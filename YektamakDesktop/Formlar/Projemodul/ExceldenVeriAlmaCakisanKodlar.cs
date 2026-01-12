using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ExceldenVeriAlmaCakisanKodlar : Form
    {
        private readonly IConvertHelper _convertHelper;
        public EventHandler<int> SecimYapildi;
        public ExceldenVeriAlmaCakisanKodlar(IConvertHelper convertHelper)
        {
            _convertHelper = convertHelper;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<ProjeStokKartDTO>(), this.Name);
        }
        public void SetData(List<ProjeStokKart> liste)
        {
            universalGrid1.SetData((liste.CastToDTO<ProjeStokKartDTO>(_convertHelper)).ToList(), this.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecimYapildi?.Invoke(this, groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r=>r.Checked).TabIndex);
            this.Close();
        }
    }
}
