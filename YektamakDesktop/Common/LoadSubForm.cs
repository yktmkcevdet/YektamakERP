using NPOI.POIFS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Abstracts;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar;

namespace YektamakDesktop.Common
{
    public static class SubForm
    {
        public static void LoadSubForm<T>(T altForm,Panel panel,IUstForm ustForm) where T: Form, IAltForm
        {
            altForm.TopLevel = false;
            altForm.FormBorderStyle = FormBorderStyle.None;
            altForm.Dock = DockStyle.Fill;
            altForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            altForm.UstFormuBagla(ustForm);
            panel.Controls.Clear();
            panel.Controls.Add(altForm);
            altForm.Show();
        }
    }
}
