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
    public partial class newVidPic : UserControl
    {
        public newVidPic()
        {
            InitializeComponent();
        }
        private Image pic;
        [Category("Custom Props")]
        public Image bigPic
        {
            get { return pic; }
            set { pic = value; recordPicture.Image = pic; }
        }
        
        private void picButton_Click(object sender, EventArgs e)
        {
            var codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            var codecFilter = "Image Files|";
            foreach (var codec in codecs) codecFilter += codec.FilenameExtension + ";";

            OpenFileDialog openPicDiag = new OpenFileDialog();//.Filter = "Image Files | *.jpg;*.jpeg;*.png";
            openPicDiag.Filter = codecFilter;
            openPicDiag.InitialDirectory = @"C:\";
            openPicDiag.Title = "Please select an image";

            if (openPicDiag.ShowDialog() == DialogResult.OK)
            {
                string name = openPicDiag.FileName;
                recordPicture.ImageLocation = name;
                bigPic = recordPicture.Image;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
