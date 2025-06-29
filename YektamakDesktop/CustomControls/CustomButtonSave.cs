using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    public partial class CustomButtonSave : UserControl
    {
        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler SaveButtonClick;
        public CustomButtonSave()
        {
            InitializeComponent();
        }
        private void roundedIconButton1_Click(object sender, EventArgs e)
        {
            SaveButtonClick?.Invoke(this, e);
        }
    }
}
