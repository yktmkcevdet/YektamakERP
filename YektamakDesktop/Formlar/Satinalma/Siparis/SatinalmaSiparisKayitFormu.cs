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
using ApiService.Implementations;
using Utilities.Implementations; 

namespace YektamakDesktop.Formlar.Satinalma.Siparis
{
    public partial class SatinalmaSiparisKayitFormu : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaSiparisService _saService;
        private readonly IProjeService _projeService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IConvertHelper _convertHelper;
        public SatinalmaSiparisKayitFormu(ICache cache, ISatinalmaSiparisService saService, IProjeService projeService, IJsonConverter jsonConverter, IConvertHelper convertHelper)
        {
            _cache = cache;
            _saService = saService;
            _projeService = projeService;
            _jsonConverter = jsonConverter;
            _convertHelper = convertHelper;
            InitializeComponent();
            Initialize();
        }
        private async void Initialize()
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
            fcbFirmaId.SetDataSource(_cache.firmaList);
            fcbKdv.SetDataSource(_cache.kdvList);
            fcbVadeId.SetDataSource(_cache.vadeList);
            fcbDovizCinsi.SetDataSource(_cache.dovizCinsiList);
            universalGrid1.SetData(new List<SatinalmaSiparisDetayDTO>(),this.Name);
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
            universalGrid1.SetData(satinalmaSiparis.satinalmaSiparisDetay.CastToDTO<SatinalmaSiparisDetayDTO>(_convertHelper).ToList(), this.Name);
        }

        private void SatinalmaSiparisKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async void customButtonSave1_SaveButtonClick(object sender, System.EventArgs e)
        {
            satinalmaSiparis.satinalmaSiparisDetay = ((SortableBindingList<SatinalmaSiparisDetayDTO>)universalGrid1.binding.DataSource).CastToEntity<SatinalmaSiparisDetay>(_convertHelper).ToList();
            string jsonResult = await _saService.SaveSatinalmaSiparis(satinalmaSiparis);
            if (!string.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error",StringComparison.OrdinalIgnoreCase))
            {
                satinalmaSiparis = _jsonConverter.DeserializeObject<List<SatinalmaSiparis>>(jsonResult)[0];
                MessageBox.Show("Kayıt işlemi başarılı.");
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarısız.");
            }
        }
    }
}
