using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class CekKayitFormu : Form, IForm
    {
        #region declerations
        private static CekKayitFormu _cekKayitFormu;
        public static CekKayitFormu cekKayitFormu
        {
            get
            {
                if (_cekKayitFormu == null)
                {
                    _cekKayitFormu = new CekKayitFormu();
                    GlobalData.Yetki(ref _cekKayitFormu);
                }
                return _cekKayitFormu;
            }

        }
        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private int _cekId;
        public int cekId { get => _cekId; set => _cekId = value; }
        private Cek _cekToSave;
        public Cek cekToSave
        {
            get
            {
                if (_cekToSave == null)
                {
                    _cekToSave = new Cek();
                }
                return _cekToSave;
            }
            set { _cekToSave = value; }
        }
        private Cek _cekToUpdate;
        public Cek cekToUpdate
        {
            get
            {
                if (_cekToUpdate == null)
                {
                    _cekToUpdate = new Cek();
                }
                return _cekToUpdate;
            }
            set { _cekToUpdate = value; }

        }
        private bool cekOnYuzResim = false;
        private byte[] cekOnYuzResimBytes;
        private string cekOnYuzResimFormat;
        private bool cekArkaYuzResim = false;
        private byte[] cekArkaYuzResimBytes;
        private string cekArkaYuzResimFormat;
        #endregion declerations
        public CekKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
            //foreach (Firma firma in GlobalData.firmaUnvanList)
            //{
            //    comboListBoxCekiVerenFirma.AddDataRow(firma.id, firma.unvan);
            //    comboListBoxCekiAlanFirma.AddDataRow(firma.id, firma.unvan);
            //}
            //foreach (Firma banka in GlobalData.bankaList)
            //{
            //    comboListBoxCekSahibiBanka.AddDataRow(banka.id, banka.unvan);
            //}
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    comboListBoxCekDovizCinsi.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
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

        /// <summary>
        /// Form kapatma işlemlerini yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        /// <summary>
        /// Formu kapatır ve activeform listesinden çıkarır
        /// </summary>
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _cekKayitFormu);
        }
        /// <summary>
        /// Formu kaydetme moduna getirir
        /// </summary>
        public void SaveMode()
        {
            rButtonGuncelle.Visible = false;
        }
        public void UpdateMode(Cek cek)
        {
            cekToUpdate = cek;

            rButtonGuncelle.Visible = true;
            customTextBoxCekNumarasi.TextCustom = cek.cekNumarasi;
            customTextBoxTutar.TextCustom = cek.tutar.tutar.ToString();
            comboListBoxCekiVerenFirma.SelectDataRowId(cek.cekiVerenFirma.Id);
            comboListBoxCekiAlanFirma.SelectDataRowId(cek.cekiAlanFirma.Id);
            comboListBoxCekSahibiBanka.SelectDataRowId(cek.cekSahibiBanka.Id);
            comboListBoxCekDovizCinsi.SelectDataRowId(cek.tutar.dovizCinsi.id);
            customTextBoxVadeTarihi.TextCustom = cek.vadeTarihi.ToString("dd.MM.yyyy");
            customTextBoxCekinVerildigiTarih.TextCustom = cek.cekinVerildigiTarih.ToString("dd.MM.yyyy");
            cekArkaYuzResimBytes = cek.cekResim.arkaYuzResimData;
            cekArkaYuzResimFormat = cek.cekResim.arkaYuzImageFormat;
            cekOnYuzResimBytes= cek.cekResim.onYuzResimData;
            cekOnYuzResimFormat = cek.cekResim.onYuzImageFormat;
            GetCurrentCek();
            cekToUpdate = JsonConvert.DeserializeObject<Cek>(JsonConvert.SerializeObject(cekToSave));
        }
        /// <summary>
        /// Çeki ve resimlerini veritabanına kaydeder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }
            GetCurrentCek();
            string result = await WebMethods.SaveCek(cekToSave);

            if (result == "success")
            {
                MessageBox.Show("Çek başarıyla kaydedildi");
                CloseForm();
            }
            else
            {
                MessageBox.Show(result);
            }
        }
        /// <summary>
        /// Zorunlu alanlara veri girilip girilmediğini kontrol eder.
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            bool returnValue = true;
            foreach (Control control in this.Controls)
            {
                if (control.Name.Contains("labelUyari"))
                {
                    control.Text = "";
                }
            }
            if (string.IsNullOrWhiteSpace(customTextBoxCekNumarasi.TextCustom))
            {
                labelUyariCekNumarasi.Text = "* Çek numarası boş bırakılamaz";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxTutar.TextCustom))
            {
                labelUyariTutar.Text = "* Tutar alanı boş bırakılamaz";
                returnValue = false;
            }
            if (comboListBoxCekiVerenFirma.selectedDataRowId == -1)
            {
                labelUyariCekiVerenFirma.Text = "* Çeki veren firma seçilmelidir";
                returnValue = false;
            }
            if (comboListBoxCekiAlanFirma.selectedDataRowId == -1)
            {
                labelUyariCekiAlanFirma.Text = "* Çeki alan firma seçilmelidir";
                returnValue = false;
            }
            if (comboListBoxCekSahibiBanka.selectedDataRowId == -1)
            {
                labelUyariCekSahibiBanka.Text = "* Çek sahibi banka seçilmelidir";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxCekinVerildigiTarih.TextCustom))
            {
                labelUyariCekinVerildigiTarih.Text = "* Çekin verildiği tarih boş bırakılamaz";
                returnValue = false;
            }
            if (string.IsNullOrWhiteSpace(customTextBoxVadeTarihi.TextCustom))
            {
                labelUyariVadeTarihi.Text = "* Vade tarihi boş bırakılamaz";
                returnValue = false;
            }
            return returnValue;
        }
        /// <summary>
        /// Çekin ön yüz resmini dosya dizininden seçtirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCekOnYuzSec_Click(object sender, EventArgs e)
        {
            openFileDialogCekOnYuz.ShowDialog();
        }
        /// <summary>
        /// Seçil ön yüz resmini byte dizisine çevirir ve değişkene atar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialogCek_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Image loadedImage = Image.FromFile(openFileDialogCekOnYuz.FileName);
                if (loadedImage != null)
                {
                    buttonCekOnYuzGoster.Enabled = true;
                    cekOnYuzResim = true;
                    ImageFormat format = ImageWorks.GetImageFileFormatFromPath(openFileDialogCekOnYuz.FileName);
                    cekOnYuzResimBytes = ImageWorks.GetBytesFromImage(loadedImage, format);
                    cekOnYuzResimFormat = format.ToString();
                }
                else
                {
                    buttonCekOnYuzGoster.Enabled = false;
                    cekOnYuzResim = false;
                }
            }
            catch
            {
                cekOnYuzResim = false;
            }
        }
        /// <summary>
        /// Çekin arka yüz resmini dosya dizininden seçtirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCekArkaYuzSec_Click(object sender, EventArgs e)
        {
            openFileDialogCekArkaYuz.ShowDialog();
        }
        /// <summary>
        /// Seçilen arka yüz resmini byte dizisine çevirir ve değişkene atar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialogCekArkaYuz_FileOk(object sender, CancelEventArgs e)
        {
            Image loadedImage = Image.FromFile(openFileDialogCekArkaYuz.FileName);
            if (loadedImage != null)
            {
                buttonCekArkaYuzGoster.Enabled = true;
                cekArkaYuzResim = true;
                ImageFormat format = ImageWorks.GetImageFileFormatFromPath(openFileDialogCekArkaYuz.FileName);
                cekArkaYuzResimBytes = ImageWorks.GetBytesFromImage(loadedImage, format);
                cekArkaYuzResimFormat = format.ToString();
            }
            else
            {
                buttonCekArkaYuzGoster.Enabled = false;
                cekArkaYuzResim = false;
            }
        }
        /// <summary>
        /// Çekin ön yüz resmini formda gösterir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCekOnYuzGoster_Click(object sender, EventArgs e)
        {
            try
            {
                ResimGoruntule cekResimGoster = ResimGoruntule.cekResimGoster;
                if(cekResimGoster!=null)
                {
                    cekResimGoster._imageBytes = cekOnYuzResimBytes;
                    cekResimGoster._headerText = "Çek Ön Yüz";
                    cekResimGoster.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim görüntülenirken bir hata oluştu: " + ex.Message);
            }
        }
        /// <summary>
        /// Çekin arka yüz resmini formda gösterir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCekArkaYuzGoster_Click(object sender, EventArgs e)
        {
            try
            {
                ResimGoruntule cekResimGoster = ResimGoruntule.cekResimGoster;
                if (cekResimGoster != null)
                {
                    cekResimGoster._imageBytes = cekArkaYuzResimBytes;
                    cekResimGoster._headerText = "Çek Arka Yüz";
                    cekResimGoster.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim görüntülenirken bir hata oluştu: " + ex.Message);
            }
        }
        /// <summary>
        /// Form üzerindeki tanımlı verileri kullanarak cekToSave nesnesini doldurur.
        /// </summary>
        /// <returns></returns>
        private Cek GetCurrentCek()
        {

            cekToSave.cekId = cekToUpdate.cekId;
            cekToSave.cekResim.onYuzResimData = cekToUpdate.cekResim.onYuzResimData;
            cekToSave.cekResim.onYuzImageFormat= cekToUpdate.cekResim.onYuzImageFormat;
            cekToSave.cekResim.arkaYuzResimData = cekToUpdate.cekResim.arkaYuzResimData;
            cekToSave.cekResim.arkaYuzImageFormat=cekToSave.cekResim.arkaYuzImageFormat;
            cekToSave.cekNumarasi = customTextBoxCekNumarasi.TextCustom;
            cekToSave.cekSahibiBanka.Id = comboListBoxCekSahibiBanka.selectedDataRowId;
            cekToSave.cekinVerildigiTarih = DateTime.Parse(customTextBoxCekinVerildigiTarih.TextCustom);
            cekToSave.vadeTarihi = DateTime.Parse(customTextBoxVadeTarihi.TextCustom);
            cekToSave.tutar.tutar = float.Parse(customTextBoxTutar.TextCustom);
            cekToSave.tutar.dovizCinsi.id = comboListBoxCekDovizCinsi.selectedDataRowId;
            cekToSave.cekiAlanFirma.Id = comboListBoxCekiAlanFirma.selectedDataRowId;
            cekToSave.cekiVerenFirma.Id = comboListBoxCekiVerenFirma.selectedDataRowId;
           
                cekToSave.cekResim.onYuzResimData=cekOnYuzResimBytes;
                cekToSave.cekResim.onYuzImageFormat = cekOnYuzResimFormat;
            
           
                cekToSave.cekResim.arkaYuzResimData = cekArkaYuzResimBytes;
                cekToSave.cekResim.arkaYuzImageFormat=cekArkaYuzResimFormat;
            
            return cekToSave;
        }
        /// <summary>
        /// Formdaki verileri veritabanına kaydeder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }
            GetCurrentCek();
            string result = await WebMethods.SaveCek(cekToSave);
            if (result.Contains("error",StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(result);
            }
            else
            {
                CekKayitlariGridForm.cekKayitlariGridForm.UpdateRow(cekToSave);
                MessageBox.Show("Çek başarıyla kaydedildi");
            }
        }
        /// <summary>
        /// Çek numarası veritabanında 9 hane uzunluğunda olduğu için 9 haneden fazla yazılamaz kontrolünü yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customTextBoxCekNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (customTextBoxCekNumarasi.TextCustom.Length > 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
