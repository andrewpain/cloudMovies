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
    public partial class smallRecord : UserControl
    {
        public smallRecord()
        {
            InitializeComponent();
        }
        private string main_name;
        private Image pic;

        [Category("Custom Props")]
        public string mainName
        {
            get { return main_name; }
            set { main_name = value; suggestRecordName.Text = main_name; }
        }
        

        [Category("Custom Props")]
        public Image performPic
        {
            get { return pic; }
            set { pic = value; suggestActorPic.Image = pic; }
        }

        
    }
}
