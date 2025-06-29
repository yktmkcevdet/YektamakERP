using ApiService;
using ApiService.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar
{
    public partial class UserLogin : Form,IForm
    {
        private readonly ICache _cache;
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IPasswordService _passwordService;
        private readonly IJsonConverter _jsonConverter;
        public UserLogin(ICache cache, IKullaniciYetkiService kullaniciYetkiService, IPasswordService passwordService, IJsonConverter jsonConverter)
        {
            InitializeComponent();
            _cache = cache;
            _kullaniciYetkiService = kullaniciYetkiService;
            _passwordService = passwordService;
            _jsonConverter = jsonConverter;
            GlobalData.AddNewForm(this);
            controlsToDisable = new List<Control>();
            var s = _cache.kullaniciListAsync();
        }
        
        public bool loginStatus { get; set; }
        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }

        private bool newPasswordMode = false;

        private void roundedButtonLogin_Click(object sender, EventArgs e)
        {
            LoginProcedures();
        }
        /// <summary>
        /// Girilen şifreyi veritabanında kayıtlı olan şifre ile karşılaştırır.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="storedHash"></param>
        /// <returns></returns>
        public bool VerifyPassword(Kullanici user, string storedHash)
        {
            string hashedPassword = user.sifre;
            //return hashedPassword == storedHash;
            return _passwordService.VerifyPassword(ctbSifre.TextCustom, storedHash);
        }
        /// <summary>
        /// Enter'a basıldığında giriş butonuna basılmış gibi işlemleri yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void KullaniciGiris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                await LoginProcedures();
            }
            if (e.KeyChar == (char)Keys.F1)
            {
            }
        }
        /// <summary>
        /// Kullanıcı adı ve şifre girildikten sonra giriş işlemlerini yapar. 
        /// Şifre ilk kez kullanılıyorsa şifre yenileme alanlarını görünür yapar.
        /// </summary>
        private async Task LoginProcedures()
        {
            try
            {
                if (!CheckFields()) return;
                this.Enabled = false;
                string storedHashPassword = "";
                string password = ctbSifre.TextCustom;

                Kullanici user = new Kullanici();
                user.ad = ctbKullaniciAdi.TextCustom;
                string jsonString = await _kullaniciYetkiService.GetKullaniciAsync(user);
                user = _jsonConverter.DeserializeToModelList<Kullanici>(jsonString)[0];
                storedHashPassword = user.sifre;
                user.sifre = GlobalData.HashPassword(ctbSifre.TextCustom, user.salt);
                if (VerifyPassword(user, storedHashPassword))
                {
                    if (user.isSifreDegisti == false && newPasswordMode == false)
                    {
                        InitializeComponentsNewPassword();

                    }
                    else if (newPasswordMode == true)
                    {
                        if (CheckFields())
                        {
                            CreateNewPassword(user);
                            OpenMainMenu(user);
                        }
                    }
                    else if (newPasswordMode == false)
                    {
                        OpenMainMenu(user);
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre hatalı");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }   
                this.Enabled = true;
        }
        /// <summary>
        /// Yeni şifre tanımlamak için program içinde dinamik olarak tanımlanan şifre textbox alanlarının passwordchar olarak gözükmesini sağlar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordChar(object sender, EventArgs e)
        {
            CustomTextBox customTextBox = (CustomTextBox)sender;
            if (customTextBox.TextCustom.Length > 0)
            {
                customTextBox.PasswordChar = true;
            }
        }
        private bool CheckFields()
        {
            bool result = true;
            result &= GlobalData.CheckField("* Kullanıcı adı girilmelidir!", this, ctbKullaniciAdi);
            result &= GlobalData.CheckField("* Şifre girilmelidir!", this, ctbSifre);
            
            if (newPasswordMode)
            {
                result &= ValidateField(customTextBoxYeniSifre.TextCustom, "* Yeni şifre girilmelidir!", labelUyariYeniSifre);

                if (customTextBoxYeniSifre.TextCustom != customTextBoxYeniSifreTekrar.TextCustom)
                    result &= SetErrorLabel("Girilen şifre uyuşmuyor!", labelUyariYeniSifreTekrar);
            }

            if (result == false) AdjustFormSize(result);

            return result;
        }
        /// <summary>
        /// Textbox alanlarına veri girilmiş mi kontrol eder, girilmemişse uyarı mesajını set eder.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMessage"></param>
        /// <param name="errorLabel"></param>
        /// <returns></returns>
        private bool ValidateField(string value, string errorMessage, Label errorLabel)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                SetErrorLabel(errorMessage, errorLabel);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Uyarı mesajını label'a yazar
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="errorLabel"></param>
        /// <returns></returns>
        private bool SetErrorLabel(string errorMessage, Label errorLabel)
        {
            errorLabel.Text = errorMessage;
            return false;
        }
        /// <summary>
        /// Şifre değiştirme alanaları gösterilirken form boyutunu ayarlar.
        /// </summary>
        /// <param name="validationResult"></param>
        private void AdjustFormSize(bool validationResult = true)
        {
            if (!validationResult)
            {
                this.Width += 100;
            }
            else
            {
                this.Width -= 100;
            }
        }
        /// <summary>
        /// Girilen kullanıcı adını bir dahaki açılış için saklar ve ana menünün açılmaısnı sağlar.
        /// </summary>
        /// <param name="kullanici"></param>
        private void OpenMainMenu(Kullanici kullanici)
        {
            Properties.Settings.Default.KullaniciAdi = kullanici.ad;
            Properties.Settings.Default.Save();
            _cache.kullanici = kullanici;
            loginStatus = true; // AnaSayfa formunun açıldığını işaretleyerek ana menünün açılmasını sağlar.
            this.Close();
        }
        /// <summary>
        /// Yeni şifrenin veritabanına kaydını sağlar.
        /// </summary>
        /// <param name="kullanici"></param>
        private void CreateNewPassword(Kullanici kullanici)
        {
            GlobalData.HandleException(async () =>
            {
                //string salt = GlobalData.GenerateSalt();
                
                string password = customTextBoxYeniSifre.TextCustom;
                string salt = _passwordService.HashPassword(password).Hash;
                //string hashedPassword = GlobalData.HashPassword(password, salt);
                string hashedPassword = _passwordService.HashPassword(password).CombinedHash;

                kullanici.sifre = hashedPassword;
                kullanici.salt = salt;
                kullanici.isSifreDegisti = true;
                string httpResult = _kullaniciYetkiService.SaveKullanici(kullanici);
                if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(httpResult);

                }
                else
                {
                    MessageBox.Show("Şifre değiştirildi");
                    //MailGonder(kullanici.personel.mail);
                    this.Close();
                }

            });
        }
        /// <summary>
        /// Form yüklenirken eğer daha önce kullanıcı adı ile giriş yapılmışsa daha önce girilmiş kullanıcı adını getirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLogin_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.KullaniciAdi))
            {
                ctbKullaniciAdi.isPlaceHolder = false;
                ctbKullaniciAdi.TextCustom = Properties.Settings.Default.KullaniciAdi;
            }
        }
    }
}
