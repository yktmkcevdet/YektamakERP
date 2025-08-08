using ApiService;
using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisTeklifTalepKayitFormu : Form, IForm
    {
        private static ICache _cache;
        private static ISatisService _satisService;
        public SatisTeklifTalepKayitFormu(ICache cache, ISatisService satinalmaService)
        {
            _cache = cache;
            _satisService = satinalmaService;
        }
        private static SatisTeklifTalepKayitFormu _satisTeklifTalepKayitFormu;
        public static SatisTeklifTalepKayitFormu satisTeklifTalepKayitFormu
        {
            get
            {
                if (_satisTeklifTalepKayitFormu == null)
                {
                    _satisTeklifTalepKayitFormu = new SatisTeklifTalepKayitFormu();
                    GlobalData.Yetki(ref _satisTeklifTalepKayitFormu);
                }
                return _satisTeklifTalepKayitFormu;
            }
        }
        CustomDataGrid<DataControlTeklifTalepDosya> customDataGrid;
        private SatisTeklifTalep _satisSiparisTeklifTalep;
        public SatisTeklifTalep satisSiparisTeklifTalep
        {
            get {
                if (_satisSiparisTeklifTalep == null) _satisSiparisTeklifTalep = new SatisTeklifTalep();
                return _satisSiparisTeklifTalep;
            }
            set => _satisSiparisTeklifTalep = value;
        }
        public SatisTeklifTalep _satisSiparisTeklifTalepToUpdate;
        public SatisTeklifTalep satisSiparisTeklifTalepToUpdate { get => _satisSiparisTeklifTalepToUpdate; set => _satisSiparisTeklifTalepToUpdate = value; }
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
        private int? _teklifTalepId;
        
        private SatisTeklifTalepKayitFormu()
        {
            InitializeComponent();
            customDataGrid = new CustomDataGrid<DataControlTeklifTalepDosya>(2, 30, new Point(5, 5), new Size(700, 250));
            panel2.Controls.Add(customDataGrid.headerPanel);
            panel2.Controls.Add(customDataGrid.detailPanel);
            ComboBoxListFill.GetLookupAd(_cache.firmaList,ref comboListBoxMusteri);
            ComboBoxListFill.GetLookupAd(_cache.markaList, ref comboListBoxMarka);
            ComboBoxListFill.GetLookupAd(_cache.markaAltGrupList, ref comboListBoxAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.referansKaynakList, ref comboListBoxReferansKaynagi);
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref comboListBoxSatisSorumlusu);
            comboListBoxSatisSorumlusu.SelectDataRowId(_cache.kullanici.personel.Id);
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
            GlobalData.CloseForm(ref _satisTeklifTalepKayitFormu);
        }



        /// <summary>
        /// Formdaki alanlara doğru veri girilip girilmediğini kontrol eder. 
        /// </summary>
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*Talep tarihi girilmelidir!", textBoxTeklifTalepTarihi) && result;
            result = GlobalData.CheckField("*Müşteri seçilmelidir!", comboListBoxMusteri) && result;
            result = GlobalData.CheckField("*Teklif konusu yazılmalıdır!", textBoxTeklifKonusu) && result;
            result = GlobalData.CheckField("*Marka seçilmelidir!", comboListBoxMarka) && result;
            result = GlobalData.CheckField("*Alt grup seçilmelidir!", comboListBoxAltGrup) && result;
            result = GlobalData.CheckField("*Referans kaynağı seçimi yapılmalıdır!", comboListBoxReferansKaynagi) && result;
            result = GlobalData.CheckField("*Satış sorumlusu seçilmelidir!", comboListBoxSatisSorumlusu) && result;
            return result;
        }
        /// <summary>
        /// Form üzerinde zorunlu alanların girilip girilmediğini kontrol eder, veriler girilmişse SatisSiparisTeklifTalep nesnesi olarak hafızaya alır.
        /// </summary>
        /// <returns></returns>
        private SatisTeklifTalep GetCurrentSatisSiparisTeklifTalep()
        {
            SatisTeklifTalep satisSiparisTeklifTalep = new SatisTeklifTalep();
            satisSiparisTeklifTalep.Id = _teklifTalepId;
            satisSiparisTeklifTalep.teklifTalepTarihi = Convert.ToDateTime(textBoxTeklifTalepTarihi.TextCustom);
            satisSiparisTeklifTalep.satisSorumlusu.Id = comboListBoxSatisSorumlusu.selectedDataRowId;
            satisSiparisTeklifTalep.musteri.Id = comboListBoxMusteri.selectedDataRowId;
            satisSiparisTeklifTalep.teklifKonusu = textBoxTeklifKonusu.TextCustom;
            satisSiparisTeklifTalep.marka.Id = comboListBoxMarka.selectedDataRowId;
            satisSiparisTeklifTalep.altGrup.Id = comboListBoxAltGrup.selectedDataRowId;
            satisSiparisTeklifTalep.referansKaynakId = comboListBoxReferansKaynagi.selectedDataRowId;
            foreach(DataControlTeklifTalepDosya item in customDataGrid.dataSource.Where(x=>x.newRec==false))
            {
                SatisSiparisTeklifTalepBelge belge = new SatisSiparisTeklifTalepBelge();
                belge.Id=Int32.TryParse(item.teklifTalepDosyaId.TextCustom,out int id)?id:0;
                belge.belgeAd = item.teklifTalepBelgeAd.TextCustom;
                belge.belgeAciklama = item.teklifTalepBelgeAd.TextCustom;
                belge.dosyaAd = item.teklifTalepDosyaAd.TextCustom;
                belge.dosyaVeri = item.dosyaVeri;
                belge.dosyaBoyut=Convert.ToDouble(item.boyut?.TextCustom);
                satisSiparisTeklifTalep.belgeList.Add(belge);
            }
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
                satisSiparisTeklifTalep = GetCurrentSatisSiparisTeklifTalep();
                if (satisSiparisTeklifTalep != null)
                {
                    this.Enabled = false;
                    string result = await _satisService.SaveSatisSiparisTeklifTalep(satisSiparisTeklifTalep);

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
                    string result = await _satisService.SaveSatisSiparisTeklifTalep(satisSiparisTeklifTalepToUpdate);

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
            textBoxTeklifTalepTarihi.TextCustom = satisSiparisTeklifTalep.teklifTalepTarihi;
            comboListBoxMusteri.SelectDataRowId(satisSiparisTeklifTalep.musteri.Id??-1);
            textBoxTeklifKonusu.TextCustom = satisSiparisTeklifTalep.teklifKonusu;
            comboListBoxMarka.SelectDataRowId(satisSiparisTeklifTalep.marka.Id);
            comboListBoxAltGrup.SelectDataRowId(satisSiparisTeklifTalep.altGrup.Id);
            comboListBoxReferansKaynagi.SelectDataRowId(satisSiparisTeklifTalep.referansKaynakId);
            comboListBoxSatisSorumlusu.SelectDataRowId(satisSiparisTeklifTalep.satisSorumlusu.Id??-1);
            List<DataControlTeklifTalepDosya> customDataGridList = new List<DataControlTeklifTalepDosya>();
            foreach (var item in satisSiparisTeklifTalep.belgeList)
            {
                DataControlTeklifTalepDosya dataControlTeklifTalepDosya=new DataControlTeklifTalepDosya();
                dataControlTeklifTalepDosya.teklifTalepDosyaId.TextCustom = item.Id.ToString();
                dataControlTeklifTalepDosya.teklifTalepBelgeAd.TextCustom = item.belgeAd;
                dataControlTeklifTalepDosya.teklifTalepDosyaAd.TextCustom = item.dosyaAd;
                dataControlTeklifTalepDosya.dosyaVeri = item.dosyaVeri;
                dataControlTeklifTalepDosya.teklifTalepDosyaId.TextCustom = item.Id.ToString();
                dataControlTeklifTalepDosya.teklifTalepId.TextCustom = item.teklifTalepId.ToString();
                dataControlTeklifTalepDosya.boyut.TextCustom = item.dosyaBoyut.ToString();
                customDataGridList.Add(dataControlTeklifTalepDosya);
            }
            customDataGrid.dataSource = customDataGridList;
            _teklifTalepId = satisSiparisTeklifTalep.Id;
        }
    }

}