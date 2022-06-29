using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoApp
{
    public partial class newSmallRecord : UserControl
    {
        int picNo = 0;
        guPix gp = new guPix() {pics = new Image[0] };
        private string recordName;

        [Category("Custom Props")]
        public string record_name
        {
            get { return recordName; }
            set { recordName = value; newNameText.Text = recordName; }
        }
        private bool ifMulti = false;

        [Category("Custom Props")]
        public bool if_multi
        {
            get { return ifMulti; }
            set { ifMulti = value; if (ifMulti) removePicButton.Visible = leftButton.Visible = rightButton.Visible = true;}
        }

        public newSmallRecord()
        {
            InitializeComponent();
        }

        private void addActorPic_Click(object sender, EventArgs e)
        {
            var codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            var codecFilter = "Image Files|";
            foreach (var codec in codecs) codecFilter += codec.FilenameExtension + ";";

            OpenFileDialog openPicDiag = new OpenFileDialog();
            openPicDiag.Filter = codecFilter;
            openPicDiag.InitialDirectory = dataControl.lastFilePath;
            openPicDiag.Title = "Please select an image";
            if (ifMulti) openPicDiag.Multiselect = true;
            //openFileDialog1.ShowDialog();
            if (openPicDiag.ShowDialog() == DialogResult.OK)
            {
                if (!ifMulti)
                {
                    if (gp.pics.Length == 0) gp.pics = new Image[1];
                    string name = openPicDiag.FileName;
                    newActorPic.ImageLocation = name;
                    gp.pics[0] = Image.FromFile(name);
                }
                else
                {
                    Image[] imgs = (Image[])this.gp.pics.Clone();
                    gp.pics = new Image[imgs.Length + openPicDiag.FileNames.Length];
                    for (int i = 0; i < openPicDiag.FileNames.Length; i++)
                        gp.pics[i] = Image.FromFile(openPicDiag.FileNames[i]);
                    for (int i =0,j= openPicDiag.FileNames.Length; j < gp.pics.Length; i++,j++)
                        gp.pics[j] = imgs[i];
                    newActorPic.Image = gp.pics[picNo];
                }
                dataControl.lastFilePath = openPicDiag.FileName;
            }
        }

        private void newActorButton_Click(object sender, EventArgs e)
        {
            if (newActorPic.Image == null || !newNameText.Text.Any(x => char.IsLetter(x)))
            {
                string s;
                if (newActorPic.Image == null) s = "Choose a picture";
                else s = "Type in a name";
                MessageBox.Show(s,"Not Complete");
                return;
            }
            //guPix gp = new guPix() { pics = this.gp.pics/*newActorPic.Image*//*pixelCtrl.saveImage((Bitmap)newActorPic.Image)*/};
            Form1 f = (Form1)this.Parent.Parent.Parent.Parent;
            if (f.newActorNow)
            {
                if (dataControl.info.performers.Find(x => x.customName == newNameText.Text) != null)
                {
                    MessageBox.Show("Actor already exists!");
                    return;
                }
                customPerformer cp = new customPerformer()
                { customName = newNameText.Text, picId = gp.id };
                dataControl.info.performers.Add(cp);
            }
            else if (f.newGenreNow)
            {
                if (dataControl.info.genres.Find(x => x.customName == newNameText.Text) != null)
                {
                    MessageBox.Show("Genre already exists!");
                    return;
                }
                genre cp = new genre()
                { customName = newNameText.Text, picId = gp.id };
                dataControl.info.genres.Add(cp);

            }
            else if (f.newAccountNow)
            {
                if (dataControl.info.accounts.Find(x => x.customName == newNameText.Text) != null)
                {
                    MessageBox.Show("Account already exists!");
                    return;
                }
                emailAccount cp = new emailAccount()
                { customName = newNameText.Text, picId = gp.id };
                dataControl.info.accounts.Add(cp);
            }
            Image temp = gp.pics[picNo];
            gp.pics[picNo] = gp.pics[0];
            gp.pics[0] = temp;
            dataControl.saveInfo(gp);
            //guImg gg = new guImg() { id = gp.id, img = newActorPic.Image };
            //dataControl.images.Add(gp);
            newNameText.Text = "";
            newActorPic.Image = null;
            gp = new guPix() { pics = new Image[0] };
            picNo = 0;
        }

        private void directButton_Click(object sender, EventArgs e)
        {
            int i;
            if (((Button)sender).Name.StartsWith("right")) i = 1;
            else i = -1;
            nextPic(i);
        }

        private void removePicButton_Click(object sender, EventArgs e)
        {
            if (gp.pics.Length == 1)
            {
                MessageBox.Show("Must have at least one image!");
                return;
            }
            Image[] imgs = (Image[])this.gp.pics.Clone();
            gp.pics = new Image[imgs.Length - 1];
            for (int i = 0, j = 0; i < gp.pics.Length; i++, j++)
            {
                if (i == picNo) j++;
                gp.pics[i] = imgs[j];
            }
            nextPic(-1);
        }
        void nextPic(int i)
        {
            if (gp.pics.Length == 0) return;
            picNo += i;
            if (picNo < 0) picNo = gp.pics.Length - 1;
            else if (picNo >= gp.pics.Length) picNo = 0;
            newActorPic.Image = gp.pics[picNo];

        }
    }
}
