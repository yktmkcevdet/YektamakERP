using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Finans;
using YektamakDesktop.Formlar.Satinalma.DataControl;
using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaFaturaKayitFormu : Form, IForm
    {
        public CustomDataGrid<DataControlSatinalmaFaturaDetay> customDataGrid;
        private static SatinalmaFaturaKayitFormu _satinalmaFaturaKayitFormu;
        public static SatinalmaFaturaKayitFormu satinalmaFaturaKayitFormu
        {
            get
            {
                if (_satinalmaFaturaKayitFormu == null)
                {
                    _satinalmaFaturaKayitFormu = new SatinalmaFaturaKayitFormu();
                    GlobalData.Yetki(ref _satinalmaFaturaKayitFormu);
                }
                return _satinalmaFaturaKayitFormu;
            }
        }

        private SatinalmaFatura _satinalmaFaturaToSave;
        public SatinalmaFatura satinalmaFaturaToSave
        {
            get
            {
                if (_satinalmaFaturaToSave == null)
                {
                    _satinalmaFaturaToSave = new SatinalmaFatura();
                }
                return _satinalmaFaturaToSave;
            }
            set { _satinalmaFaturaToSave = value; }
        }
        private SatinalmaFatura _satinalmaFaturaToUpdate;
        public SatinalmaFatura satinalmaFaturaToUpdate
        {
            get
            {
                if (_satinalmaFaturaToUpdate == null)
                {
                    _satinalmaFaturaToUpdate = new SatinalmaFatura();
                }
                return _satinalmaFaturaToUpdate;
            }
            set { _satinalmaFaturaToUpdate = value; }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }


        public SatinalmaFaturaKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
            foreach (Control control in panelSatinalmaFaturaMain.Controls)
            {
                if (control.Name != "panelHeader")
                {
                    controlsToDisable.Add(control);
                }
            }
            customDataGrid = new CustomDataGrid<DataControlSatinalmaFaturaDetay>(2, 34, new Point(31, 530), new Size(892, 200));
            panelSatinalmaFaturaMain.Controls.Add(customDataGrid.headerPanel);
            panelSatinalmaFaturaMain.Controls.Add(customDataGrid.detailPanel);
            //GlobalData.ComboCariKart(comboListBoxCariKartId);
            //GlobalData.ComboKdv(comboListBoxkdv);
            //comboListBoxkdv.SelectDataRowId(5);
            //GlobalData.ComboDovizCinsi(comboListBoxTutarDovizCinsi);
            //comboListBoxTutarDovizCinsi.SelectDataRowId(3);
            //GlobalData.ComboGiderTuru(customComboListBoxGiderTurId);
            //GlobalData.ComboTevkifat(comboListBoxTevkifat);
            //comboListBoxTevkifat.SelectDataRowId(1);
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
        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        /// <summary>
        /// Resim seçmek için filedialog nesnesini açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResimSec_Click(object sender, EventArgs e)
        {
            openFileDialogResim.ShowDialog();
        }
        /// <summary>
        /// filedialog nesnesinden resim dosyası seçilirse _yeniResim değerini true yapar, seçim yapılmazsa false yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialogResim_FileOk(object sender, CancelEventArgs e)
        {
            Image loadedImage = Image.FromFile(openFileDialogResim.FileName);
            if (loadedImage != null)
            {
                buttonResimGoster.Enabled = true;
                ImageFormat format = ImageWorks.GetImageFileFormatFromPath(openFileDialogResim.FileName);
                satinalmaFaturaToSave.faturaResim.resimData = ImageWorks.GetBytesFromImage(loadedImage, format);
                satinalmaFaturaToSave.faturaResim.imageFormat = format.ToString();
            }
            else
            {
                buttonResimGoster.Enabled = false;
            }
        }

        /// <summary>
        /// Form savemode'da açılırsa satinalmaSiparisList nesnesini doldurur. satinalmaSiparisList formda dinamik olarak oluşturulacak combolist'leri doldurmak için kullanılacak.
        /// </summary>
        public void SaveMode()
        {
            rButtonGuncelle.Visible = false;
        }
        /// <summary>
        /// SatinalmaFatura formu güncelleştirmek için açılırsa formdaki alanlar doldurulur.
        /// </summary>
        /// <param name="satinalmaFatura"></param>
        public void UpdateMode(SatinalmaFatura satinalmaFatura)
        {
            rButtonGuncelle.Visible = true;
            satinalmaFaturaToUpdate = satinalmaFatura;
            comboListBoxCariKartId.SelectDataRowId(satinalmaFatura.cariKart.cariKartId);
            textBoxFaturaNo.TextCustom = satinalmaFatura.faturaNo;
            textBoxFaturaTarihi.TextCustom = satinalmaFatura.faturaTarihi.ToShortDateString();
            textBoxFaturaTutari.TextCustom = satinalmaFatura.tutar.tutar.ToString("#,##0.00");
            comboListBoxTutarDovizCinsi.SelectDataRowId(satinalmaFatura.tutar.dovizCinsi.id);
            comboListBoxkdv.SelectDataRowId(satinalmaFatura.kdv.kdvId);
            customComboListBoxGiderTurId.SelectDataRowId(satinalmaFatura.giderTuru.giderTurId);
            comboListBoxTevkifat.SelectDataRowId(satinalmaFatura.tevkifat.tevkifatId);
            if (satinalmaFatura.faturaResim != null)
            {
                ImageFormat format = ImageWorks.GetImageFormatFromString(satinalmaFatura.faturaResim.imageFormat);
                buttonResimGoster.Enabled = true;
            }
        }
        /// <summary>
        /// Formu kapatır activeformstack listesinden siler ve SatinalmaFaturaGridForm'unun grid satırlarını günceller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaFaturaKayitFormu);
        }
        /// <summary>
        /// Form üzerindeki veriler veritabanına kaydedilmek üzere SatinalmaFatura nesnesine atanır. 
        /// </summary>
        /// <returns></returns>
        public void GetCurrentSatinalmaFatura()
        {
            satinalmaFaturaToSave.satinalmaFaturaId = satinalmaFaturaToUpdate.satinalmaFaturaId;
            satinalmaFaturaToSave.faturaNo = textBoxFaturaNo.TextCustom.ToString();
            satinalmaFaturaToSave.cariKart.cariKartId = comboListBoxCariKartId.selectedDataRowId;
            satinalmaFaturaToSave.faturaTarihi = DateTime.TryParse(textBoxFaturaTarihi.TextCustom.ToString(), out DateTime tarih) ? tarih : DateTime.MinValue;
            satinalmaFaturaToSave.tutar.tutar = float.TryParse(textBoxFaturaTutari.TextCustom.ToString(), out float tutar) ? tutar : 0;
            satinalmaFaturaToSave.tutar.dovizCinsi.id = comboListBoxTutarDovizCinsi.selectedDataRowId;
            satinalmaFaturaToSave.kdv.kdvId = comboListBoxkdv.selectedDataRowId;
            satinalmaFaturaToSave.giderTuru.giderTurId = customComboListBoxGiderTurId.selectedDataRowId;
            satinalmaFaturaToSave.tevkifat.tevkifatId = comboListBoxTevkifat.selectedDataRowId;
        }
        /// <summary>
        /// Formda zorunlu alanların doldurulup doldurulmadığını kontrol eder.
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            bool result = true;
            result = result & GlobalData.CheckField("*Firma seçilmelidir!", this, comboListBoxCariKartId);
            result = result & GlobalData.CheckField("*Fatura No alanı boş bırakılamaz!", this, textBoxFaturaNo);
            result = result & GlobalData.CheckField("*Tarih alanı boş bırakılamaz!", this, textBoxFaturaTarihi);
            result = result & GlobalData.CheckField("*Fatura tutarı girilmelidir!", this, textBoxFaturaTutari);
            result = result & GlobalData.CheckField("*Gider Türü seçilmelidir!", this, customComboListBoxGiderTurId);
            return result;
        }
        /// <summary>
        /// From üzerindeki verileri checkfields yapıldıktan sonra sorun yoksa veritabanına kaydeder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonKaydet_Click(object sender, EventArgs e)
        {

        }

        private void buttonResimGoster_Click(object sender, EventArgs e)
        {
            ResimGoruntule resimGoruntule = ResimGoruntule.cekResimGoster;
            if (resimGoruntule != null)
            {
                resimGoruntule._imageBytes = satinalmaFaturaToSave.faturaResim.resimData;
                resimGoruntule._headerText = "Satınalma Faturası";
                resimGoruntule.Show();
            }
        }

        private void comboListBoxCariKartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            CariKart cariKart = new();
            cariKart.cariKartId = comboListBoxCariKartId.selectedDataRowId;
            cariKart = GlobalData.GetModelFromDatabase(WebMethods.GetFilteredCariKartlar, cariKart);
            comboListBoxTutarDovizCinsi.SelectDataRowId(cariKart.guncelCari.dovizCinsi.id);
            SatinalmaSiparis satinalmaSiparis = new();
            DataControlSatinalmaFaturaDetay.firmaId = cariKart.cari.Id;
            DataControlSatinalmaFaturaDetay.dovizid = comboListBoxTutarDovizCinsi.selectedDataRowId;
            
            panelSatinalmaFaturaMain.Controls.Remove(customDataGrid.headerPanel);
            panelSatinalmaFaturaMain.Controls.Remove(customDataGrid.detailPanel);
            customDataGrid = null;
            customDataGrid = new CustomDataGrid<DataControlSatinalmaFaturaDetay>(2, 34, new Point(31, 530), new Size(892, 200));
            panelSatinalmaFaturaMain.Controls.Add(customDataGrid.headerPanel);
            panelSatinalmaFaturaMain.Controls.Add(customDataGrid.detailPanel);

        }

        private void SatinalmaFaturaKayitFormu_Load(object sender, EventArgs e)
        {
            
        }
    }

}
