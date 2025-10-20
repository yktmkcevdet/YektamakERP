using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using Utilities.Interfaces;

namespace YektamakMobil.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IPasswordService _passwordService;
        private readonly ICache _cache;
        public LoginPage(IKullaniciYetkiService kullaniciYetkiService, IPasswordService passwordService, ICache cache)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _passwordService = passwordService;
            _cache = cache;
            InitializeComponent();
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                var user = new Kullanici();
                user.ad = username;
                user.sifre = password;
                string jsonResult = await _kullaniciYetkiService.GetKullaniciAsync(user);
                if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    lblMessage.Text = "Kullanıcı Bilgisi Alırken Hata :" + jsonResult;
                    return;
                }
                user = JsonConvert.DeserializeObject<List<Kullanici>>(jsonResult).FirstOrDefault();
                if (_passwordService.VerifyPassword(password, user.sifre))
                {
                    if (user.isSifreDegisti == false)
                    {

                    }
                    else 
                    {
                        _cache.kullanici = JsonConvert.DeserializeObject<List<Kullanici>>(jsonResult)[0];
                        await Navigation.PushAsync(new MainPage());
                        ((AppShell)App.Current.MainPage).BuildMenu();
                    }
                }
                else
                {
                    lblMessage.Text = "Kullanıcı adı ya da şifre hatalı";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}