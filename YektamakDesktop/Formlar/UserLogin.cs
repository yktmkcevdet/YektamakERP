using ApiService;
using Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar
{
    public partial class UserLogin : Form
    {
        private readonly ICache _cache;
        public UserLogin(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
        }
        public bool loginStatus { get; private set; }
        private bool newPasswordMode = false;
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
            return hashedPassword == storedHash;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Enter'a basıldığında giriş butonuna basılmış gibi işlemleri yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KullaniciGiris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginProcedures();
            }
            if (e.KeyChar == (char)Keys.F1)
            {
            }
        }
        /// <summary>
        /// Kullanıcı adı ve şifre girildikten sonra giriş işlemlerini yapar. 
        /// Şifre ilk kez kullanılıyorsa şifre yenileme alanlarını görünür yapar.
        /// </summary>
        private void LoginProcedures()
        {
            GlobalData.HandleException(async () =>
            {
                if (!CheckFields()) return;
                this.Enabled = false;
                string storedHashPassword = "";
                string password = customTextBoxSifre.TextCustom;

				Kullanici user = new Kullanici();
                user.ad = customTextBoxKullaniciAdi.TextCustom;
                string jsonString = WebMethods.GetKullanici(user);
                IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                DataSet dataSet = jsonConverter.JsonStringToDataSet(jsonString);
                
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    storedHashPassword = dataSet.Tables[0].Rows[0]["sifre"].ToString();
                    user.Id = int.Parse(dr["Id"].ToString());
                    user.salt = dr["salt"].ToString();
                    user.sifre= GlobalData.HashPassword(customTextBoxSifre.TextCustom, user.salt);
                    user.personel = new Personel();
                    user.personel.Id = int.Parse(dr["personel_Id"].ToString());
                    user.personel.mail = dr["Mail"].ToString();
                    user.rolId = int.Parse(dr["rolId"].ToString());
                    user.isSifreDegisti = int.TryParse(dr["IsSifreDegisti"].ToString(), out int isSifreDegistiInt)
                             ? isSifreDegistiInt == 1
                             : false;
                }
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
                this.Enabled = true;
            });
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
            GlobalData.ClearWarningLabels(this);
            bool result = true;
            result &= GlobalData.CheckField("* Kullanıcı adı girilmelidir!", this, customTextBoxKullaniciAdi);
            result &= GlobalData.CheckField("* Şifre girilmelidir!", this, customTextBoxSifre);
            
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
                this.panelHeader.Width += 100;
                this.buttonHelp.Location = new Point(this.buttonHelp.Location.X + 100, this.buttonHelp.Location.Y);
                this.buttonClose.Location = new Point(this.buttonClose.Location.X + 100, this.buttonClose.Location.Y);
            }
            else
            {
                this.Width -= 100;
                this.panelHeader.Width -= 100;
                this.buttonHelp.Location = new Point(this.buttonHelp.Location.X - 100, this.buttonHelp.Location.Y);
                this.buttonClose.Location = new Point(this.buttonClose.Location.X - 100, this.buttonClose.Location.Y);
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
                string salt = GlobalData.GenerateSalt();
                string password = customTextBoxYeniSifre.TextCustom;
                string hashedPassword = GlobalData.HashPassword(password, salt);

                kullanici.sifre = hashedPassword;
                kullanici.salt = salt;
                kullanici.isSifreDegisti = true;
                string httpResult = WebMethods.SaveKullanici(kullanici);
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
                customTextBoxKullaniciAdi.isPlaceHolder = false;
                customTextBoxKullaniciAdi.TextCustom = Properties.Settings.Default.KullaniciAdi;
            }
        }
    }
}
