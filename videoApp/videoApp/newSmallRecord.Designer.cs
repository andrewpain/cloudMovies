namespace videoApp
{
    partial class newSmallRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newSmallRecord));
            this.newActorPic = new System.Windows.Forms.PictureBox();
            this.newNameText = new System.Windows.Forms.TextBox();
            this.addActorPic = new System.Windows.Forms.Button();
            this.newActorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.newActorPic)).BeginInit();
            this.SuspendLayout();
            // 
            // newActorPic
            // 
            this.newActorPic.Location = new System.Drawing.Point(3, 3);
            this.newActorPic.Name = "newActorPic";
            this.newActorPic.Size = new System.Drawing.Size(64, 58);
            this.newActorPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.newActorPic.TabIndex = 7;
            this.newActorPic.TabStop = false;
            // 
            // newNameText
            // 
            this.newNameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.newNameText.ForeColor = System.Drawing.Color.White;
            this.newNameText.Location = new System.Drawing.Point(75, 12);
            this.newNameText.Name = "newNameText";
            this.newNameText.Size = new System.Drawing.Size(172, 26);
            this.newNameText.TabIndex = 6;
            // 
            // addActorPic
            // 
            this.addActorPic.BackColor = System.Drawing.Color.Transparent;
            this.addActorPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addActorPic.BackgroundImage")));
            this.addActorPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addActorPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addActorPic.ForeColor = System.Drawing.Color.White;
            this.addActorPic.Location = new System.Drawing.Point(27, 21);
            this.addActorPic.Name = "addActorPic";
            this.addActorPic.Size = new System.Drawing.Size(40, 40);
            this.addActorPic.TabIndex = 9;
            this.addActorPic.UseVisualStyleBackColor = false;
            this.addActorPic.Click += new System.EventHandler(this.addActorPic_Click);
            // 
            // newActorButton
            // 
            this.newActorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newActorButton.BackgroundImage")));
            this.newActorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.newActorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newActorButton.ForeColor = System.Drawing.Color.White;
            this.newActorButton.Location = new System.Drawing.Point(100, 56);
            this.newActorButton.Name = "newActorButton";
            this.newActorButton.Size = new System.Drawing.Size(50, 50);
            this.newActorButton.TabIndex = 8;
            this.newActorButton.UseVisualStyleBackColor = true;
            this.newActorButton.Click += new System.EventHandler(this.newActorButton_Click);
            // 
            // newSmallRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.addActorPic);
            this.Controls.Add(this.newActorPic);
            this.Controls.Add(this.newNameText);
            this.Controls.Add(this.newActorButton);
            this.Name = "newSmallRecord";
            this.Size = new System.Drawing.Size(250, 121);
            ((System.ComponentModel.ISupportInitialize)(this.newActorPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox newActorPic;
        private System.Windows.Forms.TextBox newNameText;
        private System.Windows.Forms.Button addActorPic;
        private System.Windows.Forms.Button newActorButton;
    }
}
