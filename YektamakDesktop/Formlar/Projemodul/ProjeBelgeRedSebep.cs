using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ProjeBelgeRedSebep : Form
    {
        public string Reason { get; private set; }
        public ProjeBelgeRedSebep()
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
