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
    public partial class sigRecord : UserControl
    {
        private string video_title;
        private string actor_name;
        private string genre;
        private string account;
        private Image pic;
        //List<LinkLabel> actors = new List<LinkLabel>(), genres = new List<LinkLabel>(); 
        [Category("Custom Props")]
        public string videoTitle
        {
            get { return video_title; }
            set { video_title = value; linkVideo.Text = video_title; }
        }

        [Category("Custom Props")]
        public string actorName
        {
            get { return actor_name; }
            set
            {
                actor_name = value;
                string[] nm = actor_name.Split(',');
                LinkLabel ll;
                for(int i =0;i<nm.Length;i++)
                {
                    if (i > 0)
                    {
                        ll = new LinkLabel();
                        this.actorHolder.Controls.Add(ll);
                        ll.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkActor_LinkClicked);
                        ll.AutoSize = true;
                    }
                    else ll = linkActor;
                    ll.Text = nm[i];
                }
            }
        }
        [Category("Custom Props")]
        public string details
        {
            get { return genre; }
            set
            {
                genre = value;
                string[] nm = genre.Split(',');
                LinkLabel ll;
                for (int i = 0; i < nm.Length; i++)
                {
                    if (i > 0)
                    {
                        ll = new LinkLabel();
                        this.genreHolder.Controls.Add(ll);
                        ll.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkGenre_LinkClicked);
                        ll.AutoSize = true;
                    }
                    else ll = linkGenre;
                    ll.Text = nm[i];
                }
            }
        }

        [Category("Custom Props")]
        public Image bigPic
        {
            get { return pic; }
            set { pic = value; videoPicture.Image = pic; }
        }

        [Category("Custom Props")]
        public string email
        {
            get { return account; }
            set { account = value; linkAccount.Text = account; }
        }
        public sigRecord()
        {
            InitializeComponent();
        }

        private void linkActor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToSpecRecord("actor",((LinkLabel)sender).Text);
        }

        private void linkGenre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToSpecRecord("genre", ((LinkLabel)sender).Text);
        }

        private void linkAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToSpecRecord("email", account);
        }
        void goToSpecRecord(string rType, string name)
        {
            getForm().showSpecDetails(rType, name);
        }
        private void linkVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getForm().showSingleVid(((LinkLabel)sender).Text,pic);
        }

        Form1 getForm()
        {
            Form1 f;
            try
            {
                f = (Form1)this.Parent.Parent.Parent;
            }
            catch (Exception e)
            {
                f = (Form1)this.Parent.Parent.Parent.Parent;
            }
            return f;
        }
    }
}
