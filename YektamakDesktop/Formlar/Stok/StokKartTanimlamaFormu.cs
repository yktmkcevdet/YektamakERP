using ApiService;
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

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartTanimlamaFormu : Form, IForm
    {
        private static ICache _cache;
        private static IDataTableHelper _dataTableHelper;
        private static IJsonConvertHelper _jsonConvertHelper;
        private static StokKartTanimlamaFormu _stokKartTanimlamaFormu;
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
        public static StokKartTanimlamaFormu stokKartTanimlamaFormu
        {
            get
            {
                if (_stokKartTanimlamaFormu == null)
                {
                    _stokKartTanimlamaFormu = new StokKartTanimlamaFormu();
                    GlobalData.Yetki(ref _stokKartTanimlamaFormu);
                }
                return _stokKartTanimlamaFormu;
            }
        }

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public StokKartTanimlamaFormu(ICache cache, IDataTableHelper dataTableHelper, IJsonConvertHelper jsonConvertHelper)
        {
            _cache = cache;
            _dataTableHelper = dataTableHelper;
            _jsonConvertHelper = jsonConvertHelper;
        }
        public StokKartTanimlamaFormu()
        {
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref comboListBoxStokTip);
            ComboBoxListFill.GetLookupAd(_cache.profilTips, ref comboListBoxProfilTip);
            ComboBoxListFill.GetLookupAd(_cache.olcuBirims, ref comboListBoxOlcuBirim);
            ComboBoxListFill.GetLookupAd(_cache.parcaGrups, ref comboListBoxParcaGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref comboListBoxMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeStandarts, ref comboListBoxMalzemeStandart);
            ComboBoxListFill.GetLookupKod(_cache.projes.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList(), ref comboListBoxProjeKod);
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
            GlobalData.CloseForm(ref _stokKartTanimlamaFormu);
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            _stokKart = currentData;
            string result = await WebMethods.SaveStokKart(_stokKart);
            if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(result);
            }
            else
            {
                _stokKart=_dataTableHelper.DataRowToModel<StokKart>(_jsonConvertHelper.JsonStringToDataSet(result).Tables[0].Rows[0]);
                textBoxId.TextCustom=stokKart.Id.ToString();
                _stokKart = currentData;
                byte[] msg= JsonConvert.DeserializeObject<byte[]>(result);
                string mesaj = Encoding.UTF8.GetString(msg);
                string formattedJson = JsonConvert.SerializeObject(
                                        JsonConvert.DeserializeObject(mesaj),
                                        Formatting.Indented
                                        );
                MessageBox.Show(formattedJson);
            }
        }

        private void StokKartTanimlamaFormu_Load(object sender, EventArgs e)
        {
            textBoxId.TextCustom = stokKart.Id.ToString();
            textBoxkod.TextCustom = stokKart.kod;
            textBoxStokAd.TextCustom = stokKart.ad;
            textBoxBoyut.TextCustom = stokKart.boyut;
            textBoxUzunluk.TextCustom = stokKart.uzunluk.ToString();
            textBoxAciklama.TextCustom = stokKart.aciklama;
            textBoxAgirlik.TextCustom = stokKart.agirlik.ToString();
            textBoxMalzeme.TextCustom = stokKart.malzeme;
            textBoxParcaAd.TextCustom = stokKart.parcaAdi;
            comboListBoxStokTip.SelectDataRowId(stokKart.stokTip.Id);
            comboListBoxProfilTip.SelectDataRowId(stokKart.profilTipId);
            comboListBoxOlcuBirim.SelectDataRowId(stokKart.olcuBirim.Id);
            comboListBoxParcaGrup.SelectDataRowId(stokKart.parcaGrup.Id);
            comboListBoxMalzemeGrup.SelectDataRowId(stokKart.malzemeGrup.Id);
            comboListBoxMalzemeStandart.SelectDataRowId(stokKart.malzemeStandart.Id);
            comboListBoxProjeKod.SelectDataRowId(stokKart.proje.Id);
            _stokKart = currentData;
        }

        private StokKart currentData
        {
            get
            {
                StokKart stokKart = new StokKart();

                stokKart.Id = Convert.ToInt32(textBoxId.TextCustom);
                stokKart.kod = textBoxkod.TextCustom;
                stokKart.ad = textBoxStokAd.TextCustom;
                stokKart.boyut = textBoxBoyut.TextCustom;
                stokKart.uzunluk = Convert.ToInt32(textBoxUzunluk.TextCustom.Replace(".",""));
                stokKart.aciklama = textBoxAciklama.TextCustom;
                stokKart.agirlik = Convert.ToDouble(textBoxAgirlik.TextCustom);
                stokKart.malzeme = textBoxMalzeme.TextCustom;
                stokKart.parcaAdi = textBoxParcaAd.TextCustom;
                stokKart.stokTip.Id = comboListBoxStokTip.selectedDataRowId;
                stokKart.profilTipId = comboListBoxProfilTip.selectedDataRowId;
                stokKart.olcuBirim.Id = comboListBoxOlcuBirim.selectedDataRowId;
                stokKart.parcaGrup.Id = comboListBoxParcaGrup.selectedDataRowId;
                stokKart.malzemeGrup.Id = comboListBoxMalzemeGrup.selectedDataRowId;
                stokKart.malzemeStandart.Id = comboListBoxMalzemeStandart.selectedDataRowId;
                stokKart.proje.Id = comboListBoxProjeKod.selectedDataRowId;
                stokKart.etKalinligi = Convert.ToDouble(textBoxEtKalinlik.TextCustom.Replace(".", ""));
                stokKart.en= Convert.ToDouble(textBoxEn.TextCustom.Replace(".", ""));
                stokKart.boy= Convert.ToDouble(textBoxBoy.TextCustom.Replace(".", ""));
                stokKart.cap= Convert.ToDouble(textBoxCap.TextCustom.Replace(".", ""));
                stokKart.logoKod= textBoxLogoKod.TextCustom;
                stokKart.yukseklik= Convert.ToDouble(textBoxYukseklik.TextCustom.Replace(".", ""));
                return stokKart;
            }
        }
    }
}