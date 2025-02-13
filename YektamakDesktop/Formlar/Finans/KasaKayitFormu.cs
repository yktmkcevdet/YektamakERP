using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class KasaKayitFormu : Form, IForm
    {
        #region declarations
        private static KasaKayitFormu _kasaKayitFormu;
        public static KasaKayitFormu kasaKayitFormu
        {
            get
            {
                if (_kasaKayitFormu == null)
                {
                    _kasaKayitFormu = new KasaKayitFormu();
                    GlobalData.Yetki(ref _kasaKayitFormu);
                }
                return _kasaKayitFormu;
            }

        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }

        private Kasa _kasaToUpdate;
        public Kasa kasaToUpdate { get { if (_kasaToUpdate == null) { _kasaToUpdate = new(); } return _kasaToUpdate; } set { _kasaToUpdate = value; } }
        private Kasa _kasaToSave;
        public Kasa kasaToSave { get { if (_kasaToSave == null) { _kasaToSave = new(); } return _kasaToSave; } set { _kasaToSave = value; } }
    
        #endregion declarations
        public KasaKayitFormu()
        {
            InitializeComponent();
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    customComboListBoxDovizTuru.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
            //foreach (BankaHesabi bankaHesabi in GlobalData.bankaHesabiList)
            //{
            //    customComboListBoxBankaHesabi.AddDataRow(bankaHesabi.hesapId, bankaHesabi.hesapAdi);
            //}
            //foreach (KasaTuru tur in Enum.GetValues(typeof(KasaTuru)))
            //{
            //    customComboListBoxKasaTuru.AddDataRow((int)tur, Enum.GetName(typeof(KasaTuru), tur));
            //}
            controlsToDisable = new List<Control>();
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

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm(sender,e);
        }
        private void CloseForm(object sender,EventArgs e)
        {
            GetCurrentKasa();
            if (!GlobalData.CompareClass(kasaToSave, kasaToUpdate))
            {
                DialogResult dialogResult = MessageBox.Show("Formda yapılan değişiklikler kaydedilsin mi", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rButtonKaydet_Click(sender, e);
                }
                else
                {
                    GlobalData.CloseForm(ref _kasaKayitFormu);
                }
            }
            else
            {
                GlobalData.CloseForm(ref _kasaKayitFormu);
            }
        }
        public void SaveMode()
        {
            rButtonGuncelle.Visible = false;
        }
        public void UpdateMode(Kasa kasa)
        {
            rButtonGuncelle.Visible = true;
            kasaToUpdate = kasa;
            customTextBoxHesapAdi.TextCustom = kasa.kasaAdi;
            customComboListBoxDovizTuru.SelectDataRowId(kasa.bakiye.dovizCinsi.id);
            customTextBoxBakiye.TextCustom = kasa.bakiye.tutar.ToString();
            customComboListBoxKasaTuru.SelectDataRowId((int)kasa.kasaTuru);
            customComboListBoxBankaHesabi.SelectDataRowId(kasa.bankaHesabi.hesapId);
            GetCurrentKasa();
            kasaToUpdate = JsonConvert.DeserializeObject<Kasa>(JsonConvert.SerializeObject(kasaToSave));
        }
        public void GetCurrentKasa()
        {
            kasaToSave.kasaId=kasaToUpdate.kasaId;
            kasaToSave.kasaAdi = customTextBoxHesapAdi.TextCustom;
            kasaToSave.bakiye.tutar = float.TryParse(customTextBoxBakiye.TextCustom.ToString(), out float tutar)?tutar:0;
            kasaToSave.bakiye.dovizCinsi.id = customComboListBoxDovizTuru.selectedDataRowId;
            kasaToSave.bakiye.dovizCinsi.sembol = customComboListBoxDovizTuru.selectedDataRowValue;
            kasaToSave.bankaHesabi.hesapId = customComboListBoxBankaHesabi.selectedDataRowId;
            kasaToSave.bankaHesabi.hesapAdi = customComboListBoxBankaHesabi.selectedDataRowValue;
            kasaToSave.kasaTuru = (KasaTuru)customComboListBoxKasaTuru.selectedDataRowId;
        }
        private bool CheckFields()
        {
            bool result = true;
            result = result & GlobalData.CheckField("*Kasa Türü seçilmelidir!", this, customComboListBoxKasaTuru);
            result = result & GlobalData.CheckField("*Döviz türü seçilmelidir!", this, customComboListBoxDovizTuru);
            result = result & GlobalData.CheckField("*Hesap adı girilmelidir!", this, customTextBoxHesapAdi);
            if (customComboListBoxKasaTuru.selectedDataRowId == (int)KasaTuru.BANKAHESABI)
            {
                result = result & GlobalData.CheckField("*Banka hesabı seçilmelidir!", this, customComboListBoxBankaHesabi);
            }
            return result;
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                GetCurrentKasa();
                string result = await WebMethods.SaveKasa(kasaToSave);
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    IDataTableHelper dataTableConverter = new DataTableHelper();
                    IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                    DataSet dataSet = jsonConverter.JsonStringToDataSet(result);
                    kasaToSave = dataTableConverter.DataRowToModel<Kasa>(dataSet.Tables[0].Rows[0]);
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(KasaTanimlariGridForm))
                    {
                        KasaTanimlariGridForm.kasaTanimlariGridForm.UpdateRow(kasaToSave);
                    }
                    MessageBox.Show("Kasa kaydedildi", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateMode(kasaToSave);
                }
            }
        }
        
        private void customComboListBoxKasaTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((KasaTuru)customComboListBoxKasaTuru.selectedDataRowId == KasaTuru.BANKAHESABI)
            {
                labelBankaHesabi.Visible = true;
                label8.Visible = true;
                customComboListBoxBankaHesabi.Visible = true;
            }
            else
            {
                labelBankaHesabi.Visible = false;
                label8.Visible = false;
                customComboListBoxBankaHesabi.Visible = false;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm(sender, e);
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
