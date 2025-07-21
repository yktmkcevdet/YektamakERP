using Models;
using Models.DTO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class SatinalmaTalepSatirDetayForm : Form
    {
        private readonly ICache _cache;
        public SatinalmaTalepSatirDetayForm(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            universalGrid1.kullanici = _cache.kullanici;
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
