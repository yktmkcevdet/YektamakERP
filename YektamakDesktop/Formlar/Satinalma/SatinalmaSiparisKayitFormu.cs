using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma.DataControl;
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

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaSiparisKayitFormu : Form, IForm
    {
        public CustomDataGrid<DataControlSatinalmaSiparisDetay> customDataGrid;
        private static SatinalmaSiparisKayitFormu _satinalmaSiparisKayitFormu;
        public static SatinalmaSiparisKayitFormu satinalmaSiparisKayitFormu { get { if (_satinalmaSiparisKayitFormu == null) { _satinalmaSiparisKayitFormu = new(); GlobalData.Yetki(ref _satinalmaSiparisKayitFormu); } return _satinalmaSiparisKayitFormu; } set { _satinalmaSiparisKayitFormu = value; } }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private SatinalmaSiparis _satinalmaSiparisToSave;
        public SatinalmaSiparis satinalmaSiparisToSave { get { if (_satinalmaSiparisToSave == null) { _satinalmaSiparisToSave = new(); } return _satinalmaSiparisToSave; } set { _satinalmaSiparisToSave = value; } }
        private SatinalmaSiparis _satinalmaSiparisToUpdate;
        public SatinalmaSiparis satinalmaSiparisToUpdate { get { if (_satinalmaSiparisToUpdate == null) { _satinalmaSiparisToUpdate = new(); } return _satinalmaSiparisToUpdate; } set { _satinalmaSiparisToUpdate = value; } }
        public SatinalmaSiparisKayitFormu()
        {
            InitializeComponent();
            customDataGrid = new CustomDataGrid<DataControlSatinalmaSiparisDetay>(2, 34, new Point(31, 530), new Size(892, 200));
            this.Controls.Add(customDataGrid.headerPanel);
            this.Controls.Add(customDataGrid.detailPanel);
            //GlobalData.ComboDovizCinsi(comboListBoxAvansDoviz);
            //GlobalData.ComboDovizCinsi(customComboListBoxTutarDoviz);
            //GlobalData.ComboKdv(comboListBoxKdv);
            //GlobalData.ComboFirma(comboListBoxFirma);
            //GlobalData.ComboProjeKodu(comboListBoxProjeKodu);
            //GlobalData.ComboTalepTip(comboListBoxTalepTip);
        }
        #region MouseDrag
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
        #endregion MouseDrag
        public void SaveMode()
        {
            buttonGuncelle.Visible = false;
            GetCurrentSatinalmaSiparis();
            satinalmaSiparisToUpdate = JsonConvert.DeserializeObject<SatinalmaSiparis>(JsonConvert.SerializeObject(satinalmaSiparisToSave));
        }
        public void UpdateMode(SatinalmaSiparis satinalmaSiparis)
        {
            buttonGuncelle.Visible = true;
            satinalmaSiparisToUpdate = satinalmaSiparis;
            (satinalmaSiparisToUpdate.satinalmaSiparisId, satinalmaSiparis.satinalmaSiparisId) = (satinalmaSiparis.satinalmaSiparisId, satinalmaSiparisToUpdate.satinalmaSiparisId);
            customTextBoxSiparisNo.TextCustom = satinalmaSiparis.siparisNo;
            comboListBoxProjeKodu.SelectDataRowId(satinalmaSiparis.projeKod.Id);
            customTextBoxSayisalTermin.TextCustom = satinalmaSiparis.termin.ToString();
            customTextBoxSayisalVade.TextCustom = satinalmaSiparis.vade.ToString();
            customTextBoxSayisalAvans.TextCustom = satinalmaSiparis.avans.tutar.ToString();
            comboListBoxAvansDoviz.SelectDataRowId(satinalmaSiparis.avans.dovizCinsi.id);
            customTextBoxSayisalTutar.TextCustom = satinalmaSiparis.tutar.tutar.ToString();
            customComboListBoxTutarDoviz.SelectDataRowId(satinalmaSiparis.tutar.dovizCinsi.id);
            customTextBoxTarihSiaprisTarihi.TextCustom = satinalmaSiparis.siparisTarihi.ToString();
            comboListBoxFirma.SelectDataRowId(satinalmaSiparis.firma.Id);
            customTextBoxAciklama.TextCustom = satinalmaSiparis.siparisAciklamasi;
            comboListBoxKdv.SelectDataRowId(satinalmaSiparis.kdv.kdvId);
            comboListBoxTalepTip.SelectDataRowId(satinalmaSiparis.talepTip.talepTipId);
            List<DataControlSatinalmaSiparisDetay> dataControlSatinalmaSiparisDetayList = new();
            foreach (SatinalmaSiparisDetay satinalmaSiparisDetay in satinalmaSiparis.satinalmaSiparisDetayList)
            {
                DataControlSatinalmaSiparisDetay controlSatinalmaSiparisDetay = new();
                controlSatinalmaSiparisDetay.satinalmaSiparisDetayId.TextCustom = satinalmaSiparisDetay.satinalmaSiparisDetayId.ToString();
                controlSatinalmaSiparisDetay.satinalmaSiparisId.TextCustom=satinalmaSiparisDetay.satinalmaSiparisId.ToString();
                controlSatinalmaSiparisDetay.stokKartId.SelectDataRowId(satinalmaSiparisDetay.stokKartId);
                controlSatinalmaSiparisDetay.miktar.TextCustom=satinalmaSiparisDetay.miktar.ToString();
                controlSatinalmaSiparisDetay.birimFiyat.TextCustom=satinalmaSiparisDetay.birimFiyat.ToString();
                controlSatinalmaSiparisDetay.dovizCinsiId.SelectDataRowId(satinalmaSiparisDetay.dovizCinsiId);
                dataControlSatinalmaSiparisDetayList.Add(controlSatinalmaSiparisDetay);

            }
            customDataGrid.dataSource = dataControlSatinalmaSiparisDetayList;
            GetCurrentSatinalmaSiparis();
            satinalmaSiparisToUpdate = JsonConvert.DeserializeObject<SatinalmaSiparis>(JsonConvert.SerializeObject(satinalmaSiparisToSave));
        }
        private bool CheckFields()
        {
            bool result = true;
            result = result & GlobalData.CheckField("*Tarih girilmelidir!", this, customTextBoxTarihSiaprisTarihi);
            result = result & GlobalData.CheckField("*Firma seçilmelidir!", this, comboListBoxFirma);
            result = result & GlobalData.CheckField("*Proje kodu seçilmelidir!", this, comboListBoxProjeKodu);
            result = result & GlobalData.CheckField("*Vade girilmelidir!", this, customTextBoxSayisalVade);
            result = result & GlobalData.CheckField("*Sipariş tutarı girilmelidir!", this, customTextBoxSayisalTutar);
            result = result & GlobalData.CheckField("*Sipariş tutarı döviz cinsi seçilmelidir!", this, customComboListBoxTutarDoviz);
            result = result & GlobalData.CheckField("*Kdv seçilmelidir!", this, customComboListBoxTutarDoviz);
            return result;
        }
        private void GetCurrentSatinalmaSiparis()
        {
            satinalmaSiparisToSave.satinalmaSiparisId=satinalmaSiparisToUpdate.satinalmaSiparisId;
            satinalmaSiparisToSave.siparisNo=customTextBoxSiparisNo.TextCustom;
            satinalmaSiparisToSave.projeKod.Id = comboListBoxProjeKodu.selectedDataRowId;
            satinalmaSiparisToSave.projeKod.kod = comboListBoxProjeKodu.selectedDataRowValue;
            satinalmaSiparisToSave.termin=int.TryParse(customTextBoxSayisalTermin.TextCustom,out int termin)?termin:0;
            satinalmaSiparisToSave.vade= int.TryParse(customTextBoxSayisalVade.TextCustom,out int vade)?vade:0;
            satinalmaSiparisToSave.avans.tutar=float.TryParse(customTextBoxSayisalAvans.TextCustom,out float avansTutar)? avansTutar : 0;
            satinalmaSiparisToSave.avans.dovizCinsi.id = comboListBoxAvansDoviz.selectedDataRowId;
            satinalmaSiparisToSave.avans.dovizCinsi.sembol = comboListBoxAvansDoviz.selectedDataRowValue;
            satinalmaSiparisToSave.tutar.tutar= float.TryParse(customTextBoxSayisalTutar.TextCustom,out float tutar)?tutar:0;
            satinalmaSiparisToSave.tutar.dovizCinsi.id=customComboListBoxTutarDoviz.selectedDataRowId;
            satinalmaSiparisToSave.tutar.dovizCinsi.sembol = customComboListBoxTutarDoviz.selectedDataRowValue;
            satinalmaSiparisToSave.siparisTarihi= DateTime.TryParse(customTextBoxTarihSiaprisTarihi.TextCustom,out DateTime siparisTarihi)?siparisTarihi:DateTime.MinValue;
            satinalmaSiparisToSave.firma.Id=comboListBoxFirma.selectedDataRowId;
            satinalmaSiparisToSave.firma.ad = comboListBoxFirma.selectedDataRowValue;
            satinalmaSiparisToSave.siparisAciklamasi = customTextBoxAciklama.TextCustom;
            satinalmaSiparisToSave.talepTip.talepTipId = comboListBoxTalepTip.selectedDataRowId;
            satinalmaSiparisToSave.talepTip.talepTipi = comboListBoxTalepTip.selectedDataRowValue;
            satinalmaSiparisToSave.kdv.kdvId=comboListBoxKdv.selectedDataRowId;
            satinalmaSiparisToSave.kdv.kdvOrani = Convert.ToInt32(comboListBoxKdv.selectedDataRowValue);
            satinalmaSiparisToSave.satinalmaSiparisDetayList.Clear();
            foreach (DataControlSatinalmaSiparisDetay dataControlTalep in customDataGrid.dataSource)
            {
                if (!dataControlTalep.newRec)
                {
                    SatinalmaSiparisDetay satinalmaSiparisDetay = new();
                    satinalmaSiparisDetay.satinalmaSiparisDetayId = int.TryParse(dataControlTalep.satinalmaSiparisDetayId.TextCustom,out int siparisDetayId)? siparisDetayId:0;
                    satinalmaSiparisDetay.satinalmaSiparisId = satinalmaSiparisToUpdate.satinalmaSiparisId;
                    satinalmaSiparisDetay.stokKartId = dataControlTalep.stokKartId.selectedDataRowId;
                    satinalmaSiparisDetay.miktar = float.TryParse(dataControlTalep.miktar.TextCustom, out float miktar) ? miktar : 0;
                    satinalmaSiparisDetay.birimFiyat= float.TryParse(dataControlTalep.birimFiyat.TextCustom,out float birimFiyat)?birimFiyat:0;
                    satinalmaSiparisDetay.dovizCinsiId = dataControlTalep.dovizCinsiId.selectedDataRowId;
                    satinalmaSiparisToSave.satinalmaSiparisDetayList.Add(satinalmaSiparisDetay);
                }
            }
        }
        private void buttonKapat_Click(object sender, EventArgs e)
        {
            CloseFrom(sender,e);
        }

        private void CloseFrom(object sender, EventArgs e)
        {
            GetCurrentSatinalmaSiparis();
            if (!GlobalData.CompareClass(satinalmaSiparisToSave, satinalmaSiparisToUpdate))
            {
                DialogResult dialogResult = MessageBox.Show("Formda yapılan değişiklikler kaydedilsin mi", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    buttonKaydet_Click(sender, e);
                }
                else
                {
                    GlobalData.CloseForm(ref _satinalmaSiparisKayitFormu);
                }
            }
            else
            {
                GlobalData.CloseForm(ref _satinalmaSiparisKayitFormu);
            }

        }

        private async void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                GetCurrentSatinalmaSiparis();
                string result = await WebMethods.SaveSatinalmaSiparis(satinalmaSiparisToSave);
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    IDataTableHelper dataTableConverter = new DataTableHelper();
                    IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                    DataSet dataSet = jsonConverter.JsonStringToDataSet(result);
                    satinalmaSiparisToSave = dataTableConverter.DataRowToModel<SatinalmaSiparis>(dataSet.Tables[0].Rows[0]);
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(SatinalmaSiparisGridForm))
                    {
                        SatinalmaSiparisGridForm.satinalmaSiparisGridForm.UpdateRow(satinalmaSiparisToSave);
                    }
                    MessageBox.Show("Sipariş kaydedildi", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateMode(satinalmaSiparisToSave);
                }
            }
        }
    }
}
