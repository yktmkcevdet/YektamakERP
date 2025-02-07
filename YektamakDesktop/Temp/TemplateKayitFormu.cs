using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YektamakDesktop.Formlar.Temp
{
    public partial class SatisFaturaFormu : Form, IForm
    {   
        private static SatisFaturaFormu _satisFaturaFormu;

        public static SatisFaturaFormu satisFaturaFormu
        {
            get
            {
                if (_satisFaturaFormu == null)
                {
                    _satisFaturaFormu = new SatisFaturaFormu();
                    GlobalData.Yetki(ref _satisFaturaFormu);
                }
                return _satisFaturaFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private SatisFaturaFormu()
        {
            InitializeComponent();
            //for (int i = 0; i < GlobalData.dovizList.Count; i++)
            //{
            //    comboListBoxDovizTuru.AddDataRow(GlobalData.dovizList[i].id, GlobalData.dovizList[i].sembol);
            //}
            controlsToDisable = new List<Control>
            {

            };
        }
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

        private void CloseForm()
        {

        }

        private void textBoxIBAN_Load(object sender, EventArgs e)
        {

        }

        public void SaveMode(Firma firma)
        {

        }
        public void SaveMode(int firmaId, string firmaUnvan)
        {

        }
        public void UpdateMode(BankaHesabi bankaHesabi)
        {


        }

        private bool CheckFields()
        {
            bool result = true;
            //Alanların boş olup olmadığını kontrol et.
            //Boşsa uyarı yazılarını yaz.
            if (string.IsNullOrWhiteSpace(textBoxHesapAdi.TextCustom))
            {
                result = false;
                labelHesapAdiUyari.Text = "*Hesap ismi boş bırakılamaz!";
            }
            else labelHesapAdiUyari.Text = "";
            if (string.IsNullOrWhiteSpace(textBoxIBAN.TextCustom))
            {
                result = false;
                labelIBANUyari.Text = "*IBAN numarası boş bırakılamaz!";
            }
            else if (IbanWorks.IbanCheck(textBoxIBAN.TextCustom, IbanPrefix.TR) != 0)
            {
                result = false;
                labelIBANUyari.Text = "*Girdiğiniz IBAN numarası geçerli değildir!";
            }
            else labelIBANUyari.Text = "";
            if (comboListBoxBankalar.selectedDataRowId < 0)
            {
                result = false;
                labelBankaUyari.Text = "*Kayıtlı bankalardan birini seçmelisiniz!";
            }
            else labelBankaUyari.Text = "";
            if (comboListBoxDovizTuru.selectedDataRowId < 0)
            {
                result = false;
                labelDovizTuruUyari.Text = "*Döviz türlerinden birini seçmelisiniz!";
            }
            else labelDovizTuruUyari.Text = "";

            return result;
        }



        private void rButtonKaydet_Click(object sender, EventArgs e)
        {

        }

        private void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {

                CloseForm();

            }
        }

        private void textBoxIBAN_TextChanged(object sender, EventArgs e)
        {

        }
        private void roundedButton3_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }
    }
}
