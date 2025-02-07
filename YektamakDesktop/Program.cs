using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Utilities;
using YektamakDesktop.Formlar;
using YektamakDesktop.Formlar.Proje;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // ServiceCollection oluþtur ve servisleri kaydet
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Servis saðlayýcýyý oluþtur
            ServiceProvider s = services.BuildServiceProvider();
            
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = ServiceProviderServiceExtensions.GetRequiredService<MainWindow>(s);
            var userLogin = ServiceProviderServiceExtensions.GetRequiredService<UserLogin>(s);
            ServiceProviderServiceExtensions.GetRequiredService<GlobalData>(s);
            ServiceProviderServiceExtensions.GetRequiredService<ProjeDosyalari>(s);
            ServiceProviderServiceExtensions.GetRequiredService<StokKartTanimlamaFormu>(s);
            //UserLogin userLogin = new UserLogin(new Cache(new JsonConvertHelper(),new DataTableConverter()));
            Application.Run(userLogin);

            // KullaniciGiris formu kapatýldýðýnda buraya gelir
            if (userLogin.loginStatus)
            {
                Application.Run(mainForm);
            }
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            // Servis kayýtlarý
            services.AddSingleton<MainWindow>();
            services.AddSingleton<UserLogin>();
            services.AddSingleton<GlobalData>();
            services.AddSingleton<ProjeDosyalari>();
            services.AddSingleton<StokKartTanimlamaFormu>();
            services.AddUtilities();
            services.AddUtilities();
            // Diðer servis kayýtlarýnýzý buraya ekleyin
        }
    }
}
