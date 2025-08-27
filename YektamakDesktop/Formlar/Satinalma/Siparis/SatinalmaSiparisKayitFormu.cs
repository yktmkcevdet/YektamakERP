using Models;
using System.Windows.Forms;
using System.ComponentModel;
using YektamakDesktop.Common;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;
using System.Linq;
using Models.DTO;
using ApiService.Interfaces;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace YektamakDesktop.Formlar.Satinalma.Siparis
{
    public partial class SatinalmaSiparisKayitFormu : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaSiparisService _saService;
        public SatinalmaSiparisKayitFormu(ICache cache, ISatinalmaSiparisService saService)
        {
            _cache = cache;
            _saService = saService;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 408);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1297, 365);
            universalGrid1.TabIndex = 9;
            Controls.Add(universalGrid1);
            fcbFirmaId.SetDataSource(_cache.firmaList);
            fcbKdv.SetDataSource(_cache.kdvList);
            fcbVadeId.SetDataSource(_cache.vadeList);
            fcbDovizCinsi.SetDataSource(_cache.dovizCinsiList);
            Binding();
        }
        private SatinalmaSiparis _satinalmaSiparis;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SatinalmaSiparis satinalmaSiparis
        {
            get
            {
                if (_satinalmaSiparis == null)
                {
                    _satinalmaSiparis = new();
                }
                return _satinalmaSiparis;
            }
            set
            {
                _satinalmaSiparis = value;
                Binding();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, satinalmaSiparis, nameof(satinalmaSiparis.Id));
            BindHelper.BindData(ctbSiparisNo, satinalmaSiparis, nameof(satinalmaSiparis.siparisNo));
            BindHelper.BindData(fcbFirmaId, satinalmaSiparis.firma, nameof(satinalmaSiparis.firma.Id));
            BindHelper.BindData(fcbKdv, satinalmaSiparis.kdv, nameof(satinalmaSiparis.kdv.Id));
            BindHelper.BindData(fcbVadeId, satinalmaSiparis.vade, nameof(satinalmaSiparis.vade.Id));
            BindHelper.BindData(ctbSiparisNo, satinalmaSiparis, nameof(satinalmaSiparis.siparisNo));
            BindHelper.BindData(ctbSiparisTarihi, satinalmaSiparis, nameof(satinalmaSiparis.siparisTarihi));
            BindHelper.BindData(ctbTeslimTarihi, satinalmaSiparis, nameof(satinalmaSiparis.teslimTarihi));
            BindHelper.BindData(ctbAciklama, satinalmaSiparis, nameof(satinalmaSiparis.aciklama));
            BindHelper.BindData(ctbTutar, satinalmaSiparis, nameof(satinalmaSiparis.tutar));
            BindHelper.BindData(fcbDovizCinsi, satinalmaSiparis.dovizCinsi, nameof(satinalmaSiparis.dovizCinsi.Id));
        }
        public void UpdateMode(SatinalmaSiparis satinalmaSiparisUpdate)
        {
            satinalmaSiparis = satinalmaSiparisUpdate;
            universalGrid1.SetData(satinalmaSiparis.satinalmaSiparisDetayList.CastToDTO<SatinalmaSiparisDetayDTO>().ToList(), this.Name);
        }

        private void SatinalmaSiparisKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async void customButtonSave1_SaveButtonClick(object sender, System.EventArgs e)
        {
            string jsonResult = await _saService.SaveSatinalmaSiparis(satinalmaSiparis);
            if (!string.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error",StringComparison.OrdinalIgnoreCase))
            {
                satinalmaSiparis = JsonConvert.DeserializeObject<List<SatinalmaSiparis>>(jsonResult)[0];
                MessageBox.Show("Kayıt işlemi başarılı.");
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarısız.");
            }
        }
    }
}
