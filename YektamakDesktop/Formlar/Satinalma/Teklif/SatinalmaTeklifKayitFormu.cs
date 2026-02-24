using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma.Siparis;

namespace YektamakDesktop.Formlar.Satinalma.Teklif
{
    public partial class SatinalmaTeklifKayitFormu : Form
    {
        private readonly ISatinalmaTeklifService _satinalmaTeklifService;
        private readonly IConvertHelper _convertHelper;
        private readonly ICache _cache;
        private readonly IDataTableMapper _dataTableMapper;
        public SatinalmaTeklifKayitFormu(ISatinalmaTeklifService satinalmaTeklifService, IConvertHelper convertHelper, ICache cache, IDataTableMapper dataTableMapper)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _convertHelper = convertHelper;
            _cache = cache;
            _dataTableMapper = dataTableMapper;
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
            universalGrid1.CellValueChanged += universalGrid1_CellEndEdit;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<SatinalmaTeklifDetayDTO>(), this.Name);
            fcbFirma.SetDataSource(_cache.firmaList);
            clbDoviz.SetDataSource(_cache.dovizCinsiList);
            clbVade.SetDataSource(_cache.vadeList);
        }
        private SatinalmaTeklifBaslik _satinalmaTeklifBaslik;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SatinalmaTeklifBaslik satinalmaTeklifBaslik
        {
            get
            {
                if (_satinalmaTeklifBaslik == null)
                {
                    _satinalmaTeklifBaslik = new();
                }
                return _satinalmaTeklifBaslik;
            }
            set
            {
                _satinalmaTeklifBaslik = value;
                Binding();
            }
        }
        private async void customButtonSave1_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }
            try
            {
                SortableBindingList<SatinalmaTeklifDetayDTO> detay = (SortableBindingList<SatinalmaTeklifDetayDTO>)universalGrid1.binding.DataSource;
                satinalmaTeklifBaslik.satinalmaTeklifDetayList.Clear();
                foreach (var item in detay)
                {
                    satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(_convertHelper.ToEntity<SatinalmaTeklifDetay>(item));
                }
                string jsonResult = await _satinalmaTeklifService.SaveSatinalmaTeklif(satinalmaTeklifBaslik);
                if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(jsonResult);
                }
                else
                {
                    var nentity = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(jsonResult);
                    MessageBox.Show("Kayıt Başarılı");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool ValidateForm()
        {
            bool result = true;
            result &= CheckFieldHelper.CheckField("Firma Seçiniz", fcbFirma);
            result &= CheckFieldHelper.CheckField("Teklif Tarihi Giriniz", ctbTeklifTarihi);
            result &= CheckFieldHelper.CheckField("Teklif Talep Tarihi Giriniz", ctbTeklifTalepTarihi);
            result &= CheckFieldHelper.CheckField("*", clbDoviz);
            result &= CheckFieldHelper.CheckField("Teklif Tutarı Giriniz", ctbTutar);
            result &= CheckFieldHelper.CheckField("Teklif Geçerlilik Süresi Giriniz", ctbTeklifGecerlilikSuresi);
            result &= CheckFieldHelper.CheckField("Termin Süresi Giriniz", ctbTerminSuresi);
            result &= CheckFieldHelper.CheckField("*", clbVade);
            return result;
        }
        public void UpdateMode(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            try
            {
                this.satinalmaTeklifBaslik = satinalmaTeklifBaslik;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Binding()
        {
            BindHelper.BindData(ctbTeklifNo, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifNo));
            BindHelper.BindData(fcbFirma, satinalmaTeklifBaslik.teklifFirma, nameof(satinalmaTeklifBaslik.teklifFirma.Id));
            BindHelper.BindData(ctbTeklifTalepTarihi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifTalepTarihi));
            BindHelper.BindData(ctbTerminSuresi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.terminSuresi));
            BindHelper.BindData(ctbTeklifTarihi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifTarihi));
            BindHelper.BindData(clbVade, satinalmaTeklifBaslik.vade, nameof(satinalmaTeklifBaslik.vade.Id));
            BindHelper.BindData(ctbTutar, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifTutar));
            BindHelper.BindData(clbDoviz, satinalmaTeklifBaslik.dovizCinsi, nameof(satinalmaTeklifBaslik.dovizCinsi.Id));
            BindHelper.BindData(ctbTeklifGecerlilikSuresi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifGecerlilikSuresi));
            BindHelper.BindData(ctbAciklama, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.aciklama));

            List<SatinalmaTeklifDetayDTO> satinalmaTeklifDetayDTOs = new();
            foreach (var item in satinalmaTeklifBaslik.satinalmaTeklifDetayList)
            {
                satinalmaTeklifDetayDTOs.Add(_convertHelper.ToDTO<SatinalmaTeklifDetayDTO>(item));
            }
            await universalGrid1.SetData(satinalmaTeklifDetayDTOs, this.Name);
        }

        private async void SatinalmaTeklifKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            await universalGrid1.SaveGridSettings();
        }

        private async void btnSipariseDonustur_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }
            SatinalmaSiparisDTO satinalmaSiparis = new SatinalmaSiparisDTO();
            satinalmaSiparis.siparisTarihi = DateTime.Today;
            satinalmaSiparis.tutar = satinalmaTeklifBaslik.teklifTutar;
            satinalmaSiparis.firmaId = satinalmaTeklifBaslik.teklifFirma.Id;
            satinalmaSiparis.aciklama = satinalmaTeklifBaslik.aciklama;
            satinalmaSiparis.vadeId = satinalmaTeklifBaslik.vade.Id;
            satinalmaSiparis.tutar = satinalmaTeklifBaslik.teklifTutar;
            satinalmaSiparis.dovizCinsiId = satinalmaTeklifBaslik.dovizCinsi.Id;
            satinalmaSiparis.teslimTarihi = DateTime.Today.AddDays(Convert.ToDouble(satinalmaTeklifBaslik.terminSuresi));
            satinalmaSiparis.kdvId = 1; 
            foreach (var item in satinalmaTeklifBaslik.satinalmaTeklifDetayList)
            {
                SatinalmaSiparisDetay satinalmaSiparisDetay = new SatinalmaSiparisDetay();
                satinalmaSiparisDetay.miktar = item.satinalmaTalepDetay.miktar;
                satinalmaSiparisDetay.aciklama = item.satinalmaTalepDetay.aciklama;
                satinalmaSiparisDetay.birimFiyat = item.birimFiyat;
                satinalmaSiparisDetay.projeStokKart = item.satinalmaTalepDetay.projeStokKart;
                satinalmaSiparis.satinalmaSiparisDetay.Add(satinalmaSiparisDetay);
            }
            var satinalmaSiparisKayitFormu = FormFactory.CreateForm<SatinalmaSiparisKayitFormu>();
            satinalmaSiparisKayitFormu.UpdateMode(satinalmaSiparis);
            satinalmaSiparisKayitFormu.ShowDialog();
        }

        private void universalGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == universalGrid1.Grid.Columns["Miktar"].Index ||
                e.ColumnIndex == universalGrid1.Grid.Columns["Birim fiyat"].Index)
            {
                var row = universalGrid1.Grid.Rows[e.RowIndex];
                //if (double.TryParse(Convert.ToString(row.Cells["Miktar"].Value), out double miktar) &&
                //    double.TryParse(Convert.ToString(row.Cells["Birim fiyat"].Value), out double fiyat))
                //{
                //    row.Cells["Birim fiyat"].Value = miktar * fiyat;
                //}
                HesaplaToplam();
            }
        }
        private void HesaplaToplam()
        {
            double toplam = 0;
            foreach (DataGridViewRow row in universalGrid1.Grid.Rows)
            {
                if (row.Cells["Birim fiyat"].Value != null)
                {
                    double.TryParse(row.Cells["Birim fiyat"].Value.ToString(), out double brFiyatValue);
                    double.TryParse(row.Cells["Miktar"].Value.ToString(), out double miktarValue);
                    toplam += brFiyatValue * miktarValue;
                }
            }

            ctbTutar.TextCustom = toplam.ToString();
        }
    }
}
