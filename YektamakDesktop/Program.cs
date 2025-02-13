using ApiService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Utilities;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar;
using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Formlar.Proje;
using YektamakDesktop.Formlar.Satis;
using YektamakDesktop.Formlar.Stok;
using YektamakDesktop.Formlar.Yetkilendirme;

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

            
            
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DIContainer.ConfigureServices();
            DIContainer.GetService<GlobalData>();
            DIContainer.GetService<SatisProjeKayitFormu>();
            DIContainer.GetService<FirmaGridForm>();
            DIContainer.GetService<ProjeDosyalari>();
            DIContainer.GetService<StokKartTanimlamaFormu>();
            DIContainer.GetService<ExceldenVeriAlmaFormu>();
            var userLogin = DIContainer.GetService<UserLogin>();
            Application.Run(userLogin);

            if (userLogin.loginStatus)
            {
                var mainForm = DIContainer.GetService<MainWindow>();
                Application.Run(mainForm);
            }
        }
    }
}
