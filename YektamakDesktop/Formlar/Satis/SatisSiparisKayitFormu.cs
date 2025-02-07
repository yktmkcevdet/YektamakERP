using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;
using YektamakDesktop.Formlar.Genel;
using System.Net.Http;
using YektamakDesktop.CustomControls;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using YektamakDesktop.Formlar.Ortak;
using ApiService;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisSiparisKayitFormu : Form, IForm
    {
        private WebMethods _webMethods;
        private static SatisSiparisKayitFormu _satisSiparisKayitFormu;
        public static SatisSiparisKayitFormu satisSiparisKayitFormu
        {
            get
            {
                if (_satisSiparisKayitFormu == null)
                {
                    _satisSiparisKayitFormu = new SatisSiparisKayitFormu();
                    GlobalData.Yetki(ref _satisSiparisKayitFormu);
                }
                return _satisSiparisKayitFormu;
            }
        }
        private SatisSiparis _satisSiparisToSave;
        public SatisSiparis satisSiparisToSave { get => _satisSiparisToSave; set => _satisSiparisToSave = value; }
        public SatisSiparis _satisSiparisToUpdate;
        public SatisSiparis satisSiparisToUpdate { get => _satisSiparisToUpdate; set => _satisSiparisToUpdate = value; }
        public ModeSiparisKayit modeSiparisKayit;
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
                    switch (modeSiparisKayit)
                    {
                        case ModeSiparisKayit.SAVE_FROM_SATISPROJEKAYIT:
                            break;
                        case ModeSiparisKayit.SAVE_FROM_SIPARISGRIDFORM:
                            break;
                        default:
                            break;
                    }
                }
                _activeForm = value;
            }
        }
        private int _siparisId;
        private SatisSiparisKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
            {
                comboListBoxProjeKodu,
                comboListBoxMarka,
                comboListBoxMusteri,
                textBoxSiparisTarihi,
                textBoxTeslimVadesi,
                textBoxSatisTutar,
                comboListBoxSatisTutarDovizCinsi,
                comboListBoxKdv,
                textBoxProjeOngoruMaliyeti,
                comboListBoxProjeOngoruMaliyetiDovizCinsi,
                buttonTahsilatPlani,
                buttonKaydet,
                rButtonGuncelle,
                rButtonKapat,
                buttonTahsilatPlani
            };

        }

        public SatisSiparisKayitFormu(WebMethods webMethods)
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
        private void CloseForm()
        {
            if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(SatisSiparisGridForm))
            {
                if (satisSiparisToUpdate != null && satisSiparisToUpdate.siparisId != 0)
                {
                    SatisSiparisGridForm.satisSiparisGridForm.UpdateRow(satisSiparisToUpdate);
                }
            }
            GlobalData.CloseForm(ref _satisSiparisKayitFormu);
        }

        /// <summary>
        /// Satış sipariş formu çağrıldığı forma göre ve veri işleme tipine göre farklı modlarda açar.
        /// 1- SatisProjeKayitFormu'ndan kayıt eklemek için
        /// 2- SatisSiparisGridForm'undan kayıt eklemek için
        /// 3- SatisProjeKayitFormu'ndan kayıt güncellemek için
        /// 4- SatisSiparisGridForm'undan kayıt güncellemek için
        /// </summary>
        /// <param name="modeSiparisKayit"></param>
        /// <param name="satisSiparis"> Update edilen durumlarda SatisSiparis değeri girilmelidir</param>
        public async Task Setup(ModeSiparisKayit modeSiparisKayit, SatisSiparis satisSiparis = null)
        {
            this.modeSiparisKayit = modeSiparisKayit;
            satisSiparisToUpdate = satisSiparis;
            //KDV ve dövüz cinsi alanları her durumda default olarak doldurulacak
            comboListBoxKdv.ClearListBox();
            //foreach (KDV kdv in GlobalData.kdvList)
            //{
            //    comboListBoxKdv.AddDataRow(kdv.kdvId, "%" + kdv.kdvOrani.ToString());
            //}
            //comboListBoxSatisTutarDovizCinsi.ClearListBox();
            //comboListBoxProjeOngoruMaliyetiDovizCinsi.ClearListBox();
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    comboListBoxSatisTutarDovizCinsi.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //    comboListBoxProjeOngoruMaliyetiDovizCinsi.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}

            #region AssignedProjeKod
            LoadAssignedProjeKod();
            #endregion AssignedProjeKod
            //Seçilen mode'a göre formun setup'ı yapılır

            switch (modeSiparisKayit)
            {
                case ModeSiparisKayit.SAVE_FROM_SATISPROJEKAYIT:
                    comboListBoxProjeKodu.ClearListBox();
                    comboListBoxProjeKodu.AddDataRow(satisSiparis.satisProje.projeKod.Id, satisSiparis.satisProje.projeKod.kod);
                    comboListBoxProjeKodu.SelectDataRowId(satisSiparis.satisProje.projeKod.Id);
                    comboListBoxProjeKodu.Enabled = false;
                    comboListBoxMarka.Enabled = false;
                    //Disable edilecek kontroller belirlenmeli
                    comboListBoxProjeKodu.Enabled = false;
                    buttonTahsilatPlani.Enabled = false;
                    rButtonGuncelle.Visible = false;
                    comboListBoxKdv.SelectDataRowId(4);
                    comboListBoxSatisTutarDovizCinsi.SelectDataRowId(3);//Euro default değer
                    comboListBoxProjeOngoruMaliyetiDovizCinsi.SelectDataRowId(3);//Euro default değer
                    break;

                case ModeSiparisKayit.SAVE_FROM_SIPARISGRIDFORM:
                    comboListBoxMarka.Enabled = false;
                    comboListBoxMusteri.Enabled = false;
                    comboListBoxKdv.SelectDataRowId(4);
                    comboListBoxSatisTutarDovizCinsi.SelectDataRowId(3);//Euro default değer
                    comboListBoxProjeOngoruMaliyetiDovizCinsi.SelectDataRowId(3);//Euro default değer
                    buttonTahsilatPlani.Enabled = false;
                    rButtonGuncelle.Visible = false;
                    break;
                case ModeSiparisKayit.UPDATE_FROM_SATISPROJEKAYIT:
                    satisSiparisToUpdate = await GlobalData.GetModelFromDatabase(WebMethods.GetSatisSiparisById, satisSiparis);
                    //string result = await WebMethods.GetSatisSiparisById(satisSiparis);
                    //DataSet dataSet = GlobalData.JsonStringToDataSet(result);
                    //satisSiparisToUpdate = ConvertHelper.DataRowToModel<SatisSiparis>(dataSet.Tables[0].Rows[0]);
                    comboListBoxProjeKodu.ClearListBox();
                    comboListBoxProjeKodu.AddDataRow(satisSiparisToUpdate.satisProje.projeKod.Id, satisSiparisToUpdate.satisProje.projeKod.kod);
                    comboListBoxMarka.AddDataRow(satisSiparisToUpdate.satisProje.projeKod.marka.markaId, satisSiparisToUpdate.satisProje.projeKod.marka.markaAd);
                    comboListBoxMusteri.AddDataRow(satisSiparisToUpdate.satisProje.musteri.id, satisSiparisToUpdate.satisProje.musteri.unvan);
                    comboListBoxProjeKodu.SelectDataRowId(satisSiparisToUpdate.satisProje.projeKod.Id);
                    FillSatisSiparisKayitForm(satisSiparisToUpdate);
                    comboListBoxProjeKodu.Enabled = false;
                    comboListBoxMusteri.Enabled = false;
                    comboListBoxMarka.Enabled = false;
                    buttonTahsilatPlani.Enabled = true;
                    rButtonGuncelle.Visible = true;
                    break;
                case ModeSiparisKayit.UPDATE_FROM_SIPARISGRIDFORM:
                    comboListBoxProjeKodu.ClearListBox();
                    comboListBoxProjeKodu.AddDataRow(satisSiparis.satisProje.projeKod.Id, satisSiparis.satisProje.projeKod.kod);
                    comboListBoxMarka.AddDataRow(satisSiparis.satisProje.projeKod.marka.markaId, satisSiparis.satisProje.projeKod.marka.markaAd);
                    comboListBoxMusteri.AddDataRow(satisSiparis.satisProje.musteri.id, satisSiparis.satisProje.musteri.unvan);
                    comboListBoxProjeKodu.SelectDataRowId(satisSiparis.satisProje.projeKod.Id);
                    comboListBoxKdv.SelectDataRowValue("%"+satisSiparisToUpdate.kdv.kdvOrani.ToString());
                    FillSatisSiparisKayitForm(satisSiparis);
                    comboListBoxProjeKodu.Enabled = false;
                    buttonTahsilatPlani.Enabled = true;
                    rButtonGuncelle.Visible = true;
                    break;
                default:
                    foreach (Control ctl in controlsToDisable)
                    {
                        ctl.Enabled = false;
                    }
                    rButtonGuncelle.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Formdaki alanlara doğru veri girilip girilmediğini kontrol eder. 
        /// </summary>
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*Bir proje kodu seçmelisiniz!", this, comboListBoxProjeKodu) && result;
            result = GlobalData.CheckField("*Teslim vadesini girmelisiniz!", this, textBoxTeslimVadesi) && result;
            result = GlobalData.CheckField("*Sipariş tarihi girmelisiniz!", this, textBoxSiparisTarihi) && result;
            result = GlobalData.CheckField("*Satış tutarı girmelisiniz!", this, textBoxSatisTutar) && result;
            result = GlobalData.CheckField("*Satış tutar döviz cinsini seçmelisiniz!", this, comboListBoxSatisTutarDovizCinsi) && result;
            result = GlobalData.CheckField("*Öngörülen maliyet tutarını girmelisiniz!", this, textBoxProjeOngoruMaliyeti) && result;
            result = GlobalData.CheckField("*Maliyet tutarı döviz cinsini seçmelisiniz!", this, comboListBoxProjeOngoruMaliyetiDovizCinsi) && result;
            result = GlobalData.CheckField("*KDV oranını seçmelisiniz!", this, comboListBoxKdv) && result;
            return result;
        }
        /// <summary>
        /// Form üzerinde zorunlu alanların girilip girilmediğini kontrol eder, veriler girilmişse SatisSiparis nesnesi olarak hafızaya alır.
        /// </summary>
        /// <returns></returns>
        private SatisSiparis GetCurrentSatisSiparis()
        {
            SatisSiparis satisSiparis = new SatisSiparis();
            satisSiparis.siparisId = _siparisId;
            satisSiparis.satisProje.projeKod.Id = comboListBoxProjeKodu.selectedDataRowId;
            satisSiparis.satisProje.projeKod.kod = comboListBoxProjeKodu.selectedDataRowValue;
            satisSiparis.satisProje.projeKod.marka.markaId = comboListBoxMarka.selectedDataRowId;
            satisSiparis.satisProje.projeKod.marka.markaAd = comboListBoxMarka.selectedDataRowValue;
            satisSiparis.satisProje.musteri.id = comboListBoxMusteri.selectedDataRowId;
            satisSiparis.satisProje.musteri.unvan=comboListBoxMusteri.selectedDataRowValue;
            satisSiparis.kdv.kdvId = comboListBoxKdv.selectedDataRowId;
            satisSiparis.kdv.kdvOrani = int.Parse(comboListBoxKdv.selectedDataRowValue.Substring(1, comboListBoxKdv.selectedDataRowValue.Length - 1));
            satisSiparis.siparisTarihi = DateTime.Parse(textBoxSiparisTarihi.TextCustom);
            satisSiparis.teslimVadesi = int.Parse(textBoxTeslimVadesi.TextCustom.ToString());
            satisSiparis.ongoruMaliyeti.tutar = float.Parse(textBoxProjeOngoruMaliyeti.TextCustom.ToString());
            satisSiparis.ongoruMaliyeti.dovizCinsi.id = comboListBoxProjeOngoruMaliyetiDovizCinsi.selectedDataRowId;
            satisSiparis.satisTutari.tutar = float.Parse(textBoxSatisTutar.TextCustom.ToString());
            satisSiparis.satisTutari.dovizCinsi.id = comboListBoxSatisTutarDovizCinsi.selectedDataRowId;
            satisSiparis.satisTutari.dovizCinsi.sembol = comboListBoxSatisTutarDovizCinsi.selectedDataRowValue;
            return satisSiparis;
        }
        /// <summary>
        /// satisSiparisToSave nesnesinde kayıtlı olan verileri veritabanına kaydetmek için işlemleri başlatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                satisSiparisToSave = GetCurrentSatisSiparis();
                if (satisSiparisToSave != null)
                {
                    this.Enabled = false;
                    string result = await WebMethods.SaveSatisSiparis(satisSiparisToSave);
                    
                    if (result.Contains("error",StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        Setup(ModeSiparisKayit.UPDATE_FROM_SATISPROJEKAYIT, satisSiparisToUpdate);
                        MessageBox.Show("Kayıt başarılı");
                    }
                    this.Enabled = true;
                }
            }
        }
        /// <summary>
        /// satisSiparisToUpdate nesnesinin veritabanındaki karşılğını günceller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                satisSiparisToUpdate = GetCurrentSatisSiparis();
                if (satisSiparisToUpdate != null)
                {
                    this.Enabled = false;
                    string result = await WebMethods.SaveSatisSiparis(satisSiparisToUpdate);

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
        /// <summary>
        /// comboListBoxProjeKodu kontrolünün içine müşterisi tanımlanmış fakat siparişi açılmamış projeleri web servisten çekip doldurur.
        /// </summary>
        private void LoadAssignedProjeKod()
        {
            comboListBoxProjeKodu.ClearListBox();
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSetAssignedProjeKod = jsonConverter.JsonStringToDataSet(_webMethods.GetAllAssignedProjeKod());
            for (int i = 0; i < dataSetAssignedProjeKod.Tables[0].Rows.Count; i++)
            {
                Models.Proje projeKod = new();
                projeKod.Id = int.Parse(dataSetAssignedProjeKod.Tables[0].Rows[i]["ProjeKodId"].ToString());
                projeKod.no = int.Parse(dataSetAssignedProjeKod.Tables[0].Rows[i]["ProjeNo"].ToString());
                projeKod.marka.markaId = int.Parse(dataSetAssignedProjeKod.Tables[0].Rows[i]["MarkaId"].ToString());
                projeKod.marka.markaAltGrup.altGrupId = int.Parse(dataSetAssignedProjeKod.Tables[0].Rows[i]["MarkaAltGrupId"].ToString());
                projeKod.kod = dataSetAssignedProjeKod.Tables[0].Rows[i]["kod"].ToString();
                comboListBoxProjeKodu.AddDataRow(projeKod.Id, projeKod.kod);
            }
        }
        /// <summary>
        /// Siparişe ait ödeme planının kaydedileceği ve/veya güncelleneceği tahsilatPlanKayitFormu'nu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonProjeAsamalari_Click(object sender, EventArgs e)
        {
            //buttonTahsilatPlani.Enabled = false;
            //satisSiparisToUpdate = GetCurrentSatisSiparis();
            //string webReturnValue = await WebMethods.GetTahsilatPlaniBySiparisId(_siparisId);
            //byte[] bytes = JsonConvert.DeserializeObject<byte[]>(webReturnValue);
            //string returnValue = Encoding.UTF8.GetString(bytes);
            //DataSet tahsilatPlan = JsonConvert.DeserializeObject<DataSet>(returnValue);
            //if (tahsilatPlan.Tables[0].Rows.Count > 0)
            //{
            //    TahsilatPlanKayitFormu tahsilatPlanKayitFormu = TahsilatPlanKayitFormu.tahsilatPlanKayitFormu;
            //    if (tahsilatPlanKayitFormu != null)
            //    {
            //        tahsilatPlanKayitFormu.Show();
            //        tahsilatPlanKayitFormu.UpdateMode(satisSiparisToUpdate);
            //    }
            //}
            //else
            //{
            //    TahsilatPlanKayitFormu tahsilatPlanKayitFormu = TahsilatPlanKayitFormu.tahsilatPlanKayitFormu;
            //    if (tahsilatPlanKayitFormu != null)
            //    {
            //        tahsilatPlanKayitFormu.Show();
            //        tahsilatPlanKayitFormu.SaveMode(satisSiparisToUpdate);
            //    }
            //}

        }
        /// <summary>
        /// ProjeKodId'ye göre ProjeKod'unu döndürür.
        /// </summary>
        /// <param name="projeKodId"></param>
        /// <returns></returns>
        private async Task<Models.Proje> GetProjeKodById(int projeKodId)
        {
            DataSet dataSet;
            Models.Proje projeKod = new();
            projeKod.Id = projeKodId;
            var httpTask = WebMethods.GetProjeKodById(projeKod);
            string result = await httpTask;
            if (result.Length > 6 && result.Substring(0, 5) == "error")
            {
                MessageBox.Show(result);
            }
            else
            {
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                string json = Encoding.UTF8.GetString(bytes);
                dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    projeKod.marka.markaId = int.Parse(dr["markaId"].ToString());
                    projeKod.Id = projeKodId;
                    projeKod.no = int.Parse(dr["projeNo"].ToString());
                }
            }

            return projeKod;
        }
        
        /// <summary>
        /// Gelen satisSiparis nesnesinin alanlarını Satış sipariş kayıt formunda ilgili alanlara doldurur.
        /// </summary>
        /// <param name="satisSiparis"></param>
        private void FillSatisSiparisKayitForm(SatisSiparis satisSiparis)
        {
            textBoxSiparisTarihi.TextCustom = satisSiparis.siparisTarihi.ToShortDateString();
            textBoxTeslimVadesi.TextCustom = satisSiparis.teslimVadesi.ToString();
            textBoxSatisTutar.TextCustom = satisSiparis.satisTutari.tutar.ToString("#,##0.00");
            comboListBoxSatisTutarDovizCinsi.SelectDataRowId(satisSiparis.satisTutari.dovizCinsi.id);
            comboListBoxKdv.SelectDataRowId(satisSiparis.kdv.kdvId);
            textBoxProjeOngoruMaliyeti.TextCustom = satisSiparis.ongoruMaliyeti.tutar.ToString("#,##0.00");
            comboListBoxProjeOngoruMaliyetiDovizCinsi.SelectDataRowId(satisSiparis.ongoruMaliyeti.dovizCinsi.id);
            _siparisId = satisSiparis.siparisId;
        }
        /// <summary>
        /// Proje kodu değiştiğinde firma adı ve marka adı alanlarını doldurur.
        /// firmaId ve markaId değerlerini de atayarak kaydetmek üzere hafızada tutar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void comboListBoxProjeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboListBoxMarka.SelectDataRowId(satisSiparisToUpdate.satisProje.projeKod.marka.markaId);
            comboListBoxMusteri.SelectDataRowId(satisSiparisToUpdate.satisProje.musteri.id);
        }
        /// <summary>
        /// Sadece sayısal veriler girilmesine izin veriri, alfasayısal değerleri engeller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTeslimVadesi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Geçersiz karakterleri işleme
                MessageBox.Show("Sadece rakamsal değerler girilmelidir!");
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

        private void SatisSiparisKayitFormu_Load(object sender, EventArgs e)
        {

        }
    }
    /// <summary>
    /// SatisSiparisKayitFormu'nun açılış mode'larıdır.
    /// </summary>
    public enum ModeSiparisKayit
    {
        SAVE_FROM_SATISPROJEKAYIT = 0,
        SAVE_FROM_SIPARISGRIDFORM = 1,
        UPDATE_FROM_SATISPROJEKAYIT = 2,
        UPDATE_FROM_SIPARISGRIDFORM = 3
    }
}