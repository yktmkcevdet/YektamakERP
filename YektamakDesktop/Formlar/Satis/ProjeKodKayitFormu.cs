using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class ProjeKodKayitFormu : Form, IForm
    {
        private static ProjeKodKayitFormu _projeKodKayitFormu;
        public static ProjeKodKayitFormu projeKodKayitFormu
        {
            get
            {
                if (_projeKodKayitFormu == null)
                {
                    _projeKodKayitFormu = new ProjeKodKayitFormu();
                    GlobalData.Yetki(ref _projeKodKayitFormu);
                }
                return _projeKodKayitFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private Models.Proje _projeKodToSave;
        public Models.Proje projeKodToSave
        {
            get { return _projeKodToSave; }
            set
            {
                _projeKodToSave = value;
            }
        }
        private Models.Proje _projeKodToUpdate;
        public Models.Proje projeKodToUpdate
        {
            get { return _projeKodToUpdate; }
            set { _projeKodToUpdate = value; }
        }
        private ProjeKodKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
                {
                    comboListBoxMarka,
                    comboListBoxAltUrunGrubu,
                    textBoxProjeNo,
                    rButtonKaydet,
                    rButtonGuncelle,
                    rButtonKapat
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
        /// <summary>
        /// Formu kapatır ve activeformstack listesinden siler.
        /// </summary>
        private void CloseForm()
        {
            GlobalData.RemoveLastForm();
            this.Close();
            _projeKodKayitFormu = null;
        }
        /// <summary>
        /// Formu yeni kayıt ekleme modunda açar. Güncelle butonunu pasif, akydet butonunu aktif eder. 
        /// Proje ön ekini boş yapar, marka listesini ve ürün grubunu listesini boşaltır. Marka listesini yeniden doldurur.
        /// </summary>
        public void SaveMode()
        {
            rButtonGuncelle.Enabled = false;
            rButtonGuncelle.Visible = false;
            rButtonKaydet.Enabled = true;
            rButtonKaydet.Visible = true;
            textBoxPrefix.Text = string.Empty;
            textBoxProjeNo.TextCustom = string.Empty;
            comboListBoxAltUrunGrubu.ClearListBox();
            comboListBoxMarka.ClearListBox();
            //for (int i = 0; i < GlobalData.markaList.Count; i++)
            //{
            //    comboListBoxMarka.AddDataRow(GlobalData.markaList[i].markaId, GlobalData.markaList[i].markaAd);
            //}
            projeKodToSave = new Models.Proje();
        }

        public void UpdateMode(Models.Proje projeKod)
        {
            rButtonGuncelle.Enabled = true;
            rButtonGuncelle.Visible = true;
            rButtonKaydet.Enabled = false;
            rButtonKaydet.Visible = false;
            //textBoxPrefix.Text = GlobalData.markaList.Find(m => m.markaId == projeKod.marka.markaId).prefix;
            textBoxProjeNo.TextCustom = projeKod.no.ToString();
            comboListBoxAltUrunGrubu.ClearListBox();
            comboListBoxMarka.ClearListBox();
            //for (int i = 0; i < GlobalData.markaList.Count; i++)
            //{
            //    comboListBoxMarka.AddDataRow(GlobalData.markaList[i].markaId, GlobalData.markaList[i].markaAd);
            //}
            comboListBoxMarka.SelectDataRowId(projeKod.marka.markaId);
            comboListBoxAltUrunGrubu.SelectDataRowId(projeKod.marka.markaAltGrup.altGrupId);
            projeKodToUpdate = projeKod;
        }
        /// <summary>
        /// Zorunlu alanlara giriş yapılmış mı kontrolünü yapar.
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            bool result = true;
            //Alanların boş olup olmadığını kontrol et.
            //Boşsa uyarı yazılarını yaz.
            if (comboListBoxMarka.selectedDataRowId < 0)
            {
                result = false;
                labelMarkaUyari.Text = "*Bir marka seçmelisiniz!";
            }
            else
            {
                labelMarkaUyari.Text = "";
                if (comboListBoxAltUrunGrubu.selectedDataRowId < 0)
                {
                    result = false;
                    labelAltGrupUyari.Text = "*Alt ürün gruplarından birini seçmelisiniz!";
                }
                else labelAltGrupUyari.Text = "";
            }
            if (string.IsNullOrWhiteSpace(textBoxProjeNo.TextCustom) || !IbanWorks.IsOnlyNumeric(textBoxProjeNo.TextCustom))
            {
                result = false;
                labelProjeNoUyari.Text = "*Yalnızca nümerik karakterlerden oluşan bir proje numarası belirtmelisiniz!";
            }
            else if (IbanWorks.CleanWhiteSpaces(textBoxProjeNo.TextCustom).Length > 4)
            {
                result = false;
                labelProjeNoUyari.Text = "*En fazla 4 basamaklı bir proje numarası belirtmelisiniz!";
            }
            else labelProjeNoUyari.Text = "";

            return result;
        }
        /// <summary>
        /// Alan kontrollerini yapar ve sorun yoksa formdaki verileri veritabanına kaydeder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                projeKodToSave.no = int.Parse(textBoxProjeNo.TextCustom);
                projeKodToSave.marka.markaId = comboListBoxMarka.selectedDataRowId;
                projeKodToSave.marka.markaAltGrup.altGrupId = comboListBoxAltUrunGrubu.selectedDataRowId;
                projeKodToSave.kod = projeKodToSave.ProjeKodString();

                //Bu aşamada veritabanına projekod kayıt edilip projekodid alınacak
                string result = await WebMethods.ProjeKodKaydet(projeKodToSave);
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Kayıt Başarılı");
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(SatisProjeKayitFormu))//SatisProjeKayitFormu tarafından çağırılmışsa
                    {
                        IDataTableHelper dataTableConverter = new DataTableHelper();
                        IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                        DataRow dataRow = jsonConverter.JsonStringToDataSet(result).Tables[0].Rows[0];
                        projeKodToSave = dataTableConverter.DataRowToModel<Models.Proje>(dataRow);
                        SatisProjeKayitFormu.satisProjeKayitFormu.ProjeKodEkle(projeKodToSave);
                    }
                    CloseForm();
                }

            }
        }
        /// <summary>
        /// Bu form için güncelleme işlemi yapılmamaktadır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {

                CloseForm();

            }
        }
        /// <summary>
        /// Marka seçimi değiştirildiğinde ürün alt grubu combolist'ine seçilen markanın alt gruplarını getirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void comboListBoxMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboListBoxMarka.selectedDataRowId > 0)
            {
                //textBoxPrefix.Text = GlobalData.markaList.Find(m => m.markaId == comboListBoxMarka.selectedDataRowId).prefix + "-";
                //foreach (MarkaAltGrup altGrup in GlobalData.markaAltGrupList)
                //{
                //    if (altGrup.markaId == comboListBoxMarka.selectedDataRowId)
                //    {
                //        comboListBoxAltUrunGrubu.AddDataRow(altGrup.altGrupId, altGrup.altGrupAd);
                //    }
                //}
                this.Enabled = false;
                Models.Proje proje = new Models.Proje();
                proje.Id = comboListBoxMarka.selectedDataRowId;
                string serializeString = WebMethods.MaxProjeNo(proje);
                IDataTableHelper dataTableConverter = new DataTableHelper();
                IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                DataSet dataset = jsonConverter.JsonStringToDataSet(serializeString);
                proje = dataTableConverter.DataRowToModel<Models.Proje>(dataset.Tables[0].Rows[0]);
                this.Enabled = true;
                textBoxProjeNo.TextCustom = (proje.Id + 1).ToString();
                projeKodToSave.marka.markaId = comboListBoxMarka.selectedDataRowId;
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

        private void rButtonGuncelle_Click_1(object sender, EventArgs e)
        {

        }
    }
}
