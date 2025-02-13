using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Temp;
using Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ApiService;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisFaturaKayitFormu : Form, IForm
    {
        private WebMethods _webMethods;
        private static SatisFaturaKayitFormu _satisFaturaKayitFormu;
        public static SatisFaturaKayitFormu satisFaturaKayitFormu
        {
            get
            {
                if (_satisFaturaKayitFormu == null)
                {
                    _satisFaturaKayitFormu = new SatisFaturaKayitFormu();
                    GlobalData.Yetki(ref _satisFaturaKayitFormu);
                }
                return _satisFaturaKayitFormu;
            }
        }
        private SatisFatura _satisFaturaToSave;
        private SatisFatura satisFaturaToSave { get { if(_satisFaturaToSave==null) { _satisFaturaToSave = new(); } return _satisFaturaToSave; } set { _satisFaturaToSave = value; } }
        private SatisFatura _satisFaturaToUpdate;
        private SatisFatura satisFaturaToUpdate { get { if (_satisFaturaToUpdate == null) { _satisFaturaToUpdate = new(); } return _satisFaturaToUpdate; } set { _satisFaturaToUpdate = value; } }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private List<Models.Proje> _orderedProjeKodList;
        private int _satisFaturaId;
        private float _faturalandirilmamisTutar;
        private SatisFaturaKayitFormu()
        {
            InitializeComponent();
            LoadDovizList();
            LoadKdvList();
            controlsToDisable = new List<Control>
            {
                customTextBoxSatisTutari,
                textBoxFaturalandirilmamisTutar,
                textBoxFaturaNo,
                textBoxFaturaTarihi,
                comboListBoxCariKartId,
                comboListBoxDovizCinsi,
                comboListBoxkdv,
                comboListBoxProjeKodu,
                textBoxFaturaTutari,
                rButtonGuncelle,
                rButtonKapat,
                rButtonKaydet
            };
        }

        private void LoadKdvList()
        {
            //for (int i = 0; i < GlobalData.kdvList.Count; i++)
            //{
            //    comboListBoxkdv.AddDataRow(GlobalData.kdvList[i].kdvId, GlobalData.kdvList[i].kdvOrani.ToString());
            //}
        }

        private void LoadDovizList()
        {
            //for (int i = 0; i < GlobalData.dovizList.Count; i++)
            //{
            //    comboListBoxDovizCinsi.AddDataRow(GlobalData.dovizList[i].id, GlobalData.dovizList[i].sembol);
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
        /// Formu kapatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonKapat_Click(object sender, EventArgs e)
        {
           await CloseForm();
        }
        /// <summary>
        /// Formu kayıt modunda açar. Güncelleme butonunu görünmez yapar. ProjeKod ComboList'ini doldurur.
        /// </summary>
        public async Task SaveMode()
        {
            rButtonGuncelle.Visible = false;
            await LoadOrderedProjeKod();
            FillComboListBoxProjeKodu();
        }
        /// <summary>
        /// Formu güncelleme modunda açar. Alanları gelen satisFatura nesnesindeki bilgilere göre doldurur.
        /// </summary>
        /// <param name="satisFatura"></param>
        public void UpdateMode(SatisFatura satisFatura)
        {
            satisFaturaToUpdate = satisFatura;
            rButtonGuncelle.Visible = true;
            _satisFaturaId = satisFatura.satisFaturaId;
            comboListBoxProjeKodu.AddDataRow(satisFatura.satisSiparis.satisProje.projeKod.Id, satisFatura.satisSiparis.satisProje.projeKod.kod);
            comboListBoxProjeKodu.SelectDataRowId(satisFatura.satisSiparis.satisProje.projeKod.Id);
            comboListBoxProjeKodu.Enabled = false;
            textBoxFaturaNo.TextCustom = satisFatura.faturaNo.ToString();
            comboListBoxCariKartId.SelectDataRowId(satisFatura.cariKart.cariKartId);
            comboListBoxCariKartId.Enabled = false;
            textBoxFaturaTarihi.TextCustom = satisFatura.faturaTarihi.ToShortDateString();
            textBoxFaturaTutari.TextCustom = satisFatura.tutar.tutar.ToString("#,##0.00");
        }
        /// <summary>
        /// Zorunlu alanların bilgi girişini kontrol eder, giriş yapılmamış alan varsa uyarı verir.
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            bool result = true;

            GlobalData.ClearWarningLabels(this);
            result = GlobalData.CheckField("Fatura no girilmelidir",this,textBoxFaturaNo) && result;
            result = GlobalData.CheckField("Proje kodu seçilmelidir.", this, comboListBoxProjeKodu) && result;
            result = GlobalData.CheckField("Fatura tarihi girilmelidir.", this, textBoxFaturaTarihi) && result;
            result = GlobalData.CheckField("Fatura tutarı girilmelidir.", this, textBoxFaturaTutari) && result;
           
            if (float.Parse(textBoxFaturalandirilmamisTutar.TextCustom) < 0)
            {
                labelFaturaTutariUyari.Text = "Kesilen toplam fatura tutarı sipariş tutarını geçiyor!";
                return false;
            }

            return result;
        }
        /// <summary>
        /// Girdi alanlarını kontrol eder, eksik yoksa alanlardaki verileri veritabanına kaydeder ve form UpdateMode'a geçer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                satisFaturaToSave = await GetCurrentSatisFatura();
                if (satisFaturaToSave != null)
                {
                    string result = await WebMethods.SaveSatisFatura(satisFaturaToSave);
                    if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                        DataSet dataSetSatisFatura = jsonConverter.JsonStringToDataSet(result);
                        int satisFaturaId = int.Parse(dataSetSatisFatura.Tables[0].Rows[0][0].ToString());
                        satisFaturaToUpdate = satisFaturaToSave;
                        satisFaturaToUpdate.satisFaturaId = satisFaturaId;  
                        UpdateMode(satisFaturaToUpdate);

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
                satisFaturaToUpdate = await GetCurrentSatisFatura();

                string result = await WebMethods.SaveSatisFatura(satisFaturaToUpdate);

                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Kayıt güncellemesi başarı ile tamamlandı");

                    await CloseForm();
                }
            }
        }

        private async Task CloseForm()
        {
            SatisFatura satisFatura = await GetCurrentSatisFatura();
            if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(SatisFaturaGridForm))
            {
                if (satisFatura != null && satisFatura.satisFaturaId != 0)
                {
                    SatisFaturaGridForm.satisFaturaGridForm.UpdateRow(satisFatura);
                }
            }
            GlobalData.CloseForm(ref _satisFaturaKayitFormu);
        }

        /// <summary>
        /// Proje kodu değiştirilirse o proje koduna ait müşteri, tutar, döviz cinsi ve kdv oranı formda ilgili alanlara doldurulur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboListBoxProjeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SatisSiparis satisSiparis = new SatisSiparis();
                satisSiparis.satisProje.projeKod.Id = comboListBoxProjeKodu.selectedDataRowId;
                string data = WebMethods.GetFilteredSatisSiparis(satisSiparis);
                IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                DataSet dataSetSatisSiparis = jsonConverter.JsonStringToDataSet(data);

                int musteriId = Convert.ToInt32(dataSetSatisSiparis.Tables[0].Rows[0]["FirmaId"]);
                string musteriUnvan = dataSetSatisSiparis.Tables[0].Rows[0]["satisProje_Musteri_Unvan"].ToString();
                float tutar = float.Parse(dataSetSatisSiparis.Tables[0].Rows[0]["SatisTutari_tutar"].ToString());
                int dovizCinsi = Convert.ToInt32(dataSetSatisSiparis.Tables[0].Rows[0]["SatisTutari_DovizCinsi_id"]);
                int kdvOrani = Convert.ToInt32(dataSetSatisSiparis.Tables[0].Rows[0]["kdv_KDVOrani"]);
                int cariKartId = -1;
                //foreach (CariKart cariKart in GlobalData.cariKartList.Where(x => x.cari.Id == musteriId && x.guncelCari.dovizCinsi.id == dovizCinsi))
                //{
                //    comboListBoxCariKartId.AddDataRow(cariKart.cariKartId, cariKart.cariAdi);
                //    cariKartId = cariKart.cariKartId;
                //}
                if (comboListBoxCariKartId.listBoxDataRows.Count == 1)
                {
                    comboListBoxCariKartId.SelectDataRowId(cariKartId);
                }
                if (comboListBoxCariKartId.listBoxDataRows.Count == 0)
                {
                    MessageBox.Show("Siparişin döviz türünde firma cari kartı açılmamış");
                }
                customTextBoxSatisTutari.TextCustom = tutar.ToString("#,##0.00");
                comboListBoxDovizCinsi.SelectDataRowId(dovizCinsi);
                comboListBoxkdv.SelectDataRowValue(kdvOrani.ToString());
                _faturalandirilmamisTutar = float.Parse(dataSetSatisSiparis.Tables[0].Rows[0]["Faturalandirilmamis_Tutar"].ToString());
                textBoxFaturalandirilmamisTutar.TextCustom = (_faturalandirilmamisTutar).ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Sipariş açılmış proje kodu listesini veritabanından alır.
        /// </summary>
        /// <returns></returns>
        private async Task<string> LoadOrderedProjeKod()
        {
            try
            {
                string resultOrderedProjeKod = await _webMethods.GetAllOrderedProjeKod(); ;

                if (resultOrderedProjeKod.Length > 6 && resultOrderedProjeKod.Substring(0, 5) == "error")
                {
                    MessageBox.Show(resultOrderedProjeKod);
                }
                else
                {
                    byte[] bytes = JsonConvert.DeserializeObject<byte[]>(resultOrderedProjeKod);
                    string json = Encoding.UTF8.GetString(bytes);
                    DataSet dataSetOrderedProjeKod = JsonConvert.DeserializeObject<DataSet>(json);
                    _orderedProjeKodList = new List<Models.Proje>();


                    for (int i = 0; i < dataSetOrderedProjeKod.Tables[0].Rows.Count; i++)
                    {
                        Models.Proje projeKod = new Models.Proje();
                        projeKod.Id = int.Parse(dataSetOrderedProjeKod.Tables[0].Rows[i]["ProjeKodId"].ToString());
                        projeKod.no = int.Parse(dataSetOrderedProjeKod.Tables[0].Rows[i]["ProjeNo"].ToString());
                        projeKod.marka.markaId = int.Parse(dataSetOrderedProjeKod.Tables[0].Rows[i]["MarkaId"].ToString());
                        projeKod.marka.markaAltGrup.altGrupId = int.Parse(dataSetOrderedProjeKod.Tables[0].Rows[i]["MarkaAltGrupId"].ToString());
                        _orderedProjeKodList.Add(projeKod);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        /// <summary>
        /// Proje Kodu ComboList'ine siparişi açılmış proje kodlarını doldurur.
        /// </summary>
        public void FillComboListBoxProjeKodu()
        {
            if (_orderedProjeKodList != null && _orderedProjeKodList.Count > 0)
            {
                comboListBoxProjeKodu.ClearListBox();
                for (int i = 0; i < _orderedProjeKodList.Count; i++)
                {
                    comboListBoxProjeKodu.AddDataRow(_orderedProjeKodList[i].Id, _orderedProjeKodList[i].kod);
                }
            }
        }
        /// <summary>
        /// Form üzerindeki alanlara kayıt edilmiş verileri veritabanına kaydetmek için SatisFatura nesnesine alır.
        /// </summary>
        /// <returns></returns>
        public async Task<SatisFatura> GetCurrentSatisFatura()
        {
            SatisFatura satisFatura = new SatisFatura();

            try
            {
                Models.Proje proje=new Models.Proje();
                proje.Id = comboListBoxProjeKodu.selectedDataRowId;
                string httpResult = await WebMethods.GetProjeKodById(proje);
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
                string json = Encoding.UTF8.GetString(bytes);
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(json);
                if (CheckFields())
                {
                    satisFatura.satisSiparis.Id = int.TryParse(ds.Tables[0].Rows[0]["siparisId"].ToString(),out int outSiparisId)?outSiparisId:0;
                    satisFatura.satisFaturaId = _satisFaturaId;
                    satisFatura.faturaNo = textBoxFaturaNo.TextCustom;
                    satisFatura.satisSiparis.satisProje.projeId = int.Parse(ds.Tables[0].Rows[0]["ProjeId"].ToString());
                    satisFatura.satisSiparis.satisProje.projeKod.kod = ds.Tables[0].Rows[0]["ProjeKodString"].ToString();
                    satisFatura.faturaTarihi = DateTime.Parse(textBoxFaturaTarihi.TextCustom);
                    satisFatura.cariKart = new CariKart();
                    satisFatura.cariKart.cariKartId = int.Parse(comboListBoxCariKartId.selectedDataRowId.ToString());
                    satisFatura.tutar = new Tutar();
                    satisFatura.tutar.tutar = float.Parse(textBoxFaturaTutari.TextCustom.ToString());
                    satisFatura.tutar.dovizCinsi.id = comboListBoxDovizCinsi.selectedDataRowId;
                    satisFatura.cariKart.cariAdi = comboListBoxCariKartId.selectedDataRowValue.ToString();
                    satisFatura.satisSiparis.satisProje.projeKod.Id = comboListBoxProjeKodu.selectedDataRowId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return satisFatura;
        }
        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            GlobalData.CloseForm(ref _satisFaturaKayitFormu);
        }

    }
}
