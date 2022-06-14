namespace videoApp
{
    partial class sigRecord
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkVideo = new System.Windows.Forms.LinkLabel();
            this.linkGenre = new System.Windows.Forms.LinkLabel();
            this.linkAccount = new System.Windows.Forms.LinkLabel();
            this.linkActor = new System.Windows.Forms.LinkLabel();
            this.videoPicture = new System.Windows.Forms.PictureBox();
            this.actorHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.genreHolder = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.videoPicture)).BeginInit();
            this.actorHolder.SuspendLayout();
            this.genreHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkVideo
            // 
            this.linkVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkVideo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkVideo.Location = new System.Drawing.Point(3, 228);
            this.linkVideo.Name = "linkVideo";
            this.linkVideo.Size = new System.Drawing.Size(362, 52);
            this.linkVideo.TabIndex = 1;
            this.linkVideo.TabStop = true;
            this.linkVideo.Text = "video name";
            this.linkVideo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVideo_LinkClicked);
            // 
            // linkGenre
            // 
            this.linkGenre.AutoSize = true;
            this.linkGenre.Location = new System.Drawing.Point(3, 0);
            this.linkGenre.Name = "linkGenre";
            this.linkGenre.Size = new System.Drawing.Size(68, 20);
            this.linkGenre.TabIndex = 2;
            this.linkGenre.TabStop = true;
            this.linkGenre.Text = "genre(s)";
            this.linkGenre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGenre_LinkClicked);
            // 
            // linkAccount
            // 
            this.linkAccount.Location = new System.Drawing.Point(0, 395);
            this.linkAccount.Name = "linkAccount";
            this.linkAccount.Size = new System.Drawing.Size(168, 30);
            this.linkAccount.TabIndex = 3;
            this.linkAccount.TabStop = true;
            this.linkAccount.Text = "account";
            this.linkAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAccount_LinkClicked);
            // 
            // linkActor
            // 
            this.linkActor.AutoSize = true;
            this.linkActor.Location = new System.Drawing.Point(3, 0);
            this.linkActor.Name = "linkActor";
            this.linkActor.Size = new System.Drawing.Size(63, 20);
            this.linkActor.TabIndex = 4;
            this.linkActor.TabStop = true;
            this.linkActor.Text = "actor(s)";
            this.linkActor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkActor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkActor_LinkClicked);
            // 
            // videoPicture
            // 
            this.videoPicture.Location = new System.Drawing.Point(0, 0);
            this.videoPicture.Name = "videoPicture";
            this.videoPicture.Size = new System.Drawing.Size(368, 225);
            this.videoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.videoPicture.TabIndex = 0;
            this.videoPicture.TabStop = false;
            // 
            // actorHolder
            // 
            this.actorHolder.AutoScroll = true;
            this.actorHolder.AutoSize = true;
            this.actorHolder.Controls.Add(this.linkActor);
            this.actorHolder.Location = new System.Drawing.Point(0, 280);
            this.actorHolder.Name = "actorHolder";
            this.actorHolder.Size = new System.Drawing.Size(368, 51);
            this.actorHolder.TabIndex = 5;
            // 
            // genreHolder
            // 
            this.genreHolder.AutoScroll = true;
            this.genreHolder.AutoSize = true;
            this.genreHolder.Controls.Add(this.linkGenre);
            this.genreHolder.Location = new System.Drawing.Point(0, 335);
            this.genreHolder.Name = "genreHolder";
            this.genreHolder.Size = new System.Drawing.Size(368, 57);
            this.genreHolder.TabIndex = 6;
            // 
            // sigRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.actorHolder);
            this.Controls.Add(this.genreHolder);
            this.Controls.Add(this.linkAccount);
            this.Controls.Add(this.linkVideo);
            this.Controls.Add(this.videoPicture);
            this.Name = "sigRecord";
            this.Size = new System.Drawing.Size(368, 279);
            ((System.ComponentModel.ISupportInitialize)(this.videoPicture)).EndInit();
            this.actorHolder.ResumeLayout(false);
            this.actorHolder.PerformLayout();
            this.genreHolder.ResumeLayout(false);
            this.genreHolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox videoPicture;
        private System.Windows.Forms.LinkLabel linkVideo;
        private System.Windows.Forms.LinkLabel linkGenre;
        private System.Windows.Forms.LinkLabel linkAccount;
        private System.Windows.Forms.LinkLabel linkActor;
        private System.Windows.Forms.FlowLayoutPanel actorHolder;
        private System.Windows.Forms.FlowLayoutPanel genreHolder;
    }
}
