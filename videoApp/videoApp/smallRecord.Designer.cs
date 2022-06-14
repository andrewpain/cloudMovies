namespace videoApp
{
    partial class smallRecord
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
            this.suggestRecordName = new System.Windows.Forms.Label();
            this.suggestActorPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.suggestActorPic)).BeginInit();
            this.SuspendLayout();
            // 
            // suggestRecordName
            // 
            this.suggestRecordName.AutoSize = true;
            this.suggestRecordName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suggestRecordName.ForeColor = System.Drawing.Color.White;
            this.suggestRecordName.Location = new System.Drawing.Point(73, 3);
            this.suggestRecordName.Name = "suggestRecordName";
            this.suggestRecordName.Size = new System.Drawing.Size(109, 25);
            this.suggestRecordName.TabIndex = 3;
            this.suggestRecordName.Text = "actor name";
            // 
            // suggestActorPic
            // 
            this.suggestActorPic.Location = new System.Drawing.Point(3, 3);
            this.suggestActorPic.Name = "suggestActorPic";
            this.suggestActorPic.Size = new System.Drawing.Size(64, 58);
            this.suggestActorPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.suggestActorPic.TabIndex = 2;
            this.suggestActorPic.TabStop = false;
            // 
            // smallRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.suggestActorPic);
            this.Controls.Add(this.suggestRecordName);
            this.Name = "smallRecord";
            this.Size = new System.Drawing.Size(250, 64);
            ((System.ComponentModel.ISupportInitialize)(this.suggestActorPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox suggestActorPic;
        private System.Windows.Forms.Label suggestRecordName;
    }
}
