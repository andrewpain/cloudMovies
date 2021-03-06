using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoApp
{
    public partial class Form1 : Form
    {
        AxWMPLib.AxWindowsMediaPlayer wmp;
        WebBrowser wb;
        bool searching = false;
        public bool newActorNow = false, newGenreNow = false, newAccountNow = false;
        Panel[] panelSwitches;
        //Button[] homeButtons;
        //smallRecord[] sRecords;
        //used as a holder to keep track of images that are currently in the process of being loaded
        List<string> currSearch = new List<string>();
        public enum searchType { none, actor, genre, email }
        searchType curSpec;
        customVideo currentVideo;
        Image[] specImgs;
        Font linkFont;
        bool ifNewVideo = false;
        public Form1()
        {
            InitializeComponent();
            dataControl.loadInfo();
            panelSwitches = new Panel[] { newVidPanel, allContentPanel, specRecordPanel, singleVidPanel };
            //homeButtons = new Button[] {addNewButton, buttonEmails,buttonGenre,buttonActors, buttonVideos };
            textBox1.Select();
            linkFont = singleVidGenre.Font;
        }


        #region firstPanel
        //password check
        private void button1_Click(object sender, EventArgs e) => wordCheck();
        private void textBox1_keyEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) wordCheck();
        }
        void wordCheck()
        {
            if (dataControl.info.nameOfPass != textBox1.Text) MessageBox.Show("Wrong!", "Attempt made");
            else
            {
                panelLogIn.Visible = false;
                panelHome.Visible = true;
                allContentPanel.Visible = true;
                searchBarTextBox.Select();
            }
        }
        #endregion

        #region homeFunctions
        //show meta data that organises the videos
        private void buttonActors_Click(object sender, EventArgs e) => showSpecRecords(searchType.actor);
        private void buttonEmails_Click(object sender, EventArgs e) => showSpecRecords(searchType.email);
        private void buttonGenre_Click(object sender, EventArgs e) => showSpecRecords(searchType.genre);
        void showSpecRecords(searchType st)
        {
            switchPanel(specRecordPanel);
            List<customRecord> cr = new List<customRecord>();
            string cWords = searchBarTextBox.Text.ToLower();
            string[] words = cWords.Split(' ');
            string t = "";
            switch (st)
            {
                case searchType.actor:
                    t = "Actors";
                    foreach (customPerformer sp in dataControl.info.performers)
                        cr.Add(sp);
                    break;
                case searchType.genre:
                    t = "Genres";
                    foreach (genre g in dataControl.info.genres)
                        cr.Add(g);
                    break;
                case searchType.email:
                    t = "Emails";
                    foreach (emailAccount e in dataControl.info.accounts)
                        cr.Add(e);
                    break;
            }
            /*a somewhat nifty tool when searching for specific actors/genres/emails
             *by the first letter(s) of the name 
             */
            if (words[0] != "") cr = cr.OrderByDescending(x => x.customName.ToLower().StartsWith(words[0])).ToList();
            else cr.Sort((x,y) => string.Compare(x.customName,y.customName));
            specLabel.Text = t;
            specPhoto.Image = null;
            leftSpecButton.Visible = rightSpecButton.Visible = false;
            specImgs = null;
            picNo = 0;
            deleteSpecButton.Visible = false;
            //while (specRecordHolder.Controls.Count > 0)
            //    specRecordHolder.Controls[0].Dispose();
            ctrlDispose(specRecordHolder.Controls);
            for (int i = 0; i < cr.Count; i++)
            {
                subRecord sr = new subRecord();
                sr.recordTitle = cr[i].customName;
                sr.metaData = st.ToString();
                sr.picId = cr[i].picId;
                //guPix gg = dataControl.images.Find(g => g.id == cr[i].picId);

                //if (gg != null)
                //{
                //    sr.bigPic = gg.pics[0];
                //    sr.guP = gg;
                //}
                //else if (!currSearch.Contains(cr[i].picId))
                    loadImgNow(cr[i].picId, null, null, sr);

                specRecordHolder.Controls.Add(sr);
            }

        }
        //opens the new video panel
        private void addNewButton_Click(object sender, EventArgs e)
        {
            ifNewVideo = true;
            switchPanel(newVidPanel);
            newVidName.Select();
        }
        //method that switches the view of the panels
        void switchPanel(Panel p)
        {
            if (newVidPanel.Visible) wipeNewData();
            else if (allContentPanel.Visible) ctrlDispose(allContentPanel.Controls);
            //while (allContentPanel.Controls.Count > 0)
            //    allContentPanel.Controls[0].Dispose();
            else if (specRecordPanel.Visible) ctrlDispose(specRecordHolder.Controls);
            //while (specRecordHolder.Controls.Count > 0)
            //    specRecordHolder.Controls[0].Dispose();
            foreach (Panel pp in panelSwitches)
                if (pp.Visible && pp.Name != p.Name) pp.Visible = false;
            if (!p.Visible)p.Visible = true;
            if (specImgs != null && !singleVidPanel.Visible)//since single vid panel uses specImgs as well
            {
                specImgs = null;
                picNo = 0;
            }
        }

        void ctrlDispose(Control.ControlCollection ctrls, bool skipWait = false)
        {
            while (ctrls.Count > 0) if (!ctrls[0].Disposing) ctrls[0].Dispose();
            if (!skipWait)System.Threading.SpinWait.SpinUntil(() => ctrls.Count ==0);
        }
        //loads the image to the user control
        async void loadImgNow(string id, smallRecord sr = null, sigRecord br = null, subRecord sb = null, PictureBox pb = null)
        {
            //makes sure to not search for the same image twice, thus add to currSearch list
            currSearch.Add(id);
            guPix gp = null;
            do await Task.Run(() => gp = dataControl.loadGuPix(id));
            while (gp == null);
            //await Task.Run(() => b = pixelCtrl.loadImage(gp.pic));
            Image i = gp.pics[0];
            //dataControl.images.Add(gp);
            //removes the id once the search is complete
            currSearch.Remove(id);
            //once the usercontrol is still viewable, show the image
            if (sr != null) sr.performPic = i;
            else if (br != null) { br.bigPic = i; br.Imgs = gp.pics; }
            else if (sb != null) { sb.bigPic = i; sb.guP = gp; }
            else if (pb != null)
            {
                pb.Image = i;
                if (gp.pics.Length > 1)
                { specImgs = gp.pics; picNo = 0; leftSpecButton.Visible = rightSpecButton.Visible = true; }
                else { specImgs = null; picNo = 0; leftSpecButton.Visible = rightSpecButton.Visible = false;
                    if (gp.id != dataControl.defNm) deleteSpecButton.Visible = true;else deleteSpecButton.Visible = false;}
            }
            else foreach (Image s in gp.pics)//loading images to be edited
                {
                    newVidPic nvp = new newVidPic();
                    nvp.bigPic = s;
                    newVidPicsHolder.Controls.Add(nvp);
                }
        }

        #endregion

        #region newData
        private void buttonOpenImage_Click(object sender, EventArgs e)
        {
            var codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            var codecFilter = "Image Files|";
            foreach (var codec in codecs) codecFilter += codec.FilenameExtension + ";";

            //openFileDialog1.Filter = "Image Files | *.jpg;*.jpeg;*.png";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = codecFilter;
                openFileDialog1.InitialDirectory = dataControl.lastFilePath;
                openFileDialog1.Title = "Please select an image";
                openFileDialog1.Multiselect = true;
                //openFileDialog1.ShowDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string name = openFileDialog1.FileName;
                    //newVidImage.ImageLocation = name;
                    foreach (string s in openFileDialog1.FileNames)
                    {
                        newVidPic nvp = new newVidPic();
                        nvp.bigPic = Image.FromFile(s);
                        newVidPicsHolder.Controls.Add(nvp);
                    }
                    dataControl.lastFilePath = name;
                }
            }
        }

        private void newVidActor_TextChanged(object sender, EventArgs e) => performSearch(sender);
        private void newVidGenre_TextChanged(object sender, EventArgs e) => performSearch(sender);
        private void newVidAccount_TextChanged(object sender, EventArgs e) => performSearch(sender);
        private void newVidName_TextChanged(object sender, EventArgs e) => performSearch(sender);
        //private void newLinkText_TextChanged(object sender, EventArgs e) => performSearch(sender);

        private void newVidActor_Enter(object sender, EventArgs e)
        {
            newAccountNow = newGenreNow = false;
            newActorNow = true;
            suggestedPanel.Location = new Point(suggestedPanel.Location.X, newVidActor.Location.Y - 50);
            performSearch(sender);
        }
        private void newVidGenre_Enter(object sender, EventArgs e)
        {
            newAccountNow = newActorNow = false;
            newGenreNow = true;
            suggestedPanel.Location = new Point(suggestedPanel.Location.X, newVidGenre.Location.Y - 50);
            performSearch(sender);
        }
        private void newVidAccount_Enter(object sender, EventArgs e)
        {
            newGenreNow = newActorNow = false;
            newAccountNow = true;
            suggestedPanel.Location = new Point(suggestedPanel.Location.X, newVidAccount.Location.Y - 50);
            performSearch(sender);
        }
        private void newVidName_Enter(object sender, EventArgs e)
        {
            newGenreNow = newActorNow = newAccountNow = false;
            suggestedPanel.Location = new Point(suggestedPanel.Location.X, newVidName.Location.Y /*- 50*/);
            performSearch(sender);
        }
        
        //does a search for records with a similar name for the smaller suggestedPanel
        public void performSearch(object ob)
        {
            if (!suggestedPanel.Visible) suggestedPanel.Visible = true;
            TextBox tb = (TextBox)ob;
            string[] names = tb.Text.Split(',');
            int last = names.Length - 1;
            string searchWord;
            if (tb.Name.EndsWith("Name")) searchWord = tb.Text;
            else searchWord = names[last];
            searchWord = searchWord.ToLower();

            if (suggestedPanel.Controls.Count > 0) ctrlDispose(suggestedPanel.Controls,true);
                //while (suggestedPanel.Controls.Count > 0)
                //    suggestedPanel.Controls[0].Dispose();

            List<customRecord> records = new List<customRecord>();

            if (tb.Name.EndsWith("Name") && tb.Text.Any(x => char.IsLetter(x)))
            {
                foreach (customVideo v in dataControl.info.videos)
                {
                    if (!records.Contains(v) && v.customName.ToLower().Contains(/*tb.Text*/searchWord))
                        records.Add(v);
                }
            }

            else if (tb.Name.EndsWith("Actor"))
            {
                foreach (customRecord p in dataControl.info.performers)
                    if (!records.Contains(p) && p.customName.ToLower().Contains(/*names[last]*/searchWord))
                        records.Add(p);
            }
            else if (tb.Name.EndsWith("Genre"))
            {
                foreach (customRecord g in dataControl.info.genres)
                    if (!records.Contains(g) && g.customName.ToLower().Contains(/*names[last]*/searchWord))
                        records.Add(g);
            }
            else if (tb.Name.EndsWith("Account"))
            {
                foreach (customRecord g in dataControl.info.accounts)
                    if (!records.Contains(g) && g.customName.ToLower().Contains(/*names[last]*/searchWord))
                        records.Add(g);
            }
            //once there is text in the last entered name, add new record user control
            if ((searchWord == "" || (!searchWord.Any(x => char.IsLetter(x)) && !searchWord.Any(x => char.IsNumber(x))) || records.Count == 0) && !tb.Name.EndsWith("Name"))
            {
                //sRecords = null;
                newSmallRecord nsp = new newSmallRecord();
                nsp.record_name = names[last];
                nsp.if_multi = tb.Name.EndsWith("Actor");
                suggestedPanel.Controls.Add(nsp);
                return;
            }
            //sRecords = new smallRecord[records.Count];

            //goes through all the records of data that is available
            for (int i = 0; i < records.Count; i++)
            {
                smallRecord sRecord = new smallRecord();
                sRecord.mainName = records[i].customName;
                
                //guPix gg = dataControl.images.Find(g => g.id == records[i].picId);
                //if (gg != null) sRecords[i].performPic = gg.pics[0];
                //else if (!currSearch.Contains(records[i].picId))
                    loadImgNow(records[i].picId, sRecord);
                
                suggestedPanel.Controls.Add(sRecord);
            }

        }

        //when user hits enter, then automatically add the name of the last record separated by a comma
        private void newVid_entered(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            //if Enter key is hit, and text is not empty, and search list is not empty
            if (e.KeyChar != 13 || tb.Text == "" || tb.Text == null ||
                //|| sRecords == null || sRecords[0] == null) return;
                suggestedPanel.Controls.Count == 0) return;
            smallRecord sr = null;

            try {sr = (smallRecord)suggestedPanel.Controls[0];}
            catch (Exception ex){return;}

            string[] names = tb.Text.Split(',');
            int last = names.Length - 1;
            if (tb.Name.EndsWith("Actor") || tb.Name.EndsWith("Genre") || tb.Name.EndsWith("Account"))
            {
                names[last] = sr/*[0]*/.mainName;
                tb.Text = "";
                for (int i = 0; i < names.Length; i++)
                {
                    tb.Text += names[i];
                    if (i + 1 < names.Length) tb.Text += ",";
                }
                if (tb.Name.EndsWith("Account")) tb.Text = names[0];
                tb.Select(tb.Text.Length, 0);//puts the cursor at the end
            }
        }

        private void panelNewVid_Click(object sender, EventArgs e)
        {
            if (suggestedPanel.Visible)suggestedPanel.Visible = false;
        }
        //when the save button in the new video panel is clicked
        private void newVidSave_Click(object sender, EventArgs e)
        {
            string s = "";
            if (!newVidName.Text.Any(x => char.IsLetter(x))) s = "Enter a name";
            else if (!newVidActor.Text.Any(x => char.IsLetter(x))) s = "Enter an actor";
            else if (!newVidGenre.Text.Any(x => char.IsLetter(x))) s = "Enter a genre";
            else if (!newVidAccount.Text.Any(x => char.IsLetter(x))) s = "Enter an account";
            //else if (!newVidLink.Text.Any(x => char.IsLetter(x))) s = "Enter a link";
            //else if (newVidImage.Image == null) s = "Enter a picture";
            else if (newVidPicsHolder.Controls.Count == 0) s = "Enter a picture";
            else if (ifNewVideo && dataControl.info.videos.Find(v => v.customName == newVidName.Text) != null) s = "Enter a unique name!";
            else if (!ifNewVideo && dataControl.info.videos.Find(v => v.customName == newVidName.Text) != null &&
                newVidName.Text != currentVideo.customName) s = "You can't use a name already being used by another film!";
            else if (dataControl.info.accounts.Find(v => v.customName == newVidAccount.Text) == null) s = "Enter a proper account!";
            else
            {
                string[] names = newVidActor.Text.Split(',');
                foreach (string n in names)
                    if (dataControl.info.performers.Find(v => v.customName == n) == null)
                    {
                        s = "insert performer: " + n;
                        break;
                    }
                if (s == "")
                {
                    names = newVidGenre.Text.Split(',');
                    foreach (string n in names)
                        if (dataControl.info.genres.Find(v => v.customName == n) == null)
                        {
                            s = "insert genre: " + n;
                            break;
                        }
                }
            }
            //if any information is missing, then string wouldn't be empty
            if (s != "")
            {
                MessageBox.Show(s, "Incomplete data");
                return;
            }
            //}
            
            string[] p = newVidActor.Text.Split(',');
            string[] g = newVidGenre.Text.Split(',');
            customPerformer[] cp = new customPerformer[p.Length];
            genre[] cg = new genre[g.Length];
            for (int i = 0; i < cp.Length; i++) cp[i] = new customPerformer() { customName = p[i] };
            for (int i = 0; i < cg.Length; i++) cg[i] = new genre() { customName = g[i] };

            guPix gp = new guPix() { pics = new Image[newVidPicsHolder.Controls.Count] };// { pic = newVidImage.Image };
            for(int i =0;i<newVidPicsHolder.Controls.Count;i++)
                gp.pics[i] = ((newVidPic)newVidPicsHolder.Controls[i]).bigPic;

            customVideo cv = new customVideo()
            {
                customName = newVidName.Text,
                performers = cp,
                genres = cg,
                account = new emailAccount() { customName = newVidAccount.Text },
                picId = gp.id,
                link = newVidLink.Text
            };
            //if not a new video, but updating an already existing video
            if (!ifNewVideo)
            {
                updateVideo(cv);
                return;
            }
            dataControl.info.videos.Add(cv);
            //dataControl.images.Add(gp);
            dataControl.saveInfo(gp);

            wipeNewData();
            if (suggestedPanel.Visible) suggestedPanel.Visible = false;
        }
        //clears the text in the new Video panel
        void wipeNewData()
        {
            newVidName.Text = "";
            newVidActor.Text = "";
            newVidGenre.Text = "";
            newVidAccount.Text = "";
            newVidLink.Text = "";
            //while (newVidPicsHolder.Controls.Count > 0)
            //    newVidPicsHolder.Controls[0].Dispose();
            //while (suggestedPanel.Controls.Count > 0)
            //    suggestedPanel.Controls[0].Dispose();
            ctrlDispose(newVidPicsHolder.Controls);
            ctrlDispose(suggestedPanel.Controls);
        }

        #endregion

        #region searchBar
        private void searchBar_entered(object sender, KeyPressEventArgs e)
        {
            if (!searching && e.KeyChar == 13)
            {
                doWordSearch();
            }
        }
        private void buttonVideos_Click(object sender, EventArgs e) => doWordSearch();

        void doWordSearch()
        {
            switchPanel(allContentPanel);
            wordSearch(searchType.none, null);
        }
        
        async void wordSearch(searchType search, string name)
        {
            searching = true;
            List<customVideo> vids = new List<customVideo>();

            switch (search)
            {
                //searches based on the text from the space bar
                case searchType.none:
                    string cWords = searchBarTextBox.Text.ToLower();
                    string[] words = cWords.Split(' ');
                    if (cWords != null && cWords != "")
                        foreach (customVideo v in dataControl.info.videos)
                        {
                            foreach (string w in words)
                            {
                                //video name
                                if (v.customName.ToLower().Contains(w))
                                {
                                    vids.Add(v);
                                    break;
                                }
                                //search for account
                                if (v.account.customName.ToLower() == w)
                                {
                                    vids.Add(v);
                                    break;
                                }
                                //search for performers's vids
                                foreach (customPerformer p in v.performers)
                                    if (p.customName.ToLower().Contains(w))
                                    {
                                        vids.Add(v);
                                        break;
                                    }
                                //search for genre
                                if (!vids.Contains(v))
                                    foreach (genre g in v.genres)
                                        if (g.customName.ToLower().Contains(w))
                                        {
                                            vids.Add(v);
                                            break;
                                        }

                                if (vids.Contains(v)) break;
                            }
                            if (vids.Count >= 24) break;
                            await Task.Delay(5);
                        }
                    else
                    {
                        int vl = dataControl.info.videos.Count;
                        Random r = new Random();
                        //do
                        if (dataControl.info.videos.Count > 1)
                        {
                            //|| vids.Count < dataControl.info.videos.Count

                            int rn, vc = dataControl.info.videos.Count;
                            bool lessThanCap = dataControl.info.videos.Count <= 24;
                            for (int i = 0; i < 24 && i<vc; i++)
                            {
                                if (lessThanCap) rn = i;
                                else rn = r.Next(0, vl);
                                if (!vids.Contains(dataControl.info.videos[rn])) vids.Add(dataControl.info.videos[rn]);
                                else i--;
                                await Task.Delay(5);
                            }
                        }
                    }
                    /*ordering results by the first word in search bar
                     * to make searching for movies a little easier
                     * */
                    if (words[0]!="")vids = vids.OrderByDescending(x =>
                    x.customName.ToLower().StartsWith(words[0]) ||
                    x.account.customName.ToLower().StartsWith(words[0]) ||
                    Array.Find(x.performers, customPerformer => customPerformer.customName.ToLower().Contains(words[0]))!=null ||
                    Array.Find(x.genres, genre => genre.customName.ToLower().StartsWith(words[0]))!=null
                    ).ToList();
                    else vids.Sort((x, y) => string.Compare(x.customName, y.customName));
                    break;
                    //searching for the videos with the actor
                case searchType.actor:
                    foreach (customVideo v in dataControl.info.videos)
                        if (Array.Find(v.performers, customPerformer => customPerformer.customName == name) != null)
                            vids.Add(v);
                    break;
                    //searching for videos with the genre
                case searchType.genre:
                    foreach (customVideo v in dataControl.info.videos)
                        if (Array.Find(v.genres, genre => genre.customName == name) != null)
                            vids.Add(v);
                    break;
                    //searching for videos with the email
                case searchType.email:
                    foreach (customVideo v in dataControl.info.videos)
                        if (v.account.customName == name)
                            vids.Add(v);
                    break;
            }

            Panel chosenPanel;
            if (search == searchType.none) chosenPanel = allContentPanel;
            else chosenPanel = specRecordHolder;
            //while (chosenPanel.Controls.Count > 0)
            //    chosenPanel.Controls[0].Dispose();
            ctrlDispose(chosenPanel.Controls);
            //showing the results of the search
            for (int i = 0; i < vids.Count; i++)
            {
                sigRecord sr = new sigRecord();
                sr.videoTitle = vids[i].customName;
                sr.linkUp = !string.IsNullOrEmpty(vids[i].link);
                //string s = "";
                //for (int j = 0; j < vids[i].performers.Length; j++)
                //{
                //    s += vids[i].performers[j].customName;
                //    if (j + 1 < vids[i].performers.Length) s += ",";
                //}
                //sr.actorName = s;
                //s = "";
                //for (int j = 0; j < vids[i].genres.Length; j++)
                //{
                //    s += vids[i].genres[j].customName;
                //    if (j + 1 < vids[i].genres.Length) s += ",";
                //}
                //sr.details = s;
                //sr.email = vids[i].account.customName;
                //guPix gg = dataControl.images.Find(g => g.id == vids[i].picId);
                //if (gg != null)
                //{
                //    sr.bigPic = gg.pics[0];
                //    sr.Imgs = gg.pics;
                //}
                //else if (!currSearch.Contains(vids[i].picId))
                    loadImgNow(vids[i].picId, null, sr);
                
                chosenPanel.Controls.Add(sr);
                await Task.Delay(5);
            }
            searching = false;
        }

        #endregion

        #region specDetails
        //shows the videos based on a particular genre, email or actor
        public void showSpecDetails(string sType, string word)
        {
            searchType st = searchType.none;
            customRecord r = null;
            switch (sType)
            {
                case "genre": st = searchType.genre; r = dataControl.info.genres.Find(g => g.customName ==word);
                    break;
                case "email": st = searchType.email; r = dataControl.info.accounts.Find(g => g.customName == word);
                    break;
                case "actor": st = searchType.actor; r = dataControl.info.performers.Find(g => g.customName == word);
                    break;
            }
            //setting the image and text for particular metadata(genre, email, actor)
            curSpec = st;
            switchPanel(specRecordPanel);
            specLabel.Text = word;
            if (r != null)
            {
                //guPix gp = dataControl.images.Find(g => g.id == r.picId);
                //if (gp != null)
                //{
                //    specPhoto.Image = gp.pics[0];
                //    if (gp.pics.Length > 1)
                //    {
                //        leftSpecButton.Visible = rightSpecButton.Visible = true;
                //        specImgs = gp.pics;
                //        picNo = 0;
                //    }
                //    else
                //    {
                //        leftSpecButton.Visible = rightSpecButton.Visible = false;
                //        specImgs = null;
                //        picNo = 0;
                //    }
                //    if (r.picId != dataControl.defNm) deleteSpecButton.Visible = true;
                //    else deleteSpecButton.Visible = false;
                //}
                //else if (!currSearch.Contains(r.picId))
                    loadImgNow(r.picId, null, null, null, specPhoto);
                
            }
            else MessageBox.Show(string.Format("could not find:{0} with name {1} and type of {2}", sType, word,curSpec.ToString()));
            wordSearch(st, word);
        }
        //show single video's information/metadata
        public void showSingleVid(string text, Image []imgs)
        {
            switchPanel(singleVidPanel);
            //while (singleVidActorFlow.Controls.Count > 0)
            //    singleVidActorFlow.Controls[0].Dispose();
            //while (singleVidGenreFlow.Controls.Count > 0)
            //    singleVidGenreFlow.Controls[0].Dispose();
            ctrlDispose(singleVidActorFlow.Controls);
            ctrlDispose(singleVidGenreFlow.Controls);
            singleVidPic.Image = imgs[0];
            specImgs = imgs;
            picNo = 0;
            foreach (customVideo v in dataControl.info.videos)
            {
                if (v.customName == text)
                {
                    currentVideo = v;
                    singleVidName.Text = v.customName;
                    if (!string.IsNullOrEmpty(v.link)) singleVidName.ForeColor = Color.Lime;
                    else singleVidName.ForeColor = Color.White;
                    for (int i = 0; i < v.performers.Length; i++)
                    {
                        LinkLabel ll;
                        //if (i > 0)
                        //{
                            ll = new LinkLabel();
                            ll.LinkClicked += new LinkLabelLinkClickedEventHandler(singleVidActor_LinkClicked);
                            ll.AutoSize = true;
                            ll.Font = linkFont;
                        //}
                        //else ll = singleVidActor;
                        singleVidActorFlow.Controls.Add(ll);
                        ll.Text = v.performers[i].customName;
                    }
                    for (int i = 0; i < v.genres.Length; i++)
                    {
                        LinkLabel ll;
                        //if (i > 0)
                        //{
                            ll = new LinkLabel();
                            ll.LinkClicked += new LinkLabelLinkClickedEventHandler(singleVidGenre_LinkClicked);
                            ll.AutoSize = true;
                            ll.Font = linkFont;
                        //}
                        //else ll = singleVidGenre;
                        singleVidGenreFlow.Controls.Add(ll);
                        ll.Text = v.genres[i].customName;
                    }
                    singleVidEmail.Text = v.account.customName;
                    break;
                }
            }
        }
        int picNo = 0;
        private void directSpecButton_Click(object sender, EventArgs e)
        {
            if (specImgs == null) return;
            int i;
            if (((Button)sender).Name.StartsWith("right")) i = 1;
            else i = -1;
            picNo += i;
            if (picNo < 0) picNo = specImgs.Length - 1;
            else if (picNo >= specImgs.Length) picNo = 0;
            specPhoto.Image = specImgs[picNo];
        }


        private void directSingle_Click(object sender, EventArgs e)
        {
            if (specImgs == null) return;
            int i;
            if (((Button)sender).Name.StartsWith("right")) i = 1;
            else i = -1;
            picNo += i;
            if (picNo < 0) picNo = specImgs.Length - 1;
            else if (picNo >= specImgs.Length) picNo = 0;
            singleVidPic.Image = specImgs[picNo];
        }
        private void singleVidActor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            showSpecDetails("actor", ((LinkLabel)sender).Text);

        private void singleVidGenre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            showSpecDetails("genre", ((LinkLabel)sender).Text);

        private void singleVidEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            showSpecDetails("email", ((LinkLabel)sender).Text);
        //when user clicks on the photo of specified metadata
        private void specPhoto_Click(object sender, EventArgs e)
        {
            //if (specPhoto.Dock == DockStyle.Fill)
            //{
            //    specPhoto.Dock = DockStyle.None;
            //    specPhoto.Location = new Point(specLabel.Location.X-127/*124*/, 5);
            //    specPhoto.Anchor = AnchorStyles.Top;
            //}
            //else specPhoto.Dock = DockStyle.Fill;
            if (specPicHolder.Dock == DockStyle.Fill)
            {
                specPicHolder.Dock = DockStyle.None;
                specPicHolder.Location = new Point(specLabel.Location.X - 127/*124*/, 5);
                specPicHolder.Anchor = AnchorStyles.Top;
            }
            else specPicHolder.Dock = DockStyle.Fill;
        }

        #endregion

        #region editData
        //edit specific video
        private void editVidButton_Click(object sender, EventArgs e)
        {
            ifNewVideo = false;
            switchPanel(newVidPanel);
            customVideo cv = null;
            foreach (customVideo c in dataControl.info.videos)
                if (c.customName == singleVidName.Text)
                {
                    cv = c;
                    break;
                }
            //currentVideo = cv;
            newVidName.Text = cv.customName;
            newVidActor.Text = newVidGenre.Text = "";
            for(int i =0;i< cv.performers.Length;i++)
            {
                newVidActor.Text += cv.performers[i].customName;
                if (i + 1 < cv.performers.Length) newVidActor.Text += ",";
            }
            for (int i = 0; i < cv.genres.Length; i++)
            {
                newVidGenre.Text += cv.genres[i].customName;
                if (i + 1 < cv.genres.Length) newVidGenre.Text += ",";
            }
            newVidAccount.Text = cv.account.customName;
            newVidLink.Text = cv.link;
            //newVidImage.Image = singleVidPic.Image;
            //guPix gg = dataControl.images.Find(g => g.id == cv.picId);
            //foreach (Image s in gg.pics)
            //{
            //    newVidPic nvp = new newVidPic();
            //    nvp.bigPic = s;
            //    newVidPicsHolder.Controls.Add(nvp);
            //}
            loadImgNow(cv.picId);
        }
        //when you click on save, the save button method then forwards the customVideo data to this method
        private void updateVideo(customVideo cv)
        {
            foreach (customVideo c in dataControl.info.videos)
            if (c.customName == currentVideo.customName)
                {
                    c.customName = cv.customName;
                    c.performers = cv.performers;
                    c.genres = cv.genres;
                    c.account = cv.account;
                    c.link = cv.link;
                    guPix gp = new guPix() { id = c.picId, pics = new Image[newVidPicsHolder.Controls.Count] };
                    for (int i = 0; i < gp.pics.Length; i++)
                        gp.pics[i] = ((newVidPic)newVidPicsHolder.Controls[i]).bigPic;
                    //gp.id = c.picId;
                    dataControl.saveInfo(gp);
                    //dataControl.images.Remove(dataControl.images.Find(x => x.id == gp.id));
                    //dataControl.images.Add(gp);
                    currentVideo = cv;// null;
                    showSingleVid(cv.customName, gp.pics/*[0]*/);
                    wipeNewData();
                    break;
                }

        }

        
        #endregion

        #region deleteData
        //delete video information
        private void deleteVidButton_Click(object sender, EventArgs e) => conformDeletePanel.Visible = true;       
        private void cancelDelete_Click(object sender, EventArgs e)=> conformDeletePanel.Visible = false;
        private void confirmDelete_Click(object sender, EventArgs e)
        {
            conformDeletePanel.Visible = false;
            customVideo v = dataControl.info.videos.Find(x => x.customName == singleVidName.Text);
            //dataControl.images.Remove(dataControl.images.Find(x => x.id == v.picId));
            dataControl.info.videos.Remove(v);
            dataControl.saveInfo(null);
            dataControl.deleteGuPix(v.picId);
            doWordSearch();
        }
        //delete specific metadata information
        private void deleteSpecButton_Click(object sender, EventArgs e)
        {
            if (curSpec != searchType.none && specPhoto.Image!=null) deleteSpecPanel.Visible = true;
        }
        private void cancelDeleteSpec_Click(object sender, EventArgs e)=> deleteSpecPanel.Visible = false;
        private void confirmDeleteSpec_Click(object sender, EventArgs e)
        {
            customRecord r = null;
            deleteSpecPanel.Visible = false;
            //search and find specific data
            switch (curSpec)
            {
                case searchType.actor:
                    customPerformer p;
                    r = p = dataControl.info.performers.Find(x => x.customName == specLabel.Text);
                    dataControl.info.performers.Remove(p);
                    break;
                case searchType.genre:
                    genre g;
                    r = g = dataControl.info.genres.Find(x => x.customName == specLabel.Text);
                    dataControl.info.genres.Remove(g);
                    break;
                case searchType.email:
                    emailAccount a;
                    r = a = dataControl.info.accounts.Find(x => x.customName == specLabel.Text);
                    dataControl.info.accounts.Remove(a);
                    break;
            }
            //removes image for spec data
            //dataControl.images.Remove(dataControl.images.Find(x => x.id == r.picId));
            //replaces the metadata that matches the spec info, and changes it to 'Other'
            foreach (customVideo cr in dataControl.info.videos)
                switch (curSpec)
                {
                    case searchType.actor:
                        foreach (customPerformer cp in cr.performers)
                            if (cp.customName == r.customName)
                                cp.customName = dataControl.defNm;
                        break;
                    case searchType.genre:
                        foreach (genre ge in cr.genres)
                            if (ge.customName == r.customName)
                                ge.customName = dataControl.defNm;
                        break;
                    case searchType.email:
                            if (cr.account.customName == r.customName)
                                cr.customName = dataControl.defNm;
                        break;
                }
            dataControl.saveInfo(null);
            dataControl.deleteGuPix(r.picId);
            showSpecDetails(curSpec.ToString(), dataControl.defNm);
            curSpec = searchType.none;
        }

        #endregion

        #region videoView
        private void viewVidButton_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://drive.google.com/file/d/1eg6SxCq8JTbQuaX-SnxzpaCLyXodlMcH/view?usp=sharing");
            if (currentVideo.link != null && currentVideo.link != "")
            {
                DialogResult dr = MessageBox.Show("Ready to watch?", "Opening Movie", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
                if (currentVideo.link.StartsWith("https"))
                {
                    panelHome.Visible = false;
                    browserPanel.Visible = true;
                    wb = new WebBrowser();
                    browserPanel.Controls.Add(wb);
                    wb.Dock = DockStyle.Fill;
                    wb.Navigate(currentVideo.link);
                }
                else
                {
                    panelHome.Visible = false;
                    wmp = new AxWMPLib.AxWindowsMediaPlayer();
                    wmp.PlayStateChange +=
                        new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wmpPlayStateChange);
                    wmp.MediaError +=
                        new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(wmpMediaError);
                    Controls.Add(wmp);
                    wmp.URL = currentVideo.link;
                    //none just for video, invisible to show nothing, mini for basic controls and full for everything
                    wmp.uiMode = "full";
                    wmp.Dock = DockStyle.Fill;
                    wmp.Ctlcontrols.play();
                }
            }
            else MessageBox.Show("no video link available :(");

        }
        private void wmpPlayStateChange(object o, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e/*,int NewState*/)
        {
            //if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            if (wmp.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                wmp.Dispose();
                panelHome.Visible = true;
            }
        }
        private void wmpMediaError(object o, AxWMPLib._WMPOCXEvents_MediaErrorEvent e/*object pMediaObject*/)
        {
            MessageBox.Show("Cannot play media file.");
            wmp.Dispose();
            panelHome.Visible = true;
        }

        private void leaveBrowserButton_Click(object sender, EventArgs e)
        {
            wb.Stop();
            wb.Dispose();
            browserPanel.Visible = false;
            panelHome.Visible = true;
        }
        #endregion

        #region misc

        private void newPass_Click(object sender, EventArgs e)
        {
            switchPanel(allContentPanel);
            
            newPass np = new newPass();
            allContentPanel.Controls.Add(np);
            //np.Dock = DockStyle.Fill;
        }

        private void saveSpecImgButton_Click(object sender, EventArgs e) =>
            saveImage(specPhoto.Image, specLabel.Text);
        
        private void saveVidImgButton_Click(object sender, EventArgs e) =>
            saveImage(singleVidPic.Image, singleVidName.Text);

        void saveImage(Image img, string nm)
        {
            if (specImgs != null) nm += " " + picNo;
            nm += ".png";
            if (img == null)
            {
                MessageBox.Show("No image to save right now");
                return;
            }
            img.Save(nm, System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Saved image: " + nm);
        }
        #endregion
    }
}
