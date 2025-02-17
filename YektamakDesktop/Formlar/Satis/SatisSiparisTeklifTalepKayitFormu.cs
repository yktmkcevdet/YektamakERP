using ApiService;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisSiparisTeklifTalepKayitFormu : Form, IForm
    {
        private static SatisSiparisTeklifTalepKayitFormu _satisSiparisTeklifTalepKayitFormu;
        public static SatisSiparisTeklifTalepKayitFormu satisSiparisTeklifTalepKayitFormu
        {
            get
            {
                if (_satisSiparisTeklifTalepKayitFormu == null)
                {
                    _satisSiparisTeklifTalepKayitFormu = new SatisSiparisTeklifTalepKayitFormu();
                    GlobalData.Yetki(ref _satisSiparisTeklifTalepKayitFormu);
                }
                return _satisSiparisTeklifTalepKayitFormu;
            }
        }
        CustomDataGrid<DataControlTeklifTalepDosya> customDataGrid;
        private SatisSiparisTeklifTalep _satisSiparisTeklifTalepToSave;
        public SatisSiparisTeklifTalep satisSiparisTeklifTalepToSave { get => _satisSiparisTeklifTalepToSave; set => _satisSiparisTeklifTalepToSave = value; }
        public SatisSiparisTeklifTalep _satisSiparisTeklifTalepToUpdate;
        public SatisSiparisTeklifTalep satisSiparisTeklifTalepToUpdate { get => _satisSiparisTeklifTalepToUpdate; set => _satisSiparisTeklifTalepToUpdate = value; }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }

        private Models.Proje _selectedProjeKod;
        public Models.Proje selectedProjeKod { get { if (_selectedProjeKod == null) _selectedProjeKod = new Models.Proje(); return _selectedProjeKod; } set => _selectedProjeKod = value; }
        private Firma _musteriFirma;
        public Firma musteriFirma { get { if (_musteriFirma == null) _musteriFirma = new Firma(); return _musteriFirma; } set { _musteriFirma = value; } }
        private bool _activeForm;
        public bool activeForm
        {
            get => _activeForm;
            set
            {
                if (value)
                {

                }
                _activeForm = value;
            }
        }
        private int _teklifTalepId;
        private SatisSiparisTeklifTalepKayitFormu()
        {
            InitializeComponent();
            customDataGrid = new CustomDataGrid<DataControlTeklifTalepDosya>(2, 30, new Point(90, 447), new Size(700, 250));
            this.Controls.Add(customDataGrid.headerPanel);
            this.Controls.Add(customDataGrid.detailPanel);
            controlsToDisable = new List<Control>
            {

            };

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

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        #endregion mouseDrag
        private void CloseForm()
        {
            if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(SatisSiparisTeklifTalepGridForm))
            {
                if (satisSiparisTeklifTalepToUpdate != null && satisSiparisTeklifTalepToUpdate.Id != 0)
                {
                    SatisSiparisTeklifTalepGridForm.satisSiparisTeklifTalepGridForm.UpdateRow(satisSiparisTeklifTalepToUpdate);
                }
            }
            GlobalData.CloseForm(ref _satisSiparisTeklifTalepKayitFormu);
        }



        /// <summary>
        /// Formdaki alanlara doğru veri girilip girilmediğini kontrol eder. 
        /// </summary>
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*Talep tarihi girilmelidir!", this, textBoxTeklifTalepTarihi) && result;
            result = GlobalData.CheckField("*Müşteri seçilmelidir!", this, comboListBoxMusteri) && result;
            result = GlobalData.CheckField("*Teklif konusu yazılmalıdır!", this, textBoxTeklifKonusu) && result;
            result = GlobalData.CheckField("*Marka seçilmelidir!", this, comboListBoxMarka) && result;
            result = GlobalData.CheckField("*Alt grup seçilmelidir!", this, comboListBoxAltGrup) && result;
            result = GlobalData.CheckField("*Referans kaynağı seçimi yapılmalıdır!", this, comboListBoxReferansKaynagi) && result;
            result = GlobalData.CheckField("*Sqtış sorumlusu seçilmelidir!", this, comboListBoxSatisSorumlusu) && result;
            return result;
        }
        /// <summary>
        /// Form üzerinde zorunlu alanların girilip girilmediğini kontrol eder, veriler girilmişse SatisSiparisTeklifTalep nesnesi olarak hafızaya alır.
        /// </summary>
        /// <returns></returns>
        private SatisSiparisTeklifTalep GetCurrentSatisSiparisTeklifTalep()
        {
            SatisSiparisTeklifTalep satisSiparisTeklifTalep = new SatisSiparisTeklifTalep();
            satisSiparisTeklifTalep.Id = _teklifTalepId;

            return satisSiparisTeklifTalep;
        }
        /// <summary>
        /// satisSiparisTeklifTalepToSave nesnesinde kayıtlı olan verileri veritabanına kaydetmek için işlemleri başlatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                satisSiparisTeklifTalepToSave = GetCurrentSatisSiparisTeklifTalep();
                if (satisSiparisTeklifTalepToSave != null)
                {
                    this.Enabled = false;
                    string result = await WebMethods.SaveSatisSiparisTeklifTalep(satisSiparisTeklifTalepToSave);

                    if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarılı");
                    }
                    this.Enabled = true;
                }
            }
        }
        /// <summary>
        /// satisSiparisTeklifTalepToUpdate nesnesinin veritabanındaki karşılğını günceller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                satisSiparisTeklifTalepToUpdate = GetCurrentSatisSiparisTeklifTalep();
                if (satisSiparisTeklifTalepToUpdate != null)
                {
                    this.Enabled = false;
                    string result = await WebMethods.SaveSatisSiparisTeklifTalep(satisSiparisTeklifTalepToUpdate);

                    if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarılı");
                        CloseForm();
                    }
                    this.Enabled = true;
                }
            }
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void SatisSiparisTeklifTalepKayitFormu_Load(object sender, EventArgs e)
        {

        }

        private void labelHeader_Click(object sender, EventArgs e)
        {

        }
    }

}