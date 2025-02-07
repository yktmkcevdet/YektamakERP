using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartTanimlamaFormu : Form, IForm
    {
        private static ICache _cache;
        private static StokKartTanimlamaFormu _stokKartTanimlamaFormu;
        public static StokKartTanimlamaFormu stokKartTanimlamaFormu(StokKart stokKart)
        {
            if (_stokKartTanimlamaFormu == null)
            {
                _stokKartTanimlamaFormu = new StokKartTanimlamaFormu(stokKart,_cache);
                GlobalData.Yetki(ref _stokKartTanimlamaFormu);
            }
            return _stokKartTanimlamaFormu;
           
           
        }

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private StokKart _stokKart;
        public StokKartTanimlamaFormu(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
        }

        public StokKartTanimlamaFormu(StokKart stokKart,ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            _stokKart = stokKart;
            textBoxId.TextCustom = stokKart.Id.ToString();
            textBoxkod.TextCustom = stokKart.kod;
            textBoxStokAd.TextCustom = stokKart.ad;
            textBoxBoyut.TextCustom = stokKart.boyut;
            textBoxUzunluk.TextCustom = stokKart.uzunluk.ToString();
            textBoxAciklama.TextCustom = stokKart.aciklama;
            textBoxAgirlik.TextCustom = stokKart.agirlik.ToString();
            textBoxMalzeme.TextCustom = stokKart.malzeme;
            textBoxParcaAd.TextCustom = stokKart.parcaAdi;
            ComboBoxListFill.GetLookupAd(_cache.stokTip, ref comboListBoxStokTip);
            comboListBoxStokTip.SelectDataRowId(stokKart.stokTip.Id);
            ComboBoxListFill.GetLookupAd(_cache.profilTip, ref comboListBoxProfilTip);
            comboListBoxProfilTip.SelectDataRowId(stokKart.profilTipId);
            ComboBoxListFill.GetLookupAd(_cache.olcuBirim, ref comboListBoxOlcuBirim);
            comboListBoxOlcuBirim.SelectDataRowId(stokKart.olcuBirim.Id);
            ComboBoxListFill.GetLookupAd(_cache.parcaGrups, ref comboListBoxParcaGrup);
            comboListBoxParcaGrup.SelectDataRowId(stokKart.parcaGrup.Id);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrup, ref comboListBoxMalzemeGrup);
            comboListBoxMalzemeGrup.SelectDataRowId(stokKart.malzemeGrup.Id);
            ComboBoxListFill.GetLookupAd(_cache.malzemeStandart, ref comboListBoxMalzemeStandart);
            comboListBoxMalzemeStandart.SelectDataRowId(stokKart.malzemeStandart.Id);
            ComboBoxListFill.GetLookupKod(_cache.proje.Where(x=>x.personel.Id== _cache.kullanici.personel.Id).ToList(), ref comboListBoxProjeKod);
            comboListBoxProjeKod.SelectDataRowId(stokKart.proje.Id);
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
            CloseForm();
        }
        public void CloseForm()
        {
            GlobalData.CloseForm(ref _stokKartTanimlamaFormu);
        }

    }
}
