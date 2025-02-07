using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using Utilities.Implementations;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class CariKartKayitFormu : Form, IForm
    {
        private readonly GlobalData _globalData;
        #region declarations
        private static CariKartKayitFormu _cariKartKayitFormu;
        public static CariKartKayitFormu cariKartKayitFormu
        {
            get
            {
                if (_cariKartKayitFormu == null)
                {
                    _cariKartKayitFormu = new CariKartKayitFormu();
                    GlobalData.Yetki(ref _cariKartKayitFormu);
                }
                return _cariKartKayitFormu;
            }

        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private CariKart _cariKartToSave;
        public CariKart cariKartToSave { get { if (_cariKartToSave == null) { _cariKartToSave = new CariKart(); } return _cariKartToSave; } set { _cariKartToSave = value; } }
        private CariKart _cariKartToUpdate;
        public CariKart cariKartToUpdate{get{if (_cariKartToUpdate == null){_cariKartToUpdate = new CariKart();}return _cariKartToUpdate;}set{_cariKartToUpdate = value;}}
        #endregion declarations
        public CariKartKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>()
            {
                customComboListBoxCariTuru,
                customComboListBoxDovizTuru,
                customComboListBoxFirma,
                customTextBoxGuncelCari,
                customTextBoxHesapAdi,
                buttonClose,
                rButtonKaydet,
                rButtonGuncelle
            };
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    customComboListBoxDovizTuru.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
            foreach (CariTuru tur in Enum.GetValues(typeof(CariTuru)))
            {
                customComboListBoxCariTuru.AddDataRow((int)tur, Enum.GetName(typeof(CariTuru), tur));
            }
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
        /// Form üzerindeki verileri cariKartToSave nesnesine aktarır.
        /// </summary>
        private void GetCurrentCariKart()
        {
            cariKartToSave.cariKartId = cariKartToUpdate.cariKartId;
            cariKartToSave.cariAdi = customTextBoxHesapAdi.TextCustom;
            cariKartToSave.cari.cariTuru = (CariTuru)customComboListBoxCariTuru.selectedDataRowId;
            cariKartToSave.cari.Id = customComboListBoxFirma.selectedDataRowId;
            cariKartToSave.guncelCari.dovizCinsi.id = customComboListBoxDovizTuru.selectedDataRowId;
            cariKartToSave.guncelCari.dovizCinsi.sembol= customComboListBoxDovizTuru.selectedDataRowValue;
            cariKartToSave.guncelCari.tutar = float.TryParse(customTextBoxGuncelCari.TextCustom, out float result) ? result : 0;
        }
        /// <summary>
        /// Formu veri kaydetme moduna getirir.
        /// </summary>
        public void SaveMode()
        {
            rButtonGuncelle.Visible = false;
            GetCurrentCariKart();
            cariKartToUpdate = JsonConvert.DeserializeObject<CariKart>(JsonConvert.SerializeObject(cariKartToSave));
        }
        /// <summary>
        /// Formu veri güncelleme moduna getirir.
        /// </summary>
        /// <param name="cariKart"></param>
        public void UpdateMode(CariKart cariKart)
        {
            rButtonGuncelle.Visible = true;
            cariKartToUpdate = cariKart;
            customTextBoxHesapAdi.TextCustom = cariKart.cariAdi;
            int cariTuru = (int)cariKart.cari.cariTuru;
            customComboListBoxCariTuru.SelectDataRowId(cariTuru);
            customComboListBoxFirma.SelectDataRowId(cariKart.cari.Id);
            customComboListBoxDovizTuru.SelectDataRowId(cariKart.guncelCari.dovizCinsi.id);
            customTextBoxGuncelCari.TextCustom = cariKart.guncelCari.tutar.ToString("#,##0.00");
            GetCurrentCariKart();
            cariKartToUpdate = JsonConvert.DeserializeObject<CariKart>(JsonConvert.SerializeObject(cariKartToSave));
        }
        /// <summary>
        /// Formu kapatır, activeFormStack'ten çıkarır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm(sender, e);
        }
        /// <summary>
        /// Formu kapatır, activeFormStack'ten çıkarır.
        /// </summary>
        private void CloseForm(object sender, EventArgs e)
        {
            GetCurrentCariKart();
            if (!GlobalData.CompareClass(cariKartToSave, cariKartToUpdate))
            {
                DialogResult dialogResult = MessageBox.Show("Formda yapılan değişiklikler kaydedilsin mi", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rButtonKaydet_Click(sender, e);
                }
                else
                {
                    GlobalData.CloseForm(ref _cariKartKayitFormu);
                }
            }
            else
            {
                GlobalData.CloseForm(ref _cariKartKayitFormu);
            }
        }
        /// <summary>
        /// Form üzerindeki verileri alıp kaydetme işlemini yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                GetCurrentCariKart();
                string result=WebMethods.SaveCariKart(cariKartToSave);
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    IDataTableConverter dataTableConverter = new DataTableConverter();
                    IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                    DataSet dataSet = jsonConverter.JsonStringToDataSet(result);
                    cariKartToSave = dataTableConverter.DataRowToModel<CariKart>(dataSet.Tables[0].Rows[0]);
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(CariKartlarGridForm))
                    {
                        CariKartlarGridForm.cariKartlarGridForm.UpdateRow(cariKartToSave);
                    }
                    MessageBox.Show("Cari Kart kaydedildi", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //GlobalData.cariKartList.Add(cariKartToSave);
                    UpdateMode(cariKartToSave);
                }
            }
        }

        private bool CheckFields()
        {
            bool result = true;
            result = result & GlobalData.CheckField("*Cari Türü seçilmelidir!", this, customComboListBoxCariTuru);
            result = result & GlobalData.CheckField("*Firma seçilmelidir!", this, customComboListBoxFirma);
            result = result & GlobalData.CheckField("*Hesap adı girilmelidir!", this, customTextBoxHesapAdi);
            result = result & GlobalData.CheckField("*Döviz Türü seçilmelidir!", this, customComboListBoxDovizTuru);
            return result;
        }
        private void customComboListBoxCariTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            //customComboListBoxFirma.ClearListBox();
            //if ((CariTuru)customComboListBoxCariTuru.selectedDataRowId == CariTuru.PERSONEL)
            //{
            //    foreach (Personel personel in GlobalData.personelList)
            //    {
            //        customComboListBoxFirma.AddDataRow(personel.Id, personel.ad + " " + personel.soyad);
            //    }
            //}
            //if ((CariTuru)customComboListBoxCariTuru.selectedDataRowId == CariTuru.FIRMA)
            //{
            //    foreach (Firma firma in GlobalData.firmaUnvanList)
            //    {
            //        customComboListBoxFirma.AddDataRow(firma.id, firma.unvan);
            //    }
            //}
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            CloseForm(sender,e);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
