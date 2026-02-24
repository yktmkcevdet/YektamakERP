
using ApiService;
using ApiService.Interfaces;
using Models;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakWeb.Pages
{
    public partial class Login
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;

        bool newPasswordMode = false;
        private string userName = default!;
        private string password = default!;
        private string? message;

        public Login(IKullaniciYetkiService kullaniciYetkiService)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
        }

        public void InitializeComponentsNewPassword() { }

        public bool VerifyPassword(Kullanici user, string storedHash)
        {
            string hashedPassword = user.sifre;
            return hashedPassword == storedHash;
        }

        private void CreateNewPassword(Kullanici kullanici, string newPassWord)
        {
            ILoginHelper LoginHelper = new LoginHelper();
            string salt = LoginHelper.GenerateCryptographicSalt();
            string password = newPassWord;
            string hashedPassword = LoginHelper.ComputeHash(password, salt);

            kullanici.sifre = hashedPassword;
            kullanici.salt = salt;
            kullanici.isSifreDegisti = true;
            string httpResult = _kullaniciYetkiService.SaveKullanici(kullanici);
            if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                dialog.Content = "Hata oluştu, şifre kaydedilemedi.";
                dialog?.ShowDialog();
            }
        }

        private bool CheckFields()
        {
            bool result = true;
            return result;
        }
    }
}
