using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Formlar.Satis;
using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaSiparisKayitFormuOld : Form, IForm
    {
        private WebMethods _webMethods;
        private static SatinalmaSiparisKayitFormuOld _satinalmaSiparisKayitFormu;

        public static SatinalmaSiparisKayitFormuOld satinalmaSiparisKayitFormu
        {
            get
            {
                if (_satinalmaSiparisKayitFormu == null)
                {
                    _satinalmaSiparisKayitFormu = new SatinalmaSiparisKayitFormuOld();
                    GlobalData.Yetki(ref _satinalmaSiparisKayitFormu);
                }
                return _satinalmaSiparisKayitFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private int _satinalmaSiparisId;
        private int _satinalmaFaturaId;
        public SatinalmaSiparisKayitFormuOld()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
            foreach (Control control in panelSatinalmaSiparisMain.Controls)
            {
                if (control.Name != "panelHeader")
                {
                    controlsToDisable.Add(control);
                }
            }
            FillComboList();
        }

        public SatinalmaSiparisKayitFormuOld(WebMethods webMethods)
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
        #endregion mouseDrag
        /// <summary>
        /// Formu kapatır ve activeformstack listesinden siler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        public void FillComboList()
        {
            //comboListBoxTutarDovizCinsi.ClearListBox();
            //for (int i = 0; i < GlobalData.dovizList.Count; i++)
            //{
            //    comboListBoxTutarDovizCinsi.AddDataRow(GlobalData.dovizList[i].id, GlobalData.dovizList[i].sembol);
            //    comboListBoxAvansDovizCinsi.AddDataRow(GlobalData.dovizList[i].id, GlobalData.dovizList[i].sembol);
            //}
            //comboListBoxTutarDovizCinsi.SelectDataRowId(1);
            //comboListBoxAvansDovizCinsi.SelectDataRowId(1);
            //for (int i = 0; i < GlobalData.kdvList.Count; i++)
            //{
            //    comboListBoxkdv.AddDataRow(GlobalData.kdvList[i].kdvId, GlobalData.kdvList[i].kdvOrani.ToString());
            //}
            //comboListBoxkdv.SelectDataRowId(5);
            //for (int i = 0; i < GlobalData.firmaUnvanList.Count; i++)
            //{
            //    comboListBoxFirmaId.AddDataRow(GlobalData.firmaUnvanList[i].id, GlobalData.firmaUnvanList[i].unvan.ToString());
            //}
        }
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaSiparisKayitFormu);
        }
        /// <summary>
        /// Form veri kaydetmek için açılırsa combolist alanlar(proje kodu ve fatura numarası) doldurulur.
        /// </summary>
        public async Task SaveMode()
        {
            this.Enabled = false;
            FillComboListProjeKodu();
            await FillComboListFaturaNo();
            rButtonGuncelle.Visible = false;
            rButtonKaydet.Visible = true;
            this.Enabled = true;
        }
        /// <summary>
        /// Form veri güncellemek için açılırsa veriler ilgili form nesnelerine doldurulur.
        /// </summary>
        /// <param name="satinalmaSiparis"></param>
        public async Task UpdateMode(SatinalmaSiparis satinalmaSiparis)
        {
            this.Enabled = false;
            rButtonKaydet.Visible = false;
            FillComboListProjeKodu();
            await FillComboListFaturaNo();
            _satinalmaSiparisId = satinalmaSiparis.satinalmaSiparisId;
            comboListBoxProjeKodu.SelectDataRowId(satinalmaSiparis.projeKod.Id);
            _satinalmaFaturaId = satinalmaSiparis.satinalmaFatura.satinalmaFaturaId;
            textBoxTutar.TextCustom = satinalmaSiparis.tutar.tutar.ToString("#,##0.00");
            textBoxTermin.TextCustom = satinalmaSiparis.termin.ToString();
            comboListBoxTutarDovizCinsi.SelectDataRowId(satinalmaSiparis.tutar.dovizCinsi.id);
            textBoxAvans.TextCustom = satinalmaSiparis.avans.tutar.ToString("#,##0.00");
            comboListBoxAvansDovizCinsi.SelectDataRowId(satinalmaSiparis.avans.dovizCinsi.id);
            comboListBoxkdv.SelectDataRowId(satinalmaSiparis.kdv.kdvId);
            textBoxVade.TextCustom = satinalmaSiparis.vade.ToString();
            comboListBoxFirmaId.SelectDataRowId(satinalmaSiparis.firma.Id);
            textBoxSiparisTarihi.TextCustom = satinalmaSiparis.siparisTarihi.ToShortDateString();
            textBoxAciklama.TextCustom = satinalmaSiparis.siparisAciklamasi.ToString();
            this.Enabled = true;
        }
        /// <summary>
        /// Proje kodu combolisti satış siparişi açılmış proje kodları ile doldurulur.
        /// </summary>
        public string FillComboListProjeKodu()
        {
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(_webMethods.GetAllAssignedProjeKod());
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                int projeNo = int.Parse(dr["ProjeNo"].ToString());
                int markaId = int.Parse(dr["MarkaId"].ToString());
                string projeKod = dr["kod"].ToString();
                int projeKodId = int.Parse(dr["ProjeKodId"].ToString());
                comboListBoxProjeKodu.AddDataRow(projeKodId, projeKod);
            }
            return "";
        }
        /// <summary>
        /// Fatura no combolisti satınalma fatura numaraları ile doldurulur.
        /// </summary>
        public async Task<string> FillComboListFaturaNo()
        {
            SatinalmaFatura satinalmaFatura = new SatinalmaFatura();
            string data = WebMethods.GetFilteredSatinalmaFatura(satinalmaFatura);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(data);
            data = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(data);
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                string faturaNo = dr["FaturaNo"].ToString();
                int faturaId = int.Parse(dr["SatinalmaFaturaId"].ToString());
            }
            return "";
        }
        /// <summary>
        /// Alan veri kontrolleri yapılır. Eksik veri girilmişse doldurulması için hata mesajı gösterir.
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            bool result = true;
            labelProjeKodUyari.Text = (comboListBoxProjeKodu.selectedDataRowId == -1) ? "Proje kodu seçilmelidir!" : "";
            labelTerminUyari.Text = (string.IsNullOrWhiteSpace(textBoxTermin.TextCustom)) ? "Termin süresi girilmeli" : "";
            labelSiparisTarihiUyari.Text = (string.IsNullOrWhiteSpace(textBoxSiparisTarihi.TextCustom)) ? "Sipariş tarihi seçilmeli" : "";
            labelVadeUyari.Text = (string.IsNullOrWhiteSpace(textBoxVade.TextCustom)) ? "Vade süresi girilmeli!" : "";
            labelFirmaUyari.Text = (comboListBoxFirmaId.selectedDataRowId == -1) ? "Firma seçilmelidir!" : "";
            labelSiparisTutariUyari.Text = (string.IsNullOrWhiteSpace(textBoxTutar.TextCustom)) ? "Sipariş tutarı girilmeli" : "";
            if (labelProjeKodUyari.Text != ""
                || labelTerminUyari.Text != ""
                || labelSiparisTarihiUyari.Text != ""
                || labelVadeUyari.Text != ""
                || labelFirmaUyari.Text != ""
                || labelSiparisTutariUyari.Text != "") result = false;
            return result;
        }
        /// <summary>
        /// Alan kontrollerini yapar ve hata yoksa fomdaki verileri veritabanına kaydeder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                SatinalmaSiparis satinalmaSiparis = new SatinalmaSiparis();
                satinalmaSiparis = GetCurrentSatinalmaSiparis();
                string result = await WebMethods.SaveSatinalmaSiparis(satinalmaSiparis);
                if (result.Length > 6 && result.Substring(0, 5) == "error")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                    string json = Encoding.UTF8.GetString(bytes);
                    DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                    MessageBox.Show("Sipariş kaydedildi.");
                    CloseForm();
                }
            }
        }
        /// <summary>
        /// Alan kontrollerini yapar ve hata yoksa fomdaki verileri veritabanında günceller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                SatinalmaSiparis satinalmaSiparis = new SatinalmaSiparis();
                satinalmaSiparis = GetCurrentSatinalmaSiparis();
                string result = await WebMethods.UpdateSatinalmaSiparis(satinalmaSiparis);
                if (result.Length > 6 && result.Substring(0, 5) == "error")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                    string json = Encoding.UTF8.GetString(bytes);
                    DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                    MessageBox.Show("Sipariş güncellendi.");
                    CloseForm();
                }
            }
        }
        /// <summary>
        /// Update ya da save yapmadan önce form üzerindeki verileri SatinalmaSiparis nesnesine doldurur.
        /// </summary>
        /// <returns></returns>
        public SatinalmaSiparis GetCurrentSatinalmaSiparis()
        {
            return new SatinalmaSiparis()
            {
                satinalmaSiparisId = _satinalmaSiparisId,
                projeKod = new Models.Proje()
                {
                    Id = comboListBoxProjeKodu.selectedDataRowId
                },
                termin = int.Parse(textBoxTermin.TextCustom.ToString()),
                siparisTarihi = DateTime.Parse(textBoxSiparisTarihi.TextCustom.ToString()),
                vade = int.Parse(textBoxVade.TextCustom.ToString()),
                firma = new Firma()
                {
                    Id = comboListBoxFirmaId.selectedDataRowId
                },

                tutar = new Tutar()
                {
                    tutar = float.Parse(textBoxTutar.TextCustom.ToString()),
                    dovizCinsi = new DovizCinsi()
                    {
                        id = comboListBoxTutarDovizCinsi.selectedDataRowId
                    }
                },
                avans = new Tutar()
                {
                    tutar = float.TryParse(textBoxAvans.TextCustom.ToString(), out float tryTutar) ? tryTutar : 0,
                    dovizCinsi = new DovizCinsi()
                    {
                        id = comboListBoxAvansDovizCinsi.selectedDataRowId
                    }
                },
                siparisAciklamasi = textBoxAciklama.TextCustom.ToString(),
                kdv = new KDV()
                {
                    kdvId = comboListBoxkdv.selectedDataRowId
                }
            };
        }
        /// <summary>
        /// SatinalmaFaturaGridForm'unu açar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSatinalmaFaturaGrid_Click(object sender, EventArgs e)
        {
            SatinalmaFaturaGridForm satinalmaFaturaGridFormu = SatinalmaFaturaGridForm.satinalmaFaturaGridForm;
            if (satinalmaFaturaGridFormu != null)
            {
                satinalmaFaturaGridFormu.Show();
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

        private void buttonFirmaEkle_Click(object sender, EventArgs e)
        {
            FirmaKayitFormu firmaKayitFormu = FirmaKayitFormu.firmaKayitFormu;
            if (firmaKayitFormu != null)
            {
                firmaKayitFormu.Show();
                firmaKayitFormu.SaveMode();
            }
            
        }

        private void buttonProjeKoduEkle_Click(object sender, EventArgs e)
        {
            SatisProjeKayitFormu satisProjeKayitFormu = SatisProjeKayitFormu.satisProjeKayitFormu;
            if (satisProjeKayitFormu != null)
            {
                satisProjeKayitFormu.Show();
                satisProjeKayitFormu.SaveMode();
            }
            
        }

        private void panelSatinalmaSiparisMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
