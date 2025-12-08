using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    public partial class CustomButtonNewRecord : UserControl
    {
        public CustomButtonNewRecord()
        {
            InitializeComponent();
        }
        private event EventHandler _Click;

        private void CustomButtonNewRecord_Load(object sender, EventArgs e)
        {

        }

        [Browsable(true)]
        [Category("Behavior")]
        public new event EventHandler Click
        {
            add { roundedIconButton1.Click += value; }
            remove { roundedIconButton1.Click -= value; }
        }
    }
}
