using YektamakDesktop.Formlar.Genel;
using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.TedarikciIade
{
    public partial class TedarikciIadeFaturaKayitFormu : Form, IForm
    {
        private WebMethods _webMethods;
        private static TedarikciIadeFaturaKayitFormu _tedarikciIadeFaturaKayitFormu;
        public static TedarikciIadeFaturaKayitFormu tedarikciIadeFaturaKayitFormu
        {
            get
            {
                if (_tedarikciIadeFaturaKayitFormu == null)
                {
                    _tedarikciIadeFaturaKayitFormu = new TedarikciIadeFaturaKayitFormu();
                    GlobalData.Yetki(ref _tedarikciIadeFaturaKayitFormu);
                }
                return _tedarikciIadeFaturaKayitFormu;
            }
        }
        private TedarikciIadeFatura _tedarikciIadeFatura;
        public TedarikciIadeFatura tedarikciIadeFatura
        {
            get
            {
                if (_tedarikciIadeFatura == null)
                {
                    _tedarikciIadeFatura = new TedarikciIadeFatura();
                }
                return _tedarikciIadeFatura;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private List<Models.Proje> _orderedProjeKodList;
        private int _tedarikciIadeFaturaId;
        public TedarikciIadeFaturaKayitFormu()
        {
            InitializeComponent();
            //foreach (CariKart cariKart in GlobalData.cariKartList)
            //{
            //    comboListBoxCariKartId.AddDataRow(cariKart.cariKartId, cariKart.cariAdi);
            //}
            //foreach (KDV kDV in GlobalData.kdvList)
            //{
            //    comboListBoxkdv.AddDataRow(kDV.kdvId, kDV.kdvOrani.ToString());
            //}
            //comboListBoxkdv.SelectDataRowId(4);
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    comboListBoxTutarDovizCinsi.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
            comboListBoxTutarDovizCinsi.SelectDataRowId(3);
            controlsToDisable = new List<Control>();
            foreach (Control control in panelTedarikciIadeFaturaMain.Controls)
            {
                if (control.Name != "panelHeader")
                {
                    controlsToDisable.Add(control);
                }
            }
        }

        public TedarikciIadeFaturaKayitFormu(WebMethods webMethods)
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
        public async Task SaveMode()
        {
            this.Enabled = false;
            await LoadOrderedProjeKod();
            foreach (Models.Proje projeKod in _orderedProjeKodList)
            {
                comboListBoxProjeKodu.AddDataRow(projeKod.Id, projeKod.kod);
            }
            rButtonGuncelle.Visible = false;
            rButtonKaydet.Visible = true;
            this.Enabled = true;
        }
        public async Task UpdateMode(TedarikciIadeFatura tedarikciIadeFatura)
        {
            this.Enabled = false;
            await LoadOrderedProjeKod();
            foreach (Models.Proje projeKod in _orderedProjeKodList)
            {
                comboListBoxProjeKodu.AddDataRow(projeKod.Id, projeKod.kod);
            }
            rButtonGuncelle.Visible = true;
            rButtonKaydet.Visible = false;
            _tedarikciIadeFaturaId = tedarikciIadeFatura.tedarikciIadeFaturaId;
            comboListBoxProjeKodu.SelectDataRowId(tedarikciIadeFatura.projeKod.Id);
            comboListBoxCariKartId.SelectDataRowId(tedarikciIadeFatura.cariKart.cariKartId);
            comboListBoxkdv.SelectDataRowId(tedarikciIadeFatura.kdv.kdvId);
            comboListBoxTutarDovizCinsi.SelectDataRowId(tedarikciIadeFatura.tedarikciIadeFaturaTutari.dovizCinsi.id);
            textBoxFaturaNo.TextCustom = tedarikciIadeFatura.tedarikciIadeFaturaNo;
            textBoxFaturaTarihi.TextCustom = tedarikciIadeFatura.tedarikciIadeFaturaTarihi.ToString("dd.MM.yyyy");
            textBoxFaturaTutari.TextCustom = tedarikciIadeFatura.tedarikciIadeFaturaTutari.tutar.ToString();
            this.Enabled = true;
        }
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            GlobalData.RemoveLastForm();
            this.Close();
            _tedarikciIadeFaturaKayitFormu = null;
            TedarikciIadeFaturaGridForm tedarikciIadeFaturaGridForm = TedarikciIadeFaturaGridForm.tedarikciIadeFaturaGridForm;
            //tedarikciIadeFaturaGridForm.buttonTumKayitlariGetir_Click(this, null);
        }
        public TedarikciIadeFatura GetCurrentTedarikciIadeFatura()
        {
            tedarikciIadeFatura.tedarikciIadeFaturaId = _tedarikciIadeFaturaId;
            tedarikciIadeFatura.projeKod.Id = comboListBoxProjeKodu.selectedDataRowId;
            tedarikciIadeFatura.cariKart.cariKartId = comboListBoxCariKartId.selectedDataRowId;
            tedarikciIadeFatura.tedarikciIadeFaturaNo = textBoxFaturaNo.TextCustom;
            tedarikciIadeFatura.tedarikciIadeFaturaTarihi = DateTime.Parse(textBoxFaturaTarihi.TextCustom.ToString());
            tedarikciIadeFatura.tedarikciIadeFaturaTutari.tutar = float.Parse(textBoxFaturaTutari.TextCustom.ToString());
            tedarikciIadeFatura.tedarikciIadeFaturaTutari.dovizCinsi.id = comboListBoxTutarDovizCinsi.selectedDataRowId;
            tedarikciIadeFatura.kdv.kdvId = comboListBoxkdv.selectedDataRowId;
            return tedarikciIadeFatura;
        }
        private bool CheckFields()
        {
            bool result = true;
            if (comboListBoxProjeKodu.selectedDataRowId == -1)
            {
                labelProjeKodUyari.Text = "Proje kodu seçimi yapılmalıdır!";
                result = false;
            }
            if (comboListBoxCariKartId.selectedDataRowId == -1)
            {
                labelFirmaUyari.Text = "Tedariki seçimi yapılmalıdır!";
                result = false;
            }
            if (string.IsNullOrWhiteSpace(textBoxFaturaNo.TextCustom))
            {
                labelFaturaNoUyari.Text = "Fatura numarası yazılmalıdır!";
                result = false;
            }
            if (string.IsNullOrWhiteSpace(textBoxFaturaTarihi.TextCustom))
            {
                labelFaturaTarihiUyari.Text = "Faura tarihi verilmelidir!";
                result = false;
            }
            if (string.IsNullOrWhiteSpace(textBoxFaturaTutari.TextCustom))
            {
                labelFaturaTutariUyari.Text = "Fatura tutarı yazılmalıdır!";
                result = false;
            }
            return result;
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            //if (CheckFields())
            //{
            //    try
            //    {
            //        GetCurrentTedarikciIadeFatura();
            //        var result = await _webMethods.SaveTedarikciIadeFatura(tedarikciIadeFatura);
            //        if (result.Length > 6 && result.Substring(0, 5) == "error")
            //        {
            //            MessageBox.Show(result);
            //        }
            //        else
            //        {
            //            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
            //            string json = Encoding.UTF8.GetString(bytes);
            //            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            //            MessageBox.Show("Kayıt başarılı");
            //            CloseForm();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //}
        }
        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            //if (CheckFields())
            //{
            //    try
            //    {
            //        GetCurrentTedarikciIadeFatura();
            //        var result = await WebMethods.SaveTedarikciIadeFatura(tedarikciIadeFatura);
            //        if (result.Length > 6 && result.Substring(0, 5) == "error")
            //        {
            //            MessageBox.Show(result);
            //        }
            //        else
            //        {
            //            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
            //            string json = Encoding.UTF8.GetString(bytes);
            //            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            //            MessageBox.Show("Kayıt başarı ile güncellendi");
            //            CloseForm();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //}
        }
        /// <summary>
        /// Sipariş açılmış proje kodu listesini veritabanından alır.
        /// </summary>
        /// <returns></returns>
        private async Task<string> LoadOrderedProjeKod()
        {
            string resultOrderedProjeKod = await _webMethods.GetAllOrderedProjeKod(); ;

            if (resultOrderedProjeKod.Length > 6 && resultOrderedProjeKod.Substring(0, 5) == "error")
            {
                MessageBox.Show(resultOrderedProjeKod);
            }
            else
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return "";
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void comboListBoxCariKartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboListBoxTutarDovizCinsi.SelectDataRowId(GlobalData.cariKartList.Where(x => x.cariKartId == comboListBoxCariKartId.selectedDataRowId).First().guncelCari.dovizCinsi.id);
            comboListBoxTutarDovizCinsi.Enabled = false;
        }
    }
}
