using ApiService.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar
{
    public partial class UserLogin : Form
    {
        private readonly ICache _cache;
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IPasswordService _passwordService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IMailHandler _mailHandler;
        public UserLogin(ICache cache, IKullaniciYetkiService kullaniciYetkiService, IPasswordService passwordService, IJsonConverter jsonConverter, IMailHandler mailHandler)   
        {
            _cache = cache;
            _kullaniciYetkiService = kullaniciYetkiService;
            _passwordService = passwordService;
            _jsonConverter = jsonConverter;
            _mailHandler = mailHandler;
            InitializeComponent();
            var s = _cache.kullaniciListAsync();
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnSifreDegistir, "Şifre Değiştir");
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool loginStatus { get; set; }

        private bool newPasswordMode = false;
        private Kullanici _user;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Kullanici user
        {
            get { if (_user == null) { _user = new(); } return _user; }
            set
            {
                _user = value;
                Binding();
            }
        }
        private void Binding() 
        {
            //ctbKullaniciAdi.DataBindings.Clear();
            //ctbSifre.DataBindings.Clear();
            //ctbKullaniciAdi.DataBindings.Add("TextCustom", user, $"{nameof(user.ad)}", true, DataSourceUpdateMode.OnPropertyChanged);
            //ctbSifre.DataBindings.Add("TextCustom", user, $"{nameof(user.sifre)}", true, DataSourceUpdateMode.OnPropertyChanged);
        }   
        private void roundedButtonLogin_Click(object sender, EventArgs e)
        {
            LoginProcedures();
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
                string password = ctbSifre.TextCustom;
                user =new Kullanici();
                user.ad = ctbKullaniciAdi.TextCustom;
                user.sifre= ctbSifre.TextCustom;
                string jsonResult = await _kullaniciYetkiService.GetKullaniciAsync(user);
                if(String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre hatalı");
                    return;
                }
                user = JsonConvert.DeserializeObject<List<Kullanici>>(jsonResult).FirstOrDefault();
                if (_passwordService.VerifyPassword(password, user.sifre))
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
            finally
            {
                this.Enabled = true;
            }
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
            result &= CheckFieldHelper.CheckField("* Kullanıcı adı girilmelidir!", ctbKullaniciAdi);
            result &= CheckFieldHelper.CheckField("* Şifre girilmelidir!", ctbSifre);

            if (newPasswordMode)
            {
                result &= ValidateField(customTextBoxYeniSifre.TextCustom, "* Yeni şifre girilmelidir!", labelUyariYeniSifre);

                if (customTextBoxYeniSifre.TextCustom != customTextBoxYeniSifreTekrar.TextCustom)
                    result &= SetErrorLabel("Girilen şifre uyuşmuyor!", labelUyariYeniSifreTekrar);
            }
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
            try
            {
                string password = customTextBoxYeniSifre.TextCustom;
                string salt = _passwordService.HashPassword(password).Hash;
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
                    IMailHandler mailHandler = new MailHandler();
                    mailHandler.SendSystemMail(kullanici.personel.mail, "Şifre Değişimi", "Şifreniz değiştirilmiştir.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                Binding();
            }
        }

        private async void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            string password = ctbSifre.TextCustom;
            user = new Kullanici();
            user.ad = ctbKullaniciAdi.TextCustom;
            user.sifre = ctbSifre.TextCustom;
            string jsonResult = await _kullaniciYetkiService.GetKullaniciAsync(user);
            user = JsonConvert.DeserializeObject<List<Kullanici>>(jsonResult).FirstOrDefault();
            if (_passwordService.VerifyPassword(password, user.sifre))
            {
                InitializeComponentsNewPassword();
            }
            
        }
    }
}
