using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Formlar.Satinalma;
using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities.Interfaces;
using Utilities.Implementations;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisProjeKayitFormu : Form, IForm
    {
        private static ICache _cache;
        private WebMethods _webMethods;
        private static SatisProjeKayitFormu _satisProjeKayitFormu;
        public static SatisProjeKayitFormu satisProjeKayitFormu
        {
            get
            {
                if (_satisProjeKayitFormu == null)
                {
                    _satisProjeKayitFormu = new SatisProjeKayitFormu();
                    GlobalData.Yetki(ref _satisProjeKayitFormu);
                }
                return _satisProjeKayitFormu;
            }
        }
        private SatisProje satisProjeToSave;
        private SatisProje satisProjeToUpdate;
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private List<Models.Proje> _unassignedProjeKodList;
        public List<Models.Proje> unassignedProjeKodList
        {
            get => _unassignedProjeKodList;
            set => _unassignedProjeKodList = value;
        }
        private List<Firma> _firmaUnvanList;
        public List<Firma> firmaUnvanList
        {
            get => _firmaUnvanList;
            set => _firmaUnvanList = value;
        }

        private bool _activeForm;
        public bool activeForm
        {
            get => _activeForm;
            set
            {
                if (value)
                {
                    if (isSaveMode)
                    {
                        SaveMode();
                    }
                }
                _activeForm = value;
            }
        }
        private bool _isSaveMode = false;
        /// <summary>
        /// Başka pencerelerden bu form üzerinde işlem yapılacak olursa diye böyle bir property oluşturuldu.
        /// Pencere SaveMode metoduyla açılırsa true, UpdateMode metoduyla açılırsa false olur.
        /// </summary>
        public bool isSaveMode { get => _isSaveMode; }
        public SatisProjeKayitFormu()
        {
            InitializeComponent();
            LoadUnassignedProjeKod();
            LoadMusteriler();
            LoadSatisPersonelList();
            controlsToDisable = new List<Control>();
            {
            }
        }
        public SatisProjeKayitFormu(ICache cache)
        {
            _cache = cache;
        }

        public SatisProjeKayitFormu(WebMethods webMethods)
        {
            _webMethods = webMethods;
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

        /// <summary>
        /// Formu kapatır, form eğer SatisProjeGridForm'dan çağrıldıysa SatisProjeGridForm'u günceller.
        /// </summary>
        private void CloseForm()
        {
            SatisProje satisProje = GetCurrentSatisProje();
            if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(SatisProjeGridForm))
            {
                if (satisProje != null && satisProje.projeId != 0)
                {
                    SatisProjeGridForm.satisProjeGridForm.UpdateRow(satisProjeToUpdate);
                }
            }
            else if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(SatinalmaSiparisKayitFormuOld))
            {
                if (satisProje != null && satisProje.projeId != 0)
                {
                    SatinalmaSiparisKayitFormuOld.satinalmaSiparisKayitFormu.FillComboListProjeKodu();
                }
            }
            GlobalData.CloseForm(ref _satisProjeKayitFormu);
        }
        /// <summary>
        /// Formu yeni kayıt modunda açar.Kayıt modunda pasif olması gereken kontrolleri pasifleştirir, gerekli kontrolleri aktifleştirir.
        /// ProjeKodları ve FirmaUnvanları combolist'leri yüklenir.
        /// </summary>
        public void SaveMode()
        {
            //textBoxProjeAsamalari.Enabled = false;
            textBoxSiparisKaydi.Enabled = false;
            //buttonProjeAsamalari.Enabled = false;
            buttonSiparisKaydiEkle.Enabled = false;
            rButtonGuncelle.Visible = false;
            rButtonKaydet.Visible = true;
            rButtonKaydet.Enabled = true;
            _isSaveMode = true;
            comboListBoxSatisSorumlusu.SelectDataRowId(_cache.kullanici.personel.Id);
        }
        /// <summary>
        /// Formu güncelleme modunda açar.Güncelleme modunda pasif olması gereken kontrolleri pasifleştirir, gerekli kontrolleri aktifleştirir.
        /// </summary>
        /// <param name="satisProje"></param>
        public void UpdateMode(SatisProje satisProje)
        {
            this.Enabled = false;
            
            satisProjeToUpdate = satisProje;
            
            comboListBoxProjeKodu.AddDataRow(satisProje.projeKod.Id, satisProje.projeKod.kod);
            comboListBoxProjeKodu.SelectDataRowId(satisProje.projeKod.Id);
            comboListBoxMusteri.SelectDataRowId(satisProje.musteri.Id);
            SatisSiparis satisSiparis=new SatisSiparis();
            satisSiparis.satisProje=satisProje;
            string httpResult = WebMethods.GetFilteredSatisSiparis(satisSiparis);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            string json = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            if (dataSet.Tables[0].Rows.Count > 0)
                textBoxSiparisKaydi.TextCustom = dataSet.Tables[0].Rows[0]["SiparisId"].ToString();
            this.Enabled = true;
            comboListBoxSatisSorumlusu.SelectDataRowId(satisProje.satisSorumlusu.Id);


            textBoxProjeAdi.TextCustom = satisProje.projeAd;
            textBoxProjeAciklamasi.TextCustom = satisProje.projeAciklama;

            textBoxProjeAsamalari.Enabled = false;
            textBoxSiparisKaydi.Enabled = true;
            buttonProjeAsamalari.Enabled = true;
            buttonSiparisKaydiEkle.Enabled = true;
            rButtonGuncelle.Visible = true;
            rButtonGuncelle.Enabled = true;
            rButtonKaydet.Visible = false;
            rButtonKaydet.Enabled = false;
            comboListBoxSatisSorumlusu.Enabled = false;

        }
        /// <summary>
        /// Zorunlu alanlara veri girilip girilmediğini kontrol eder. 
        /// </summary>
        private bool CheckFields()
        {
            bool result = true;

            GlobalData.ClearWarningLabels(this);

            result = GlobalData.CheckField("*Bir proje kodu seçmelisiniz!", this, comboListBoxProjeKodu) && result;
            result = GlobalData.CheckField("*Bir proje adı girmelisiniz!", this, textBoxProjeAdi) && result;
            result = GlobalData.CheckField("*Bir proje açıklaması girmelisiniz!", this, textBoxProjeAciklamasi) && result;
            result = GlobalData.CheckField("*Bir müşteri seçmelisiniz!", this, comboListBoxMusteri) && result;

            return result;
        }
        /// <summary>
        /// Form üzerinde yapılan değişiklikleri SatisProje nesnesi olarak döndürür.
        /// </summary>
        /// <returns></returns>
        private SatisProje GetCurrentSatisProje()
        {
            SatisProje satisProje = null;
            if (CheckFields())
            {
                satisProje = new SatisProje();
                satisProje.projeId = (satisProjeToUpdate != null ? satisProjeToUpdate.projeId : 0); //Güncellemek için açıldıysa projeId'sini atar, yemi kayıt ise projeId'ye 0 atar.
                satisProje.projeAd = textBoxProjeAdi.TextCustom;
                satisProje.projeAciklama = textBoxProjeAciklamasi.TextCustom;
                satisProje.projeKod = new Models.Proje();
                satisProje.projeKod.Id = comboListBoxProjeKodu.selectedDataRowId;
                satisProje.projeKod.kod = comboListBoxProjeKodu.selectedDataRowValue;
                satisProje.musteri = new Firma();
                satisProje.musteri.Id = comboListBoxMusteri.selectedDataRowId;
                satisProje.musteri.ad = comboListBoxMusteri.selectedDataRowValue;
                satisProje.satisSorumlusu = new Personel();
                satisProje.satisSorumlusu.Id = comboListBoxSatisSorumlusu.selectedDataRowId;
            }
            return satisProje;
        }
        /// <summary>
        /// Form üzerinde yapılan değişiklikleri satisProjeToSave nesnesine aktarıp, veritabanına kaydetme işlemlerini başlatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                satisProjeToSave = GetCurrentSatisProje();
                if (satisProjeToSave != null)
                {
                    string result = await WebMethods.SaveSatisProje(satisProjeToSave);
                    if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                        DataSet dsProjeId = jsonConverter.JsonStringToDataSet(result);
                        int projeId = int.Parse(dsProjeId.Tables[0].Rows[0][0].ToString());
                        satisProjeToUpdate = satisProjeToSave;
                        satisProjeToUpdate.projeId = projeId;
                        UpdateMode(satisProjeToUpdate);

                        MessageBox.Show("Kayıt başarılı");
                    }
                }
            }
        }
        /// <summary>
        /// Formdaki zorunlu alanları kontrol eder, hata yoksa veritabanına günceller ve formu kapatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                satisProjeToUpdate = GetCurrentSatisProje();

                string result = await WebMethods.SaveSatisProje(satisProjeToUpdate);

                if (result.Contains("error",StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    
                    MessageBox.Show("Kayıt güncellemesi başarı ile tamamlandı");

                    CloseForm();
                }
            }
        }
        /// <summary>
        /// comboListBoxProjeKodu kontrolünün içine bir projeye atanmamış projekod verilerini web servisten çekip doldurur.
        /// </summary>
        private void LoadUnassignedProjeKod()
        {
            ComboBoxListFill.GetLookupKod(_cache.unAssignedProjeList, ref comboListBoxProjeKodu);
        }
        /// <summary>
        /// comboListBoxMusteriler kontrolünün içine web servisteki bütün firma bilgilerini doldurur.
        /// </summary>
        private void LoadMusteriler()
        {
            ComboBoxListFill.GetLookupAd(_cache.firmaList, ref comboListBoxMusteri);
        }
        /// <summary>
        /// Yeni bir proje kodu eklemek için ProjeKodKayitFormu formunu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProjeKoduEkle_Click(object sender, EventArgs e)
        {
            ProjeKodKayitFormu projeKodKayitFormu = ProjeKodKayitFormu.projeKodKayitFormu;
            if(projeKodKayitFormu != null)
            {
                projeKodKayitFormu.Show();
                projeKodKayitFormu.SaveMode();
            }
        }
        /// <summary>
        /// Yeni bir firma eklemek için FirmaKayitFormu formunu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFirmaEkle_Click(object sender, EventArgs e)
        {
            FirmaKayitFormu firmaKayitFormu = FirmaKayitFormu.firmaKayitFormu;
            if(firmaKayitFormu !=null)
            {
                firmaKayitFormu.Show();
                firmaKayitFormu.SaveMode();
            }
        }
        /// <summary>
        /// comboListBoxProjeKodu kontrolünün içine bir projeye atanmamış projekod verilerini web servisten çekip doldurur.
        /// </summary>
        /// <param name="projeKod"></param>
        internal void ProjeKodEkle(Models.Proje projeKod)
        {
            comboListBoxProjeKodu.AddDataRow(projeKod.Id, projeKod.kod);
            comboListBoxProjeKodu.SelectDataRowId(projeKod.Id);
        }
        /// <summary>
        /// comboListBoxMusteriler kontrolünün içine web servisteki bütün firma bilgilerini doldurur.
        /// </summary>
        /// <param name="firma"></param>
        internal void AddNewFirmaToComboList(Firma firma)
        {
            comboListBoxMusteri.AddDataRow(firma.Id, firma.ad);
            comboListBoxMusteri.SelectDataRowId(firma.Id);
        }
        /// <summary>
        /// Proje safhalarını eklemek ve çıkarmak için ProjeSafhaGridForm formunu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProjeAsamalari_Click(object sender, EventArgs e)
        {
            //Tıklanılan projenin projeId bilgisini al ve yeni açılan SatisProjesSafhaGridForm formuna gönder.

            ProjeSafhaGridForm projeSafhaGridForm = ProjeSafhaGridForm.projeSafhaGridForm;
            if(projeSafhaGridForm != null)
            {
                projeSafhaGridForm.UpdateMode(satisProjeToUpdate.projeId);
                projeSafhaGridForm.Show();
            }
        }
        /// <summary>
        /// textBoxProjeAsamalari kontrolüne, proje aşamalarının başlıklarını yazar.
        /// </summary>
        /// <param name="projeSafhaList"></param>
        public void FilltextBoxProjeAsamalari(List<ProjeSafha> projeSafhaList)
        {
            satisProjeToUpdate.projeSafhalar = projeSafhaList;
            try
            {
                if (satisProjeToUpdate != null)
                {
                    textBoxProjeAsamalari.TextCustom = "";
                    if (satisProjeToUpdate.projeSafhalar != null)
                    {
                        foreach (ProjeSafha satisProjeSafha in satisProjeToUpdate.projeSafhalar)
                        {
                            textBoxProjeAsamalari.TextCustom = textBoxProjeAsamalari.TextCustom + satisProjeSafha.projeSafhaAdi + "|";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Proje Kodu combolist'i değişirse proje koduna bağlı olan proje safhlarını gösteren textbox'ı günceller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboListBoxProjeKodu_TextChanged(object sender, EventArgs e)
        {
            if (_isSaveMode == false)
            {
                FilltextBoxProjeAsamalari(satisProjeToUpdate.projeSafhalar);
            }
        }
        /// <summary>
        /// Yeni bir satış siparişi eklemek için satisSiparisKayitFormu'nu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSiparisKaydiEkle_Click(object sender, EventArgs e)
        {
            SatisSiparis satisSiparis = new();
            satisSiparis.satisProje.projeKod.Id = comboListBoxProjeKodu.selectedDataRowId;
            satisSiparis.satisProje.projeKod.kod = comboListBoxProjeKodu.selectedDataRowValue;
            SatisSiparisKayitFormu satisSiparisKayitFormu = SatisSiparisKayitFormu.satisSiparisKayitFormu;
            if(satisSiparisKayitFormu  != null)
            {
                satisSiparisKayitFormu.Show();
            }
            if (!string.IsNullOrWhiteSpace(textBoxSiparisKaydi.TextCustom))
            {
                satisSiparis.Id = Convert.ToInt32(textBoxSiparisKaydi.TextCustom);
                satisSiparisKayitFormu.Setup(ModeSiparisKayit.UPDATE_FROM_SATISPROJEKAYIT, satisSiparis);
            }
            else
            {
                satisSiparisKayitFormu.Setup(ModeSiparisKayit.SAVE_FROM_SATISPROJEKAYIT, satisSiparis);
            }

        }
        private void LoadSatisPersonelList()
        {
            //foreach (Personel personel in GlobalData.personelList)
            //{
            //    comboListBoxSatisSorumlusu.AddDataRow(personel.Id, string.Concat(personel.ad, " ", personel.soyad));
            //}
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
