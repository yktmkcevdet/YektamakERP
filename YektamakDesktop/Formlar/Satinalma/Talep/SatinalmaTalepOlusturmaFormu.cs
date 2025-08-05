using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepOlusturmaFormu : Form, IUstForm
    {
        private readonly ICache _cache;
        private readonly ISatinalmaTalepService _satinalmaTalepService;
        private readonly IJsonConverter _jsonConverter;
        public SatinalmaTalepOlusturmaFormu(ICache cache, ISatinalmaTalepService satinalmaTalepService, IJsonConverter jsonConverter)
        {
            _cache = cache;
            _satinalmaTalepService = satinalmaTalepService;
            _jsonConverter = jsonConverter;
            InitializeComponent();
            ctbTalepNo.Enabled = false;
            customDataGrid = new CustomDataGrid<DataControlSatinalmaTalepDetay>(2, 30, new Point(0, 0), new Size(990, 300));
            customDataGrid.SetUstForm(this);
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref fcbProjeKod);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref clbStokTip);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            satinalmaTalep.talepEdenKullanici.Id = _cache.kullanici.Id;
            BindData();
        }
        public event EventHandler<object> VeriDegisti;
        CustomDataGrid<DataControlSatinalmaTalepDetay> customDataGrid;
        SatinalmaTalep _satinalmaTalep;
        public SatinalmaTalep satinalmaTalep
        {
            get { if (_satinalmaTalep == null) { _satinalmaTalep = new(); } return _satinalmaTalep; }
            set
            {
                _satinalmaTalep = value;
                BindData();
            }
        }
        public void UpdateMode(SatinalmaTalep satinalmaTalep)
        {
            this.satinalmaTalep = satinalmaTalep;
        }
        private void BindData()
        {
            clbMalzemeGrup.DataBindings.Clear();
            clbMalzemeGrup.DataBindings.Add("SelectedValue", satinalmaTalep.malzemeGrup, nameof(satinalmaTalep.malzemeGrup.Id), true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokTip.DataBindings.Clear();
            clbStokTip.DataBindings.Add("SelectedValue", satinalmaTalep.stokTip, nameof(satinalmaTalep.stokTip.Id), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAciklama.DataBindings.Clear();
            ctbAciklama.DataBindings.Add("TextCustom", satinalmaTalep, nameof(satinalmaTalep.aciklama), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTalepNo.DataBindings.Clear();
            ctbTalepNo.DataBindings.Add("TextCustom", satinalmaTalep, nameof(satinalmaTalep.satinalmaTalepNo), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTeslimTarihi.DataBindings.Clear();
            ctbTeslimTarihi.DataBindings.Add("TextCustom", satinalmaTalep, nameof(satinalmaTalep.teslimTarihi), true, DataSourceUpdateMode.OnPropertyChanged);
            fcbProjeKod.DataBindings.Clear();
            fcbProjeKod.DataBindings.Add("SelectedValue", satinalmaTalep.proje, nameof(satinalmaTalep.proje.Id), true, DataSourceUpdateMode.OnPropertyChanged);
            satinalmaTalep.talepTarihi = DateTime.Today;
            satinalmaTalep.talepEdenKullanici = _cache.kullanici;
            List<DataControlSatinalmaTalepDetay> dataControlSatinalmaTalepDetays = new();
            foreach (var satinalmaTalepDetay in satinalmaTalep.satinalmaTalepDetays)
            {
                DataControlSatinalmaTalepDetay dataControlSatinalmaTalepDetay = DIContainer.GetService<DataControlSatinalmaTalepDetay>();
                if (!dataControlSatinalmaTalepDetay.ValidateFields()) return;
                dataControlSatinalmaTalepDetay.satinalmaTalepDetay = satinalmaTalepDetay;
                dataControlSatinalmaTalepDetays.Add(dataControlSatinalmaTalepDetay);
            }
            customDataGrid.dataSource = dataControlSatinalmaTalepDetays;
        }
        private void clbStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == int.Parse(clbStokGrup.SelectedValue.ToString())).ToList(), ref clbMalzemeGrup);
        }

        private void clbMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }

        private void clbStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }
        private async void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            bool isValid = true;
            isValid &= GlobalData.CheckField("Proje kodu seçilmelidir", this, fcbProjeKod);
            isValid &= GlobalData.CheckField("Stok grubu seçilmelidir", this, clbStokGrup);
            isValid &= GlobalData.CheckField("Malzeme grubu seçilmelidir", this, clbMalzemeGrup);
            isValid &= GlobalData.CheckField("Teslim tarihi girilmelidir", this, ctbTeslimTarihi);
            isValid &= GlobalData.CheckField("Talep detayı girilmelidir", customDataGrid);
            if (!isValid) return;
            satinalmaTalep.satinalmaTalepDetays.Clear();
            foreach (var dataControlSatinalmaTalepDetay in customDataGrid.dataSource.Where(x => x.newRec == false))
            {
                if (!dataControlSatinalmaTalepDetay.ValidateFields()) return;
                SatinalmaTalepDetay satinalmaTalepDetay = new();
                satinalmaTalepDetay = dataControlSatinalmaTalepDetay.satinalmaTalepDetay;
                satinalmaTalep.satinalmaTalepDetays.Add(satinalmaTalepDetay);
            }
            satinalmaTalep.talepTarihi = DateTime.Today;
            string jsonResult = await _satinalmaTalepService.SaveSatinalmaTalep(satinalmaTalep);
            Result resultModel = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            if (resultModel.result != null && !resultModel.result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                satinalmaTalep = _jsonConverter.ToModelList<SatinalmaTalep>(resultModel.result).FirstOrDefault();
                MessageBox.Show("Satınalma talebi başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Satınalma talebi kaydedilemedi. " + resultModel.result, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }
    }
    public class DataControlSatinalmaTalepDetay : DataControl, IEntity, IAltForm
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly IStokService _stokService;
        private readonly IProjeService _projeService;
        public DataControlSatinalmaTalepDetay(SatinalmaTalep satinalmaTalep)
        {
            _satinalmaTalep = satinalmaTalep;
        }
        public DataControlSatinalmaTalepDetay()
        {
        }
        private void Initialize()
        {
            stokKartId.SelectedIndexChanged += StokKartId_SelectedIndexChanged;
            BindData();
        }
        public void UstFormuBagla(IUstForm ustForm)
        {
            ustForm.VeriDegisti += UstVerisiDegisti;
        }
        private static List<ProjeStokKart> _stokKarts;
        public static List<ProjeStokKart> stokKarts
        {
            get { if (_stokKarts == null) { _stokKarts = new(); } return _stokKarts; }
            set { _stokKarts = value; }
        }
        private async void UstVerisiDegisti(object sender, object yeniDeger)
        {
            _satinalmaTalep = (SatinalmaTalep)yeniDeger;
            stokKarts.Clear();
            ProjeStokKart projeStokKart = new ProjeStokKart();
            projeStokKart.proje.Id = satinalmaTalep.proje.Id;
            projeStokKart.stokKart.malzemeGrup.Id = satinalmaTalep.malzemeGrup.Id;
            projeStokKart.stokKart.stokTip.Id = satinalmaTalep.stokTip.Id;
            string jsonResult = await _projeService.GetProjeStokKart(projeStokKart);
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            if (result?.result != null)
            {
                stokKarts = JsonConvert.DeserializeObject<List<ProjeStokKart>>(result.result);
                
            }
            ComboBoxListFill.GetLookupAd(stokKarts.Select(x => new StokKart{ Id=x.stokKart.Id, ad=$"{x.stokKart.kod} - {x.stokKart.ad} - {x.stokKart.boyut}",olcuBirim=x.stokKart.olcuBirim}).ToList(), ref _stokKartId);
        }
        public DataControlSatinalmaTalepDetay(IJsonConverter jsonConverter, IStokService stokService, IProjeService projeService)
        {
            _jsonConverter = jsonConverter;
            _stokService = stokService;
            _projeService = projeService;
            Initialize();
        }
        private void StokKartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = stokKartId.SelectedItem as StokKart;
            olcuBirimi.TextCustom = selected.olcuBirim.ad;
        }
        private static SatinalmaTalep _satinalmaTalep;
        public static SatinalmaTalep satinalmaTalep
        {
            get { if (_satinalmaTalep == null) { _satinalmaTalep = new(); } return _satinalmaTalep; }
            set
            {
                _satinalmaTalep = value;
            }
        }
        private SatinalmaTalepDetay _satinalmaTalepDetay;
        public SatinalmaTalepDetay satinalmaTalepDetay
        {
            get { if (_satinalmaTalepDetay == null) { _satinalmaTalepDetay = new(); } return _satinalmaTalepDetay; }
            set
            {
                _satinalmaTalepDetay = value;
                BindData();
            }
        }
        public CustomTextBox Id { get; set; } = new() { TabIndex = 1, Width = 0, Visible = true, Tag = "Id" };
        public FilterableComboBox _stokKartId;
        public FilterableComboBox stokKartId
        {
            get
            {
                if (_stokKartId == null)
                {
                    _stokKartId = new() { TabIndex = 2, Width = 300, Visible = true, Tag = "Stok Kartı", DisplayMember = "ad", ValueMember="Id" };
                    _stokKartId.SetDataSource(stokKarts.Select(x => new StokKart { Id = x.stokKart.Id, ad = $"{x.stokKart.kod} - {x.stokKart.ad} - {x.stokKart.boyut}" }).ToList());
                }
                return _stokKartId;
            }
            set { _stokKartId = value; }
        }

        public CustomTextBoxSayisal miktar { get; set; } = new() { TabIndex = 3, Width = 100, Visible = true, Tag = "Miktar" };
        public CustomTextBox olcuBirimi { get; set; } = new() { TabIndex = 4, Width = 50, Visible = true, Tag = "Ölçü Birimi", Enabled=false };
        public CustomTextBox aciklama { get; set; } = new() { TabIndex = 5, Width = 350, Visible = true, Tag = "Açıklama" };

        private void BindData()
        {
            Id.DataBindings.Clear();
            stokKartId.DataBindings.Clear();
            miktar.DataBindings.Clear();
            olcuBirimi.DataBindings.Clear();
            aciklama.DataBindings.Clear();
            Id.DataBindings.Add(nameof(Id.TextCustom), satinalmaTalepDetay, nameof(satinalmaTalepDetay.Id), true, DataSourceUpdateMode.OnPropertyChanged);
            miktar.DataBindings.Add(nameof(miktar.TextCustom), satinalmaTalepDetay, nameof(satinalmaTalepDetay.miktar), true, DataSourceUpdateMode.OnPropertyChanged);
            olcuBirimi.DataBindings.Add(nameof(olcuBirimi.TextCustom), satinalmaTalepDetay.stokKart.olcuBirim, nameof(satinalmaTalepDetay.stokKart.olcuBirim.ad), true, DataSourceUpdateMode.OnPropertyChanged);
            stokKartId.DataBindings.Add(nameof(stokKartId.SelectedValue), satinalmaTalepDetay.stokKart, nameof(satinalmaTalepDetay.stokKart.Id), true, DataSourceUpdateMode.OnPropertyChanged);
            aciklama.DataBindings.Add(nameof(aciklama.TextCustom), satinalmaTalepDetay, nameof(satinalmaTalepDetay.aciklama), true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public bool ValidateFields()
        {
            bool isValid = true;
            isValid &= GlobalData.CheckField("Stok kartı seçilmelidir", stokKartId);
            isValid &= GlobalData.CheckField("Miktar girilmelidir", miktar);
            return isValid;
        }
    }

}
