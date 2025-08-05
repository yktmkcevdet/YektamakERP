using ApiService.Interfaces;
using Models;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartKayitFormu : Form
    {
        private readonly IStokService _stokService;
        private readonly ICache _cache;
        private readonly IDataTableMapper _dataTableHelper;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;

        private ProjeStokKart _projeStokKart;
        public ProjeStokKart projeStokKart
        {
            get
            {
                if (_projeStokKart == null) { _projeStokKart = new ProjeStokKart(); }
                return _projeStokKart;
            }
            set
            {
                _projeStokKart = value;
                Binding();
            }
        }
        

        public StokKartKayitFormu(ICache cache, IDataTableMapper dataTableHelper, IJsonConverter jsonConvertHelper, IStokService stokService, IProjeService projeService)
        {
            _cache = cache;
            _dataTableHelper = dataTableHelper;
            _jsonConverter = jsonConvertHelper;
            _stokService = stokService;
            _projeService = projeService;
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref clbStokTip);
            ComboBoxListFill.GetLookupAd(_cache.olcuBirims, ref clbOlcuBirim);
            ComboBoxListFill.GetLookupAd(_cache.malzemeStandarts, ref clbMalzemeStandart);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref clbProjeKod);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups, ref clbMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List, ref clbMalzemeAltGrup2);
            projeStokKart = new ProjeStokKart();
        }

        public void UpdateMode(ProjeStokKart stokKartToUpdate)
        {
            projeStokKart = stokKartToUpdate;
            
        }
        
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*", this, ctbStokAd) && result;
            result = GlobalData.CheckField("*", this, clbStokTip) && result;
            result = GlobalData.CheckField("*", this, clbStokGrup) && result;
            result = GlobalData.CheckField("*", this, clbMalzemeGrup) && result;
            result = GlobalData.CheckField("*", this, clbMalzemeAltGrup2) && result;
            result = GlobalData.CheckField("*", this, clbMalzemeAltGrup) && result;
            return result;
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if(!CheckFields())
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
                return;
            }
            var data = customDataGrid.dataSource;
            projeStokKart.stokKart.dosyaList.Clear();
            foreach(var item in data.Where(s=>s.newRec==false))
            {
                projeStokKart.stokKart.dosyaList.Add(item.stokKartDosya);
            }
            string jsonResult = await _projeService.SaveProjeStokKart(projeStokKart);
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            if (result?.result==null || result.result.Contains("error",StringComparison.OrdinalIgnoreCase)) 
            {
                MessageBox.Show("Stok kart kaydı sırasında bir hata oluştu: " + result?.result);
            }
            else
            {
                ProjeStokKart savedProjeStokKart = JsonConvert.DeserializeObject<List<ProjeStokKart>>(result.result).FirstOrDefault();
                projeStokKart = savedProjeStokKart;
                MessageBox.Show("Stok Kartı Kayıt Edildi");
            }
        }
        private void Binding()
        {
            ctbId.DataBindings.Clear();
            clbProjeKod.DataBindings.Clear();
            ctbKod.DataBindings.Clear();
            ctbStokAd.DataBindings.Clear();
            ctbBoyut.DataBindings.Clear();
            ctbUzunluk.DataBindings.Clear();
            ctbAciklama.DataBindings.Clear();
            ctbAgirlik.DataBindings.Clear();
            ctbBoy.DataBindings.Clear();
            ctbEn.DataBindings.Clear();
            ctbYukseklik.DataBindings.Clear();
            ctbCap.DataBindings.Clear();
            ctbEtKalinlik.DataBindings.Clear();
            checkBoxIsSatinalma.DataBindings.Clear();
            checkBoxIsPdf.DataBindings.Clear();
            checkBoxIsFromExcel.DataBindings.Clear();
            checkBoxIsStep.DataBindings.Clear();
            checkBoxIsDxf.DataBindings.Clear();
            clbStokTip.DataBindings.Clear();
            clbOlcuBirim.DataBindings.Clear();
            clbMalzemeStandart.DataBindings.Clear();
            clbStokGrup.DataBindings.Clear();
            clbMalzemeGrup.DataBindings.Clear();
            clbMalzemeAltGrup.DataBindings.Clear();
            clbMalzemeAltGrup2.DataBindings.Clear();
            ctbId.DataBindings.Add(nameof(ctbId.TextCustom), projeStokKart, nameof(projeStokKart.Id), true, DataSourceUpdateMode.OnPropertyChanged);
            clbProjeKod.DataBindings.Add(nameof(clbProjeKod.SelectedValue), projeStokKart.proje, $"{nameof(projeStokKart.proje.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbKod.DataBindings.Add(nameof(ctbKod.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.kod), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbStokAd.DataBindings.Add(nameof(ctbStokAd.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.ad), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbBoyut.DataBindings.Add(nameof(ctbBoyut.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.boyut), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbUzunluk.DataBindings.Add(nameof(ctbUzunluk.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.uzunluk), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAciklama.DataBindings.Add(nameof(ctbAciklama.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.aciklama), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAgirlik.DataBindings.Add(nameof(ctbAgirlik.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.agirlik), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbBoy.DataBindings.Add(nameof(ctbBoy.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.boy), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbEn.DataBindings.Add(nameof(ctbEn.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.en), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbYukseklik.DataBindings.Add(nameof(ctbYukseklik.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.yukseklik), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbCap.DataBindings.Add(nameof(ctbCap.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.cap), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbEtKalinlik.DataBindings.Add(nameof(ctbEtKalinlik.TextCustom), projeStokKart.stokKart, nameof(projeStokKart.stokKart.etKalinligi), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsSatinalma.DataBindings.Add(nameof(checkBoxIsSatinalma.Checked), projeStokKart.stokKart, nameof(projeStokKart.stokKart.isSatinalma), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsPdf.DataBindings.Add(nameof(checkBoxIsPdf.Checked), projeStokKart.stokKart, nameof(projeStokKart.stokKart.isPdf), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsFromExcel.DataBindings.Add(nameof(checkBoxIsFromExcel.Checked), projeStokKart.stokKart, nameof(projeStokKart.stokKart.isFromExcel), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsStep.DataBindings.Add(nameof(checkBoxIsStep.Checked), projeStokKart.stokKart, nameof(projeStokKart.stokKart.isStep), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsDxf.DataBindings.Add(nameof(checkBoxIsDxf.Checked), projeStokKart.stokKart, nameof(projeStokKart.stokKart.isDxf), true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokTip.DataBindings.Add(nameof(clbStokTip.SelectedValue), projeStokKart.stokKart.stokTip, $"{nameof(projeStokKart.stokKart.stokTip.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbOlcuBirim.DataBindings.Add(nameof(clbOlcuBirim.SelectedValue), projeStokKart.stokKart.olcuBirim, $"{nameof(projeStokKart.stokKart.olcuBirim.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeStandart.DataBindings.Add(nameof(clbMalzemeStandart.SelectedValue), projeStokKart.stokKart.malzemeStandart, $"{nameof(projeStokKart.stokKart.malzemeStandart.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup2.DataBindings.Add(nameof(clbMalzemeAltGrup2.SelectedValue), projeStokKart.stokKart.malzemeAltGrup2, $"{nameof(projeStokKart.stokKart.malzemeAltGrup2.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup.DataBindings.Add(nameof(clbMalzemeAltGrup.SelectedValue), projeStokKart.stokKart.malzemeAltGrup, $"{nameof(projeStokKart.stokKart.malzemeAltGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeGrup.DataBindings.Add(nameof(clbMalzemeGrup.SelectedValue), projeStokKart.stokKart.malzemeGrup, $"{nameof(projeStokKart.stokKart.malzemeGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokGrup.DataBindings.Add(nameof(clbStokGrup.SelectedValue), projeStokKart.stokKart.stokGrup, $"{nameof(projeStokKart.stokKart.stokGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            List<DataControlStokKartDosya> dataControlStokKartDosyaList = new List<DataControlStokKartDosya>();
            for (int i = 0; i < projeStokKart.stokKart.dosyaList.Count; i++)
            {
                DataControlStokKartDosya dataControlStokKartDosya = DIContainer.GetService<DataControlStokKartDosya>();
                //dataControlStokKartDosya.newRec = false;
                //dataControlStokKartDosya.dosyaAdControl.TextCustom= projeStokKart.stokKart.dosyaList[i].dosyaAd;
                //dataControlStokKartDosya.IdControl.TextCustom = projeStokKart.stokKart.dosyaList[i].Id.ToString();
                //dataControlStokKartDosya.dosyaTipControl.SelectedValue = projeStokKart.stokKart.dosyaList[i].dosyaTip?.Id;
                //dataControlStokKartDosya.dosyaUzantiControl.TextCustom = projeStokKart.stokKart.dosyaList[i].dosyaUzanti;
                //dataControlStokKartDosya.stokKartIdControl.TextCustom = projeStokKart.stokKart.dosyaList[i].stokKartId.ToString();
                dataControlStokKartDosya.stokKartDosya = projeStokKart.stokKart.dosyaList[i];
                dataControlStokKartDosyaList.Add(dataControlStokKartDosya);
            }
            customDataGrid = new CustomDataGrid<DataControlStokKartDosya>(2, 30, new Point(5, 5), new Size(700, 250));

            panel1.Controls.Clear();
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
            customDataGrid.dataSource = dataControlStokKartDosyaList;
        }

        private void StokKartTanimlamaFormu_Load(object sender, EventArgs e)
        {

        }
        private void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == projeStokKart.stokKart.stokGrup.Id).ToList(), ref clbMalzemeGrup);
        }
        private void cbxMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == projeStokKart.stokKart.malzemeGrup.Id).ToList(), ref clbMalzemeAltGrup);
            if (_cache.malzemeAltGrups.Count(x => x.malzemeGrup.Id == projeStokKart.stokKart.malzemeGrup.Id) == 0)
            {
                clbMalzemeAltGrup.Enabled = false;
                clbMalzemeAltGrup2.Enabled = false;
            }
            else
            {
                clbMalzemeAltGrup.Enabled = true;
            }
        }
        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == projeStokKart.stokKart.malzemeAltGrup.Id).ToList(), ref clbMalzemeAltGrup2);
            if (_cache.malzemeAltGrup2List.Count(x => x.malzemeAltGrup.Id == projeStokKart.stokKart.malzemeAltGrup.Id) == 0)
            {
                clbMalzemeAltGrup2.Enabled = false;
            }
            else
            {
                clbMalzemeAltGrup2.Enabled = true;
            }
        }
    }
}