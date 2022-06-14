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
    public partial class subRecord : UserControl
    {
        public subRecord()
        {
            InitializeComponent();
        }
        private string record_title;
        private Image pic;
        private string meta_data;
        private string pic_id;

        [Category("Custom Props")]
        public string picId
        {
            get { return pic_id; }
            set { pic_id = value; }
        }
        //List<LinkLabel> actors = new List<LinkLabel>(), genres = new List<LinkLabel>(); 
        [Category("Custom Props")]
        public string metaData
        {
            get { return meta_data; }
            set { meta_data = value; }
        }
        [Category("Custom Props")]
        public string recordTitle
        {
            get { return record_title; }
            set
            {
                record_title = value;
                linkRecord.Text = record_title;
                if (record_title == dataControl.defNm) editButton.Visible = false;
            }
        }
        [Category("Custom Props")]
        public Image bigPic
        {
            get { return pic; }
            set { pic = value; recordPicture.Image = pic; }
        }

        private void linkRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f;
            try
            {
                f = (Form1)this.Parent.Parent.Parent;
            }
            catch (Exception ex)
            {
                f = (Form1)this.Parent.Parent.Parent.Parent;
            }
            f.showSpecDetails(meta_data, record_title);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editButton.Visible = linkRecord.Visible = false;
            nameText.Visible = saveButton.Visible = picButton.Visible = true;
            nameText.Text = linkRecord.Text;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            customRecord cr = null;
            if (!nameText.Text.Any(x => char.IsLetter(x)))
            {
                MessageBox.Show("Enter a name!");
                return;
            }
            switch (meta_data)
            {
                case "actor":cr = dataControl.info.performers.Find(x => x.customName == nameText.Text);
                    break;
                case "genre":cr = dataControl.info.genres.Find(x => x.customName == nameText.Text);
                    break;
                case "email":cr = dataControl.info.accounts.Find(x => x.customName == nameText.Text);
                    break;
            }

            if (cr != null && cr.picId!=pic_id)
            {
                MessageBox.Show("That name already exists!");
                return;
            }
            editButton.Visible = linkRecord.Visible = true;
            nameText.Visible = saveButton.Visible = picButton.Visible = false;
            switch (meta_data)
            {
                case "actor":
                    foreach (customPerformer sp in dataControl.info.performers)
                        if (sp.customName == linkRecord.Text) { sp.customName = nameText.Text; cr = sp; break; }
                    break;
                case "genre":
                    foreach (genre g in dataControl.info.genres)
                        if (g.customName == linkRecord.Text) { g.customName = nameText.Text; cr = g; break; }
                    break;
                case "email":
                    foreach (emailAccount ea in dataControl.info.accounts)
                        if (ea.customName == linkRecord.Text){ ea.customName = nameText.Text; cr = ea; break; }
                    break;
            }
            guPix gp = new guPix() {id = cr.picId,pic = recordPicture.Image };
            
            foreach (customVideo v in dataControl.info.videos)
                switch (meta_data)
                {
                    case "actor":
                        foreach (customPerformer p in v.performers)
                            if (p.customName == linkRecord.Text)
                                p.customName = nameText.Text;
                        break;
                    case "genre":
                        foreach (genre p in v.genres)
                            if (p.customName == linkRecord.Text)
                                p.customName = nameText.Text;
                        break;
                    case "email": if (v.account.customName == linkRecord.Text)
                            v.account.customName = nameText.Text;
                        break;
                }
            

            dataControl.saveInfo(gp);
            
            dataControl.images.Find(x => x.id == cr.picId).pic = gp.pic;
            recordTitle = nameText.Text;
            
        }
    }
}
