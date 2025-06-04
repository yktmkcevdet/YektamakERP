using ApiService;
using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using static YektamakDesktop.Formlar.Satis.SatisTeklifMaliyetKayitFormu;
using YektamakDesktop.CustomControls;
using System.Diagnostics;
using System.IO;
using YektamakDesktop.Formlar.Genel;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartKayitFormu : Form, IForm
    {
        private static IStokService _stokService;
        private static ICache _cache;
        private static IDataTableMapper _dataTableHelper;
        private static IJsonConverter _jsonConvertHelper;
        private static StokKartKayitFormu _stokKartKayitFormu;
        
        private StokKart _stokKart;
        public StokKart stokKart
        {
            get
            {
                if (_stokKart == null) _stokKart = new StokKart();
                return _stokKart;
            }
            set { _stokKart = value; }
        }
        public static StokKartKayitFormu stokKartKayitFormu
        {
            get
            {
                if (_stokKartKayitFormu == null)
                {
                    _stokKartKayitFormu = new StokKartKayitFormu();
                    GlobalData.Yetki(ref _stokKartKayitFormu);
                }
                return _stokKartKayitFormu;
            }
        }

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public StokKartKayitFormu(ICache cache, IDataTableMapper dataTableHelper, IJsonConverter jsonConvertHelper, IStokService stokService)
        {
            _cache = cache;
            _dataTableHelper = dataTableHelper;
            _jsonConvertHelper = jsonConvertHelper;
            _stokService = stokService;
        }
        public StokKartKayitFormu()
        {
            InitializeComponent();
            customDataGrid = new CustomDataGrid<DataControlStokKartDosyalar>(2, 30, new Point(5, 5), new Size(700, 250));
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref cbxStokTip);
            ComboBoxListFill.GetLookupAd(_cache.olcuBirims, ref comboListBoxOlcuBirim);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref cbxStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeStandarts, ref comboListBoxMalzemeStandart);
            ComboBoxListFill.GetLookupKod(_cache.projes, ref comboListBoxProjeKod);
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
        }
        #region mouseDrag
        bool mouseDown;
        private Point offset;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }
        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseDrag
        public void UpdateMode(StokKart stokKart)
        {
            _stokKart = JsonConvert.DeserializeObject<StokKart>(JsonConvert.SerializeObject(stokKart));
            LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!GlobalData.CompareClass(_stokKart, currentData))
            {
                DialogResult dialogResult = MessageBox.Show("Formda yapılan değişiklikler kaydedilsin mi", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rButtonKaydet_Click(sender, e);
                }
                else
                {
                    CloseForm();
                }
            }
            else
            {
                CloseForm();
            }
        }
        public void CloseForm()
        {
            GlobalData.CloseForm(ref _stokKartKayitFormu);
        }
        private bool CheckFields()
        {
            bool result = true;
            GlobalData.ClearWarningLabels(this);
            result = GlobalData.CheckField("*", this, ctxbStokAd) && result;
            result = GlobalData.CheckField("*", this, cbxStokTip) && result;
            result = GlobalData.CheckField("*", this, cbxStokGrup) && result;
            result = GlobalData.CheckField("*", this, cbxMalzemeGrup) && result;
            result = GlobalData.CheckField("*", this, cbxMalzemeAltGrup2) && result;
            result = GlobalData.CheckField("*", this, cbxMalzemeAltGrup) && result;
            return result;
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if(!CheckFields())
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
                return;
            }
            _stokKart = currentData;
            string result = await _stokService.SaveStokKart(_stokKart);
            byte[] msg = JsonConvert.DeserializeObject<byte[]>(result);
            string mesaj = Encoding.UTF8.GetString(msg);
            string formattedJson = JsonConvert.SerializeObject(
                                    JsonConvert.DeserializeObject(mesaj),
                                    Formatting.Indented
                                    );
            if (formattedJson.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(formattedJson);
            }
            else
            {
                _stokKart = _dataTableHelper.MapToEntity<StokKart>(_jsonConvertHelper.DeserializeToDataSet(result).Tables[0].Rows[0]);
                textBoxId.TextCustom = stokKart.Id.ToString();
                _stokKart = currentData;
                
                if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(StokKartGridForm))
                {
                    StokKartGridForm.stokKartGridForm.UpdateRow(stokKart);
                }
                MessageBox.Show(formattedJson.Substring(0,255));
            }
        }
        private void LoadData() 
        {
            textBoxId.TextCustom = stokKart.Id.ToString();
            textBoxkod.TextCustom = stokKart.parcaKod;
            textBoxBoyut.TextCustom = stokKart.boyut;
            ctxbStokAd.TextCustom = stokKart.ad;
            textBoxUzunluk.TextCustom = stokKart.uzunluk.ToString();
            textBoxAciklama.TextCustom = stokKart.aciklama;
            textBoxAgirlik.TextCustom = stokKart.agirlik.ToString();
            textBoxBoy.TextCustom=stokKart.boy.ToString();
            textBoxEn.TextCustom = stokKart.en.ToString();
            textBoxYukseklik.TextCustom = stokKart.yukseklik.ToString();
            textBoxCap.TextCustom = stokKart.cap.ToString();
            textBoxEtKalinlik.TextCustom = stokKart.etKalinligi.ToString();
            cbxStokTip.SelectDataRowId(stokKart.stokTip.Id);
            comboListBoxOlcuBirim.SelectDataRowId(stokKart.olcuBirim.Id);
            comboListBoxProjeKod.SelectDataRowId(stokKart.proje.Id);
            comboListBoxMalzemeStandart.SelectDataRowId(stokKart.malzemeStandart.Id);
            cbxStokGrup.SelectDataRowId(stokKart.stokGrup.Id);
            cbxMalzemeGrup.SelectDataRowId(stokKart.malzemeGrup.Id);
            cbxMalzemeAltGrup.SelectDataRowId(stokKart.malzemeAltGrup.Id ?? 0);
            cbxMalzemeAltGrup2.SelectDataRowId(stokKart.malzemeAltGrup2.Id ?? 0);
            List<DataControlStokKartDosyalar> dataControlStokKartDosyalars = new List<DataControlStokKartDosyalar>();
            foreach(var item in stokKart.stokKartDosya)
            {
                DataControlStokKartDosyalar dataControlStokKartDosyalar = new DataControlStokKartDosyalar();
                dataControlStokKartDosyalar.Id.TextCustom = item.Id.ToString();
                dataControlStokKartDosyalar.stokKartId.TextCustom = item.stokKartId.ToString();
                dataControlStokKartDosyalar.dosyaTip.SelectDataRowId(item.dosyaTip.Id);
                dataControlStokKartDosyalar.dosyaVeri = item.dosya;
                dataControlStokKartDosyalar.dosyaAd.TextCustom = item.dosyaAd;
                dataControlStokKartDosyalar.dosyaUzanti.TextCustom = item.dosyaUzanti;
                dataControlStokKartDosyalars.Add(dataControlStokKartDosyalar);
            }
            customDataGrid.dataSource = dataControlStokKartDosyalars;
            
            _stokKart = currentData;
        }
        private void StokKartTanimlamaFormu_Load(object sender, EventArgs e)
        {
            //LoadData();
            _stokKart = currentData;
        }
        private void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMalzemeGrup.SelectDataRowId(-1);
            cbxMalzemeAltGrup.SelectDataRowId(-1);
            cbxMalzemeAltGrup2.SelectDataRowId(-1);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == cbxStokGrup.selectedDataRowId).ToList(), ref cbxMalzemeGrup);
            stokKart.stokGrup = _cache.stokGrups.FirstOrDefault(x => x.Id == cbxStokGrup.selectedDataRowId);
            textBoxLogoKod.TextCustom = stokKart.hammaddeKod;
        }
        private void cbxMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMalzemeAltGrup.SelectDataRowId(-1);
            cbxMalzemeAltGrup2.SelectDataRowId(-1);
            if (_cache.malzemeAltGrups.Count(x => x.malzemeGrup.Id == cbxMalzemeGrup.selectedDataRowId) == 0)
            {
                cbxMalzemeAltGrup.Enabled = false;
                cbxMalzemeAltGrup2.Enabled = false;
                cbxMalzemeAltGrup2.SelectDataRowId(-1);
            }
            else
            {
                cbxMalzemeAltGrup.Enabled = true;
                cbxMalzemeAltGrup2.Enabled = true;
            }
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == cbxMalzemeGrup.selectedDataRowId).ToList(), ref cbxMalzemeAltGrup);
            stokKart.malzemeGrup = _cache.malzemeGrups.FirstOrDefault(x => x.Id == cbxMalzemeGrup.selectedDataRowId);
            textBoxLogoKod.TextCustom = stokKart.hammaddeKod;
        }
        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMalzemeAltGrup2.SelectDataRowId(-1);
            if (_cache.malzemeAltGrup2List.Count(x => x.malzemeAltGrup.Id == cbxMalzemeAltGrup.selectedDataRowId) == 0)
            {
                cbxMalzemeAltGrup2.Enabled = false;
                cbxMalzemeAltGrup2.SelectDataRowId(-1);
            }
            else
            {
                cbxMalzemeAltGrup2.Enabled = true;
            }
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == cbxMalzemeAltGrup.selectedDataRowId).ToList(), ref cbxMalzemeAltGrup2);
            stokKart.malzemeAltGrup = _cache.malzemeAltGrups.FirstOrDefault(x => x.Id == cbxMalzemeAltGrup.selectedDataRowId);
            textBoxLogoKod.TextCustom = stokKart.hammaddeKod;
        }

        private void cbxMalzemeAltGrup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKart.malzemeAltGrup2 = _cache.malzemeAltGrup2List.FirstOrDefault(x => x.Id == cbxMalzemeAltGrup2.selectedDataRowId);
            textBoxLogoKod.TextCustom = stokKart.hammaddeKod;
        }

        private StokKart currentData
        {
            get
            {
                StokKart stokKart = new StokKart();

                stokKart.Id = int.TryParse(textBoxId.TextCustom, out int id)?id:null;
                stokKart.parcaKod = textBoxkod.TextCustom;
                stokKart.boyut=textBoxBoyut.TextCustom;
                stokKart.ad = ctxbStokAd.TextCustom;
                stokKart.uzunluk = Convert.ToInt32(textBoxUzunluk.TextCustom.Replace(".", ""));
                stokKart.aciklama = textBoxAciklama.TextCustom;
                stokKart.agirlik = Double.TryParse(textBoxAgirlik.TextCustom, out Double agrlk)?agrlk:0;
                stokKart.stokTip.Id = cbxStokTip.selectedDataRowId;
                stokKart.olcuBirim.Id = comboListBoxOlcuBirim.selectedDataRowId;
                stokKart.stokGrup = _cache.stokGrups.FirstOrDefault(x => x.Id == cbxStokGrup.selectedDataRowId);
                stokKart.malzemeGrup = _cache.malzemeGrups.FirstOrDefault(x => x.Id == cbxMalzemeGrup.selectedDataRowId);
                stokKart.malzemeAltGrup = _cache.malzemeAltGrups.FirstOrDefault(x => x.Id == cbxMalzemeAltGrup.selectedDataRowId);
                stokKart.malzemeAltGrup2 = _cache.malzemeAltGrup2List.FirstOrDefault(x => x.Id == cbxMalzemeAltGrup2.selectedDataRowId);
                stokKart.malzemeStandart.Id = comboListBoxMalzemeStandart.selectedDataRowId;
                stokKart.proje.Id = comboListBoxProjeKod.selectedDataRowId;
                stokKart.etKalinligi = Convert.ToDouble(textBoxEtKalinlik.TextCustom.Replace(".", ""));
                stokKart.en = Convert.ToDouble(textBoxEn.TextCustom.Replace(".", ""));
                stokKart.boy = Convert.ToDouble(textBoxBoy.TextCustom.Replace(".", ""));
                stokKart.cap = Convert.ToDouble(textBoxCap.TextCustom.Replace(".", ""));
                stokKart.logoKod = textBoxLogoKod.TextCustom;
                stokKart.yukseklik = Convert.ToDouble(textBoxYukseklik.TextCustom.Replace(".", ""));
                foreach (var row in customDataGrid.dataSource.Where(x=>x.newRec==false).ToList())
                {
                    StokKartDosya stokKartDosya = new StokKartDosya();
                    stokKartDosya.Id = Int32.TryParse(row.Id.TextCustom, out int dosyaId) ? dosyaId : 0;
                    stokKartDosya.stokKartId = Int32.TryParse(row.stokKartId.TextCustom, out int stokKartId) ? stokKartId : 0;
                    stokKartDosya.dosyaTip.Id = row.dosyaTip.selectedDataRowId;
                    stokKartDosya.dosya = row.dosyaVeri;
                    stokKartDosya.dosyaAd = row.dosyaAd.TextCustom;
                    stokKartDosya.dosyaUzanti = row.dosyaUzanti.TextCustom;
                    stokKart.stokKartDosya.Add(stokKartDosya);
                }
                return stokKart;
            }
        }
       
    }
}