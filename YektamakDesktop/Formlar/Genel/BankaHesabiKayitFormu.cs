using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class BankaHesabiKayitFormu : Form, IForm
    {
        private static BankaHesabiKayitFormu _bankaHesabiKayitFormu;

        public static BankaHesabiKayitFormu bankaHesabiKayitFormu
        {
            get
            {
                if (_bankaHesabiKayitFormu == null)
                {
                    _bankaHesabiKayitFormu = new BankaHesabiKayitFormu();
                    GlobalData.Yetki(ref _bankaHesabiKayitFormu);
                }
                return _bankaHesabiKayitFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public BankaHesabi bankaHesabiToSave;
        public BankaHesabi bankaHesabiToUpdate = new();
        private BankaHesabiKayitFormu()
        {
            InitializeComponent();
            //for (int i = 0; i < GlobalData.dovizList.Count; i++)
            //{
            //    comboListBoxDovizTuru.AddDataRow(GlobalData.dovizList[i].id, GlobalData.dovizList[i].sembol);
            //}
            controlsToDisable = new List<Control>
            {
                rButtonGuncelle,
                rButtonKapat,
                rButtonKaydet,
                textBoxHesapAdi,
                textBoxIBAN,
                comboBoxBanka,
                comboListBoxDovizTuru
            };
        }
        #region mouseMove
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
        #endregion mouseMove


        private void textBoxIBAN_Load(object sender, EventArgs e)
        {
            textBoxIBAN.TextAlignment = HorizontalAlignment.Left;
        }

        public void SaveMode(Firma firma)
        {
            bankaHesabiToSave = new BankaHesabi();
            bankaHesabiToSave.firma.unvan = firma.unvan;
            bankaHesabiToSave.firma.id = firma.id;
            comboBoxHesapSahibiFirma.SelectDataRowId(firma.id);
            rButtonGuncelle.Visible = false;
            //for (int i = 0; i < GlobalData.bankaList.Count; i++)
            //{
            //    comboBoxBanka.AddDataRow(GlobalData.bankaList[i].id, GlobalData.bankaList[i].unvan);
            //}
        }
        public void UpdateMode(BankaHesabi bankaHesabi)
        {
            bankaHesabiToUpdate = bankaHesabi;
            comboBoxHesapSahibiFirma.SelectDataRowId(bankaHesabiToUpdate.firma.id);
            rButtonGuncelle.Visible = true;
            comboBoxBanka.SelectDataRowId(bankaHesabiToUpdate.banka.id);
            textBoxIBAN.TextCustom = bankaHesabiToUpdate.IBAN;
            textBoxHesapAdi.TextCustom = bankaHesabiToUpdate.hesapAdi;
            comboListBoxDovizTuru.SelectDataRowId(bankaHesabiToUpdate.dovizCinsi.id);
        }

        private bool CheckFields()
        {
            bool result = true;
            result = result & GlobalData.CheckField("*Hesap ismi boş bırakılamaz!", this, textBoxHesapAdi);
            result = result & GlobalData.CheckField("*IBAN numarası boş bırakılamaz!", this, textBoxIBAN);
            result = result & GlobalData.CheckField("*Kayıtlı bankalardan birini seçmelisiniz!", this, comboBoxBanka);
            result = result & GlobalData.CheckField("*Döviz türlerinden birini seçmelisiniz!", this, comboListBoxDovizTuru);
            if (IbanWorks.IbanCheck(textBoxIBAN.TextCustom, IbanPrefix.TR) != 0)
            {
                result = false;
                labelIBANUyari.Text = "*Girdiğiniz IBAN numarası geçerli değildir!";
            }
            return result;
        }
        private BankaHesabi GetCurrentBankaHesabi()
        {
            BankaHesabi bankaHesabi = new BankaHesabi();

            if (CheckFields())
            {
                bankaHesabi.hesapId = bankaHesabiToUpdate.hesapId;
                bankaHesabi.hesapAdi = textBoxHesapAdi.TextCustom;
                bankaHesabi.banka.id = comboBoxBanka.selectedDataRowId;
                bankaHesabi.banka.unvan = comboBoxBanka.selectedDataRowValue;
                bankaHesabi.firma.id = comboBoxHesapSahibiFirma.selectedDataRowId;
                bankaHesabi.firma.unvan = comboBoxHesapSahibiFirma.selectedDataRowValue;
                bankaHesabi.dovizCinsi.id = comboListBoxDovizTuru.selectedDataRowId;
                bankaHesabi.dovizCinsi.sembol = comboListBoxDovizTuru.selectedDataRowValue;
                bankaHesabi.IBAN = textBoxIBAN.TextCustom;
            }
            return bankaHesabi;
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            bankaHesabiToSave = GetCurrentBankaHesabi();
            if (bankaHesabiToSave == null)
            {
                return;
            }

            //if (bankaHesabiToSave != null)
            {
                this.Enabled = false;
                string result = await WebMethods.SaveBankaHesabi(bankaHesabiToSave);
                if (result.Contains("error",StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    IDataTableConverter dataTableConverter = new DataTableConverter();
                    IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                    //Firma kayıt formuna bankahesapId geri dönüyor
                    bankaHesabiToSave = dataTableConverter.DataRowToModel<BankaHesabi>(jsonConverter.JsonStringToDataSet(result).Tables[0].Rows[0]);
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(FirmaKayitFormu))//FirmaKayitFormu tarafından çağırılmışsa
                    {
                        FirmaKayitFormu.firmaKayitFormu.AddNewBankaHesabi(bankaHesabiToSave);
                    }
                    if (GlobalData.activeFormStack.Skip(2).First().GetType() == typeof(FirmaKayitFormu))//FirmaKayitFormu->BankaHesabiGridFormu->BankaHesabiKayitFormu şeklinde FirmaKayitFormundan çağırılmışsa
                    {
                        FirmaKayitFormu.firmaKayitFormu.AddNewBankaHesabi(bankaHesabiToSave);
                    }
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(BankaHesabiGridFormu))//BankaHesabiGridFormu tarafından çağırılmışsa
                    {
                        BankaHesabiGridFormu.bankaHesabiGridFormu.UpdateRow(bankaHesabiToSave);
                    }
                    UpdateMode(bankaHesabiToSave);
                }
                this.Enabled = true;
            }
            //Geriye hesapId dönen bir webmethod çağırmalıyız.
            //Diğer pencerede firmaToUpdate'in 
        }

        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                bankaHesabiToSave = GetCurrentBankaHesabi();
                this.Enabled = false;
                string result = await WebMethods.SaveBankaHesabi(bankaHesabiToSave);
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(FirmaKayitFormu))//FirmaKayitFormu tarafından çağırılmışsa
                    {
                        FirmaKayitFormu.firmaKayitFormu.AddNewBankaHesabi(bankaHesabiToSave);
                    }
                    if (GlobalData.activeFormStack.Skip(2).First().GetType() == typeof(FirmaKayitFormu))//FirmaKayitFormu->BankaHesabiGridFormu->BankaHesabiKayitFormu şeklinde FirmaKayitFormundan çağırılmışsa
                    {
                        FirmaKayitFormu.firmaKayitFormu.AddNewBankaHesabi(bankaHesabiToSave);
                    }
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(BankaHesabiGridFormu))//BankaHesabiGridFormu tarafından çağırılmışsa
                    {
                        BankaHesabiGridFormu.bankaHesabiGridFormu.UpdateRow(bankaHesabiToSave);
                    }
                    MessageBox.Show("Güncelleme Başarılı");
                    CloseForm();
                }
                this.Enabled = true;
            }
        }

        private void textBoxIBAN_TextChanged(object sender, EventArgs e)
        {
            int caretPos = textBoxIBAN.SelectionStart;
            int firstLength = textBoxIBAN.TextCustom.Length;
            int distanceToEnd = firstLength - caretPos;
            string textBeforeFormat = textBoxIBAN.TextCustom;
            textBoxIBAN.TextCustom = IbanWorks.GetFormattedIbanWithoutCheck(textBoxIBAN.TextCustom, IbanPrefix.TR);
            string textAfterFormat = textBoxIBAN.TextCustom;
            int lastLength = textBoxIBAN.TextCustom.Length;
            int targetPos = lastLength - distanceToEnd;

            textBoxIBAN.SelectionStart = Math.Max(Math.Min(caretPos + Math.Abs(lastLength - firstLength), lastLength), 0);

            // NOT : Şu an imleç text'in ortalarında bir yerdeyken yeni karakterler eklendiğinde,
            // formatlanmış metine ilave boşluklar geldiğinde imleç bir karakter fazladan ilerliyor
            //  müsait bir zamanda bu durumu da hesaba katan bir algoritma geliştirmek gerekior
        }
        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private async void CloseForm()
        {
            bankaHesabiToSave = GetCurrentBankaHesabi();
            if (!GlobalData.CompareClass(bankaHesabiToSave, bankaHesabiToUpdate))
            {
                DialogResult dialogResult = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    await WebMethods.SaveBankaHesabi(bankaHesabiToSave);
                }
            }

            GlobalData.CloseForm(ref _bankaHesabiKayitFormu);
        }

        private void BankaHesabiKayitFormu_Load(object sender, EventArgs e)
        {
            //if (GlobalData.firmaUnvanList != null)
            //{
            //    for (int i = 0; i < GlobalData.firmaUnvanList.Count; i++)
            //    {
            //        comboBoxHesapSahibiFirma.AddDataRow(GlobalData.firmaUnvanList[i].id, GlobalData.firmaUnvanList[i].unvan);
            //    }
            //}
            //comboBoxHesapSahibiFirma.Enabled = false;
            //if (GlobalData.bankaList != null)
            //{
            //    for (int i = 0; i < GlobalData.bankaList.Count; i++)
            //    {
            //        comboBoxBanka.AddDataRow(GlobalData.bankaList[i].id, GlobalData.bankaList[i].unvan);
            //    }
            //}
            
        }
    }
}
