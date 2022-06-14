namespace videoApp
{
    partial class subRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subRecord));
            this.linkRecord = new System.Windows.Forms.LinkLabel();
            this.recordPicture = new System.Windows.Forms.PictureBox();
            this.editButton = new System.Windows.Forms.Button();
            this.picButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.nameText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.recordPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // linkRecord
            // 
            this.linkRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRecord.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkRecord.Location = new System.Drawing.Point(3, 133);
            this.linkRecord.Name = "linkRecord";
            this.linkRecord.Size = new System.Drawing.Size(214, 29);
            this.linkRecord.TabIndex = 3;
            this.linkRecord.TabStop = true;
            this.linkRecord.Text = "record name";
            this.linkRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkRecord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecord_LinkClicked);
            // 
            // recordPicture
            // 
            this.recordPicture.Location = new System.Drawing.Point(3, 3);
            this.recordPicture.Name = "recordPicture";
            this.recordPicture.Size = new System.Drawing.Size(214, 127);
            this.recordPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.recordPicture.TabIndex = 2;
            this.recordPicture.TabStop = false;
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editButton.BackgroundImage")));
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Location = new System.Drawing.Point(167, 176);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(50, 50);
            this.editButton.TabIndex = 4;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // picButton
            // 
            this.picButton.BackColor = System.Drawing.Color.Transparent;
            this.picButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picButton.BackgroundImage")));
            this.picButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.picButton.ForeColor = System.Drawing.Color.White;
            this.picButton.Location = new System.Drawing.Point(177, 89);
            this.picButton.Name = "picButton";
            this.picButton.Size = new System.Drawing.Size(40, 40);
            this.picButton.TabIndex = 5;
            this.picButton.UseVisualStyleBackColor = false;
            this.picButton.Visible = false;
            this.picButton.Click += new System.EventHandler(this.picButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveButton.BackgroundImage")));
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(3, 176);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(50, 50);
            this.saveButton.TabIndex = 6;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // nameText
            // 
            this.nameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.nameText.ForeColor = System.Drawing.Color.White;
            this.nameText.Location = new System.Drawing.Point(8, 135);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(209, 26);
            this.nameText.TabIndex = 7;
            this.nameText.Visible = false;
            // 
            // subRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.linkRecord);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.picButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.recordPicture);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "subRecord";
            this.Size = new System.Drawing.Size(220, 239);
            ((System.ComponentModel.ISupportInitialize)(this.recordPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkRecord;
        private System.Windows.Forms.PictureBox recordPicture;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button picButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox nameText;
    }
}
