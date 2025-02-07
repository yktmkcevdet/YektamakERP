using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class KrediKartiKayitFormu : Form, IForm
    {
        
        
        private static KrediKartiKayitFormu _krediKartiKayitFormu;
        public static KrediKartiKayitFormu krediKartiKayitFormu
        {
            get
            {
                if (_krediKartiKayitFormu == null)
                {
                    _krediKartiKayitFormu = new KrediKartiKayitFormu();
                    GlobalData.Yetki(ref _krediKartiKayitFormu);
                }
                return _krediKartiKayitFormu;
            }

        }
        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private KrediKarti _krediKartiToSave;
        public KrediKarti krediKartiToSave
        {
            get
            {
                if (_krediKartiToSave == null)
                {
                    _krediKartiToSave = new KrediKarti();
                }
                return _krediKartiToSave;
            }
            set
            {
                _krediKartiToSave = value;
            }

        }
        private KrediKarti _krediKartiToUpdate;
        public KrediKarti krediKartiToUpdate
        {
            get
            {
                return _krediKartiToUpdate;
            }
            set
            {
                _krediKartiToUpdate = value;
            }

        }
        public KrediKartiKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
            //foreach (Firma banka in GlobalData.bankaList)
            //{
            //    comboListBoxBanka.AddDataRow(banka.id, banka.unvan);
            //}
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    customComboListBoxDovizTuru.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
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

        private bool CheckFields()
        {
            foreach (Control control in krediKartiKayitFormu.Controls)
            {
                if (control.Name.Contains("labelUyari"))
                {
                    control.Text = string.Empty;
                }
            }
            bool returnValue = true;
            if (string.IsNullOrWhiteSpace(customTextBoxKartNumarasi.TextCustom))
            {
                labelUyariKartNumarasi.Text = "Kart Numarası Boş Olamaz";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxKartSahibi.TextCustom))
            {
                labelUyariKartSahibi.Text = "Kart Sahibi Boş Olamaz";
                returnValue = false;
            }
            if (comboListBoxBanka.selectedDataRowId == -1)
            {
                labelUyariBanka.Text = "Banka seçilmelidir.";
                returnValue = false;
            }
            if (customComboListBoxBagliHesap.selectedDataRowId == -1)
            {
                labelUyariBagliHesap.Text = "Bağlı hesap seçilmelidir.";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxHesapKesimTarihi.TextCustom))
            {
                labelUyariHesapKesimTarihi.Text = "Hesap Kesim Tarihi Boş Olamaz";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxSonOdemeTarihi.TextCustom))
            {
                labelUyariSonOdemeTarihi.Text = "Son Ödeme Tarihi Boş Olamaz";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxKartLimiti.TextCustom))
            {
                labelUyariKartLimiti.Text = "Kart Limiti Boş Olamaz";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxGuncelKartLimiti.TextCustom))
            {
                labelUyariGuncelKartLimiti.Text = "Güncel Kart Limiti Boş Olamaz";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxEkstreBorcu.TextCustom))
            {
                labelUyariEkstreBorcu.Text = "Ekstre Borcu Boş Olamaz";
                returnValue = false;
            }
            return returnValue;
        }
        public void SaveMode()
        {
            rButtonGuncelle.Visible = false;
            customComboListBoxDovizTuru.SelectDataRowId(1);
        }
        private void GetCurrentKrediKarti()
        {
            krediKartiToSave.krediKartiId = (krediKartiToUpdate != null) ? krediKartiToUpdate.krediKartiId : 0;
            krediKartiToSave.kartNumarasi = customTextBoxKartNumarasi.TextCustom;
            krediKartiToSave.kartSahibi = customTextBoxKartSahibi.TextCustom;
            krediKartiToSave.bagliHesap = new BankaHesabi();
            krediKartiToSave.bagliHesap.banka.id = comboListBoxBanka.selectedDataRowId;
            krediKartiToSave.bagliHesap.hesapId = customComboListBoxBagliHesap.selectedDataRowId;
            krediKartiToSave.dovizCinsi.id = customComboListBoxDovizTuru.selectedDataRowId;
            krediKartiToSave.hesapKesimTarihi = DateTime.Parse(customTextBoxHesapKesimTarihi.TextCustom);
            krediKartiToSave.sonOdemeTarihi = DateTime.Parse(customTextBoxSonOdemeTarihi.TextCustom);
            krediKartiToSave.kartLimiti = float.Parse(customTextBoxKartLimiti.TextCustom);
            krediKartiToSave.guncelKartLimiti = float.Parse(customTextBoxGuncelKartLimiti.TextCustom);
            krediKartiToSave.ekstreBorcu = float.Parse(customTextBoxEkstreBorcu.TextCustom);
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }
            GetCurrentKrediKarti();
            string result = await WebMethods.SaveKrediKarti(krediKartiToSave);
            if (result.Substring(0, 5) == "error")
            {
                MessageBox.Show(result, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Kayıt başarılı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CloseForm();
            }
        }
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _krediKartiKayitFormu = null;
            KrediKartlariGridForm krediKartlariGridForm = KrediKartlariGridForm.krediKartlariGridForm;
            if (GlobalData.activeFormStack.First().GetType() == krediKartlariGridForm.GetType())
            {
                krediKartlariGridForm.buttonFiltre_Click(null, null);
            }
        }
        public void UpdateMode(KrediKarti krediKarti)
        {
            krediKartiToUpdate = krediKarti;
            rButtonKaydet.Visible = false;
            customTextBoxKartNumarasi.TextCustom = krediKarti.kartNumarasi;
            customTextBoxKartSahibi.TextCustom = krediKarti.kartSahibi;
            customComboListBoxDovizTuru.SelectDataRowId(krediKarti.dovizCinsi.id);
            customTextBoxHesapKesimTarihi.TextCustom = krediKarti.hesapKesimTarihi.ToShortDateString();
            customTextBoxSonOdemeTarihi.TextCustom = krediKarti.sonOdemeTarihi.ToShortDateString();
            customTextBoxKartLimiti.TextCustom = float.Parse(krediKarti.kartLimiti.ToString()).ToString("#,##0.00");
            customTextBoxGuncelKartLimiti.TextCustom = float.Parse(krediKarti.guncelKartLimiti.ToString()).ToString("#,##0.00");
            customTextBoxEkstreBorcu.TextCustom = float.Parse(krediKarti.ekstreBorcu.ToString()).ToString("#,##0.00");
            //comboListBoxBanka.SelectDataRowId(GlobalData.bankaHesabiList.Where(x => x.hesapId == krediKarti.bagliHesap.hesapId).First().banka.id);
        }

        private void customTextBoxKartNumarasi_Key_Up(object sender, KeyEventArgs e)
        {
            string kartNumarasi = customTextBoxKartNumarasi.TextCustom;
            string first = "";
            string second = "";
            string third = "";
            string fourth;
            if (kartNumarasi.Length > 19)
            {
                e.Handled = true;
                kartNumarasi = kartNumarasi.Substring(0, 19);
                MessageBox.Show("Kredi kartı numarası 16 haneli olmalıdır");
            }
            kartNumarasi = kartNumarasi.Replace(" ", "");
            if (kartNumarasi.Length > 0)
            {
                int length = (kartNumarasi.Length > 4) ? 4 : kartNumarasi.Length;
                first = kartNumarasi.Substring(0, length);
                customTextBoxKartNumarasi.TextCustom = first;
            }
            if (kartNumarasi.Length > 4)
            {
                int length = (kartNumarasi.Length > 8) ? 8 : kartNumarasi.Length;
                second = kartNumarasi.Substring(4, length - 4);
                customTextBoxKartNumarasi.TextCustom = string.Concat(first, " ", second);
            }
            if (kartNumarasi.Length > 8)
            {
                int length = (kartNumarasi.Length > 12) ? 12 : kartNumarasi.Length;
                third = kartNumarasi.Substring(8, length - 8);
                customTextBoxKartNumarasi.TextCustom = string.Concat(first, " ", second, " ", third);
            }
            if (kartNumarasi.Length > 12)
            {
                fourth = kartNumarasi.Substring(12, kartNumarasi.Length - 12);
                customTextBoxKartNumarasi.TextCustom = string.Concat(first, " ", second, " ", third, " ", fourth);
            }
            customTextBoxKartNumarasi.SelectionStart = (customTextBoxKartNumarasi.TextCustom.Length % 4 == 0) ? customTextBoxKartNumarasi.TextCustom.Length + 1 : customTextBoxKartNumarasi.TextCustom.Length;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void comboListBoxBanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            customComboListBoxBagliHesap.ClearListBox();
            BankaHesabi bankaHesabi= new();
            bankaHesabi.firma.id = GlobalData.kendiFirmaId; // Yektamak'a ait banka hesapları
            string jsonString = WebMethods.GetFilteredBankaHesabi(bankaHesabi);
            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dsBankaHesabi= jsonConverter.JsonStringToDataSet(jsonString);
            foreach (DataRow drBankaHesabi in dsBankaHesabi.Tables[0].Select("BankaId=" + comboListBoxBanka.selectedDataRowId))
            {
                customComboListBoxBagliHesap.AddDataRow(int.Parse(drBankaHesabi["hesapId"].ToString()), drBankaHesabi["hesapAdi"].ToString());
            }
            if (krediKartiToUpdate != null)
            {
                customComboListBoxBagliHesap.SelectDataRowId(krediKartiToUpdate.bagliHesap.hesapId);
            }

        }

        private void customComboListBoxBagliHesap_SelectedIndexChanged(object sender, EventArgs e)
        {
            //customComboListBoxDovizTuru.SelectDataRowId(GlobalData.bankaHesabiList.Where(x => x.hesapId == customComboListBoxBagliHesap.selectedDataRowId).First().dovizCinsi.id);
        }
    }
}
