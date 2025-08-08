using Models;
using Models.DTO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepSatirDetayForm : Form
    {
        private readonly ICache _cache;
        public SatinalmaTalepSatirDetayForm(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(2, 36);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(736, 392);
            universalGrid1.TabIndex = 2;
            Controls.Add(universalGrid1);
        }
        public void UpdateMode(List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays)
        {
            List<SatinalmaTalepSatirDetayDTO> satinalmaTalepSatirDetayDTOs = new();
            foreach (var satinalmaTalepSatirDetay in satinalmaTalepSatirDetays) 
            {
                satinalmaTalepSatirDetayDTOs.Add(ConvertHelper.ToDTO<SatinalmaTalepSatirDetayDTO>(satinalmaTalepSatirDetay));
            }
            universalGrid1.SetData(satinalmaTalepSatirDetayDTOs,this.Name);
        }

    }
}
