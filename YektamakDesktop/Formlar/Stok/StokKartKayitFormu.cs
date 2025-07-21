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
        
        private StokKart _stokKart;
        public StokKart stokKart
        {
            get
            {
                if (_stokKart == null) { _stokKart = new StokKart(); }
                return _stokKart;
            }
            set { 
                _stokKart = value;
                Binding();
            }
        }
        

        public StokKartKayitFormu(ICache cache, IDataTableMapper dataTableHelper, IJsonConverter jsonConvertHelper, IStokService stokService)
        {
            _cache = cache;
            _dataTableHelper = dataTableHelper;
            _jsonConverter = jsonConvertHelper;
            _stokService = stokService;
            InitializeComponent();
            stokKart=new StokKart();
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref clbStokTip);
            ComboBoxListFill.GetLookupAd(_cache.olcuBirims, ref clbOlcuBirim);
            ComboBoxListFill.GetLookupAd(_cache.malzemeStandarts, ref clbMalzemeStandart);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref clbProjeKod);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups, ref clbMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List, ref clbMalzemeAltGrup2);
        }
        
        public void UpdateMode(StokKart stokKartToUpdate)
        {
            stokKart = stokKartToUpdate;
            
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
            stokKart.dosyaList.Clear();
            foreach(var item in data.Where(s=>s.newRec==false))
            {
                stokKart.dosyaList.Add(item.stokKartDosya);
            }
            string jsonResult = await _stokService.SaveStokKart(stokKart);
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            if (result.result != null && result.result.Contains("error",StringComparison.OrdinalIgnoreCase)) 
            {
                MessageBox.Show("Stok kart kaydı sırasında bir hata oluştu: " + result.result);
            }
            else
            {
                StokKart savedStokKart = JsonConvert.DeserializeObject<List<StokKart>>(result.result).FirstOrDefault();
                stokKart = savedStokKart;
                MessageBox.Show("Stok Kartı Kayıt Edildi");
            }
        }
        private void Binding()
        {
            ctbId.DataBindings.Clear();
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
            ctbLogoKod.DataBindings.Clear();
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
            ctbId.DataBindings.Add(nameof(ctbId.TextCustom), stokKart, nameof(stokKart.Id), true, DataSourceUpdateMode.Never);
            ctbKod.DataBindings.Add(nameof(ctbKod.TextCustom), stokKart, nameof(stokKart.kod), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbStokAd.DataBindings.Add(nameof(ctbStokAd.TextCustom), stokKart, nameof(stokKart.ad), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbBoyut.DataBindings.Add(nameof(ctbBoyut.TextCustom), stokKart, nameof(stokKart.boyut), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbUzunluk.DataBindings.Add(nameof(ctbUzunluk.TextCustom), stokKart, nameof(stokKart.uzunluk), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAciklama.DataBindings.Add(nameof(ctbAciklama.TextCustom), stokKart, nameof(stokKart.aciklama), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAgirlik.DataBindings.Add(nameof(ctbAgirlik.TextCustom), stokKart, nameof(stokKart.agirlik), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbBoy.DataBindings.Add(nameof(ctbBoy.TextCustom), stokKart, nameof(stokKart.boy), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbEn.DataBindings.Add(nameof(ctbEn.TextCustom), stokKart, nameof(stokKart.en), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbYukseklik.DataBindings.Add(nameof(ctbYukseklik.TextCustom), stokKart, nameof(stokKart.yukseklik), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbCap.DataBindings.Add(nameof(ctbCap.TextCustom), stokKart, nameof(stokKart.cap), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbEtKalinlik.DataBindings.Add(nameof(ctbEtKalinlik.TextCustom), stokKart, nameof(stokKart.etKalinligi), true, DataSourceUpdateMode.OnPropertyChanged);
            ctbLogoKod.DataBindings.Add(nameof(ctbLogoKod.TextCustom), stokKart, nameof(stokKart.logoKod), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsSatinalma.DataBindings.Add(nameof(checkBoxIsSatinalma.Checked), stokKart, nameof(stokKart.isSatinalma), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsPdf.DataBindings.Add(nameof(checkBoxIsPdf.Checked), stokKart, nameof(stokKart.isPdf), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsFromExcel.DataBindings.Add(nameof(checkBoxIsFromExcel.Checked), stokKart, nameof(stokKart.isFromExcel), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsStep.DataBindings.Add(nameof(checkBoxIsStep.Checked), stokKart, nameof(stokKart.isStep), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsDxf.DataBindings.Add(nameof(checkBoxIsDxf.Checked), stokKart, nameof(stokKart.isDxf), true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokTip.DataBindings.Add(nameof(clbStokTip.selectedDataRowId),   stokKart.stokTip, $"{nameof(stokKart.stokTip.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbOlcuBirim.DataBindings.Add(nameof(clbOlcuBirim.selectedDataRowId), stokKart, $"{nameof(stokKart.olcuBirim)}.{nameof(stokKart.olcuBirim.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeStandart.DataBindings.Add(nameof(clbMalzemeStandart.selectedDataRowId), stokKart, $"{nameof(stokKart.malzemeStandart)}.{nameof(stokKart.malzemeStandart.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup2.DataBindings.Add(nameof(clbMalzemeAltGrup2.selectedDataRowId), stokKart.malzemeAltGrup2, $"{nameof(stokKart.malzemeAltGrup2.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup.DataBindings.Add(nameof(clbMalzemeAltGrup.selectedDataRowId), stokKart.malzemeAltGrup, $"{nameof(stokKart.malzemeAltGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeGrup.DataBindings.Add(nameof(clbMalzemeGrup.selectedDataRowId), stokKart.malzemeGrup, $"{nameof(stokKart.malzemeGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokGrup.DataBindings.Add(nameof(clbStokGrup.selectedDataRowId), stokKart, $"{nameof(stokKart.stokGrup)}.{nameof(stokKart.stokGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            List<DataControlStokKartDosya> dataControlStokKartDosyaList = new List<DataControlStokKartDosya>();
            for (int i = 0; i < stokKart.dosyaList.Count; i++)
            {
                DataControlStokKartDosya dataControlStokKartDosya = new DataControlStokKartDosya(stokKart.dosyaList[i]);
                dataControlStokKartDosya.newRec = false;
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
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == clbStokGrup.selectedDataRowId).ToList(), ref clbMalzemeGrup);
            clbMalzemeGrup.SelectDataRowId(null);
            clbMalzemeAltGrup.SelectDataRowId(null);
            clbMalzemeAltGrup2.SelectDataRowId(null);
            clbMalzemeGrup.DataBindings.Clear();
            clbMalzemeAltGrup.DataBindings.Clear();
            clbMalzemeAltGrup2.DataBindings.Clear();
            clbMalzemeAltGrup2.DataBindings.Add(nameof(clbMalzemeAltGrup2.selectedDataRowId), stokKart.malzemeAltGrup2, $"{nameof(stokKart.malzemeAltGrup2.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup.DataBindings.Add(nameof(clbMalzemeAltGrup.selectedDataRowId), stokKart.malzemeAltGrup, $"{nameof(stokKart.malzemeAltGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeGrup.DataBindings.Add(nameof(clbMalzemeGrup.selectedDataRowId), stokKart.malzemeGrup, $"{nameof(stokKart.malzemeGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void cbxMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == clbMalzemeGrup.selectedDataRowId).ToList(), ref clbMalzemeAltGrup);
            clbMalzemeAltGrup2.SelectDataRowId(null);
            clbMalzemeAltGrup.SelectDataRowId(null);
            clbMalzemeAltGrup.DataBindings.Clear();
            clbMalzemeAltGrup2.DataBindings.Clear();
            clbMalzemeAltGrup2.DataBindings.Add(nameof(clbMalzemeAltGrup2.selectedDataRowId), stokKart.malzemeAltGrup2, $"{nameof(stokKart.malzemeAltGrup2.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeAltGrup.DataBindings.Add(nameof(clbMalzemeAltGrup.selectedDataRowId), stokKart.malzemeAltGrup, $"{nameof(stokKart.malzemeAltGrup.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            if (_cache.malzemeAltGrups.Count(x => x.malzemeGrup.Id == clbMalzemeGrup.selectedDataRowId) == 0)
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
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == clbMalzemeAltGrup.selectedDataRowId).ToList(), ref clbMalzemeAltGrup2);
            clbMalzemeAltGrup2.SelectDataRowId(null);
            clbMalzemeAltGrup2.DataBindings.Clear();
            clbMalzemeAltGrup2.DataBindings.Add(nameof(clbMalzemeAltGrup2.selectedDataRowId), stokKart.malzemeAltGrup2, $"{nameof(stokKart.malzemeAltGrup2.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            if (_cache.malzemeAltGrup2List.Count(x => x.malzemeAltGrup.Id == clbMalzemeAltGrup.selectedDataRowId) == 0)
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