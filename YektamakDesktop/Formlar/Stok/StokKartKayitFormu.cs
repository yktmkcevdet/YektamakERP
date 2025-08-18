using ApiService.Interfaces;
using Models;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            clbStokTip.SetDataSource(_cache.stokTips);
            clbOlcuBirim.SetDataSource(_cache.olcuBirims);
            clbMalzemeStandart.SetDataSource(_cache.malzemeStandarts);
            clbProjeKod.SetDataSource(_cache.projes.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList());
            clbStokGrup.SetDataSource(_cache.stokGrups);
            clbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            clbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            clbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List);
            fcbBoyut.SetDataSource(_cache.boyutList);
            Binding();
        }

        public void UpdateMode(ProjeStokKart stokKartToUpdate)
        {
            projeStokKart = stokKartToUpdate;
            
        }
        
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*", ctbStokAd) && result;
            result = GlobalData.CheckField("*", clbStokTip) && result;
            result = GlobalData.CheckField("*", clbStokGrup) && result;
            result = GlobalData.CheckField("*", clbMalzemeGrup) && result;
            result = GlobalData.CheckField("*", clbMalzemeAltGrup2) && result;
            result = GlobalData.CheckField("*", clbMalzemeAltGrup) && result;
            if (_cache.kullanici.Id != 1)
            {
                if (!_cache.projes.Any(p => p.personel.Id == _cache.kullanici.personel.Id && p.Id == projeStokKart.proje.Id))
                {
                    MessageBox.Show("Bu stok kartı için seçilen proje, kullanıcının projeleri arasında bulunmamaktadır. Lütfen geçerli bir proje seçiniz.");
                    result = false;
                }
            }
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
            foreach(var dataControlStokKartDosya in data.Where(s=>s.newRec==false))
            {
                if(!dataControlStokKartDosya.Validate())return;
                projeStokKart.stokKart.dosyaList.Add(dataControlStokKartDosya.stokKartDosya);
            }
            string jsonResult = await _projeService.SaveProjeStokKart(projeStokKart);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Stok kart kaydı sırasında bir hata oluştu: " + jsonResult);
            }
            else
            {
                ProjeStokKart savedProjeStokKart = JsonConvert.DeserializeObject<List<ProjeStokKart>>(jsonResult).FirstOrDefault();
                projeStokKart = savedProjeStokKart;
                MessageBox.Show("Stok Kartı Kayıt Edildi");
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId,projeStokKart,nameof(projeStokKart.Id));
            BindHelper.BindData(clbProjeKod, projeStokKart.proje, nameof(projeStokKart.proje.Id));
            BindHelper.BindData(ctbKod, projeStokKart.stokKart, nameof(projeStokKart.stokKart.kod));
            BindHelper.BindData(ctbStokAd, projeStokKart.stokKart, nameof(projeStokKart.stokKart.ad));
            BindHelper.BindData(ctbStokAd, projeStokKart.stokKart, nameof(projeStokKart.stokKart.ad));
            BindHelper.BindData(ctbBoyut, projeStokKart.stokKart, nameof(projeStokKart.stokKart.boyut));
            BindHelper.BindData(ctbUzunluk, projeStokKart.stokKart, nameof(projeStokKart.stokKart.uzunluk));
            BindHelper.BindData(ctbUzunluk, projeStokKart.stokKart, nameof(projeStokKart.stokKart.uzunluk));
            BindHelper.BindData(ctbAciklama, projeStokKart.stokKart, nameof(projeStokKart.stokKart.aciklama));
            BindHelper.BindData(ctbAgirlik, projeStokKart.stokKart, nameof(projeStokKart.stokKart.agirlik));
            BindHelper.BindData(ctbAgirlik, projeStokKart.stokKart, nameof(projeStokKart.stokKart.agirlik));
            BindHelper.BindData(ctbBoy, projeStokKart.stokKart, nameof(projeStokKart.stokKart.boy));
            BindHelper.BindData(ctbEn, projeStokKart.stokKart, nameof(projeStokKart.stokKart.en));
            BindHelper.BindData(ctbYukseklik, projeStokKart.stokKart, nameof(projeStokKart.stokKart.yukseklik));
            BindHelper.BindData(ctbCap, projeStokKart.stokKart, nameof(projeStokKart.stokKart.cap));
            BindHelper.BindData(ctbEtKalinlik, projeStokKart.stokKart, nameof(projeStokKart.stokKart.etKalinligi));
            BindHelper.BindData(checkBoxIsSatinalma, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isSatinalma));
            BindHelper.BindData(checkBoxIsPdf, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isPdf));
            BindHelper.BindData(checkBoxIsFromExcel, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isFromExcel));
            BindHelper.BindData(checkBoxIsStep, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isStep));
            BindHelper.BindData(checkBoxIsDxf, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isDxf));
            BindHelper.BindData(clbStokTip, projeStokKart.stokKart.stokTip, nameof(projeStokKart.stokKart.stokTip.Id));
            BindHelper.BindData(clbOlcuBirim, projeStokKart.stokKart.olcuBirim, nameof(projeStokKart.stokKart.olcuBirim.Id));
            BindHelper.BindData(clbOlcuBirim, projeStokKart.stokKart.olcuBirim, nameof(projeStokKart.stokKart.olcuBirim.Id));
            BindHelper.BindData(clbMalzemeStandart, projeStokKart.stokKart.malzemeStandart, nameof(projeStokKart.stokKart.malzemeStandart.Id));
            BindHelper.BindData(clbMalzemeAltGrup2, projeStokKart.stokKart.malzemeAltGrup2, nameof(projeStokKart.stokKart.malzemeAltGrup2.Id));
            BindHelper.BindData(clbMalzemeAltGrup, projeStokKart.stokKart.malzemeAltGrup, nameof(projeStokKart.stokKart.malzemeAltGrup.Id));
            BindHelper.BindData(clbMalzemeGrup, projeStokKart.stokKart.malzemeGrup, nameof(projeStokKart.stokKart.malzemeGrup.Id));
            BindHelper.BindData(clbStokGrup, projeStokKart.stokKart.stokGrup, nameof(projeStokKart.stokKart.stokGrup.Id));
            BindHelper.BindData(ctbProjeAdet, projeStokKart, nameof(projeStokKart.adet));
            BindHelper.BindData(fcbBoyut,projeStokKart.stokKart.boyutTanim,nameof(projeStokKart.stokKart.boyutTanim.Id));
            List<DataControlStokKartDosya> dataControlStokKartDosyaList = new List<DataControlStokKartDosya>();
            for (int i = 0; i < projeStokKart.stokKart.dosyaList.Count; i++)
            {
                DataControlStokKartDosya dataControlStokKartDosya = DIContainer.GetService<DataControlStokKartDosya>();
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