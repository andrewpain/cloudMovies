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
        private string recordName;

        [Category("Custom Props")]
        public string record_name
        {
            get { return recordName; }
            set { recordName = value; newNameText.Text = recordName; }
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
            openPicDiag.InitialDirectory = @"C:\";
            openPicDiag.Title = "Please select an image";

            //openFileDialog1.ShowDialog();
            if (openPicDiag.ShowDialog() == DialogResult.OK)
            {
                string name = openPicDiag.FileName;
                newActorPic.ImageLocation = name;
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
                guPix gp = new guPix() { pic = newActorPic.Image/*pixelCtrl.saveImage((Bitmap)newActorPic.Image)*/};
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
            dataControl.saveInfo(gp);
            //guImg gg = new guImg() { id = gp.id, img = newActorPic.Image };
            dataControl.images.Add(gp);
            newNameText.Text = "";
            newActorPic.Image = null;
        }
    }
}
