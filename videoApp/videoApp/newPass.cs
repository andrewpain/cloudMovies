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
    public partial class newPass : UserControl
    {
        public newPass()
        {
            InitializeComponent();
            textBox1.Text = textBox2.Text = "";
            textBox1.Select();
        }

        private void enterPassButton_Click(object sender, EventArgs e)
        {
            string s = "";
            if (!textBox1.Text.Any(x => char.IsLetter(x)) || !textBox2.Text.Any(x => char.IsLetter(x)))
                s = "Try entering a password with letters";
            else if (textBox1.Text != textBox2.Text)
                s = "Try enter the correct password correctly in both boxes";
            else if (textBox1.Text == textBox2.Text)
            {
                dataControl.info.nameOfPass = textBox1.Text;
                dataControl.saveInfo(null);
                textBox1.Text = textBox2.Text = "";
                s = "Password changed!";
            }
            MessageBox.Show(s);
        }
    }
}
