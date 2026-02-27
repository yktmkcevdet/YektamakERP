using System;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar
{
    public partial class RedSebep : Form
    {
        public string Reason { get; private set; }
        public RedSebep()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ctbRedSebep.TextCustom))
            {
                MessageBox.Show("Açıklama zorunludur.");
                return;
            }

            Reason = ctbRedSebep.TextCustom;
            this.DialogResult = DialogResult.OK;
        }
    }
}
