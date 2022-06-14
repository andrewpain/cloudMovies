namespace videoApp
{
    partial class newPass
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.enterPassButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(223, 271);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(295, 26);
            this.textBox1.TabIndex = 15;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // enterPassButton
            // 
            this.enterPassButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.enterPassButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.enterPassButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterPassButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.enterPassButton.Location = new System.Drawing.Point(313, 452);
            this.enterPassButton.Name = "enterPassButton";
            this.enterPassButton.Size = new System.Drawing.Size(124, 44);
            this.enterPassButton.TabIndex = 17;
            this.enterPassButton.Text = "Enter";
            this.enterPassButton.UseVisualStyleBackColor = true;
            this.enterPassButton.Click += new System.EventHandler(this.enterPassButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(286, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 40);
            this.label6.TabIndex = 14;
            this.label6.Text = "New Pass";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(223, 346);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(295, 26);
            this.textBox2.TabIndex = 16;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // newPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.enterPassButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Name = "newPass";
            this.Size = new System.Drawing.Size(750, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button enterPassButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
    }
}
