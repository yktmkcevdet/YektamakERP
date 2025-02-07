using ApiService;
using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utilities.Implementations;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class KullaniciYeniSifreBelirlemeFormu : Form, IForm
    {
        
        public Kullanici kullanici;
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public KullaniciYeniSifreBelirlemeFormu()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rButtonKullaniciKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            GlobalData.HandleException(async () =>
            {
                string salt = GlobalData.GenerateSalt();
                string password = customTextBoxSifre.TextCustom;
                string hashedPassword = GlobalData.HashPassword(password, salt);

                kullanici.sifre = hashedPassword;
                kullanici.salt = salt;
                kullanici.isSifreDegisti= true;
                string httpResult = WebMethods.SaveKullanici(kullanici);
                if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(httpResult);

                }
                else
                {
                    MessageBox.Show("Şifre değiştirildi");
                    this.Close();
                    UserLogin kullaniciGiris = new UserLogin(new Cache(new JsonConvertHelper(),new DataTableConverter()));
                    kullaniciGiris.Show();
                }

            });
        }
        private bool CheckFields()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(customTextBoxSifre.TextCustom))
            {
                result = false;
                labelUyariSifre.Text = "Şifre girilmelidir!";
            }
            if (customTextBoxSifre.TextCustom != customTextBoxSifreTekrar.TextCustom)
            {
                result = false;
                labelUyariSifreTekrar.Text = "Şifre uyuşmuyor!";
            }
            return result;
        }
    }
}
