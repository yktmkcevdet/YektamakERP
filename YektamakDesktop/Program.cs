using ApiService.Implementations;
using ApiService.Interfaces;
using Models.Models.Configuration;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;
using QuestPDF.Infrastructure;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar;
using YektamakDesktop.Formlar.Yetkilendirme;
using YektamakDesktop.Helpers;

namespace YektamakDesktop
{
    internal static class Program
    {
        static IUpdateService updateService;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            QuestPDF.Settings.License = LicenseType.Community; // ? Ücretsiz lisans
            QuestPDF.Settings.CheckIfAllTextGlyphsAreAvailable = false;
            CultureInfo culture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            
            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            while (true)
            {
                DIContainer.Reset();
                DIContainer.ConfigureServices();
                DIContainer.GetService<PermissionManager>();
                DIContainer.GetService<DataControlMenu>();
                
                UserLogin loginForm = FormFactory.CreateForm<UserLogin>();
                Application.Run(loginForm);
                
                if (loginForm.loginStatus)
                {
                    
                    MainForm mainForm = FormFactory.CreateForm<MainForm>();
                    Application.Run(mainForm);
                    // mainForm kapanýnca döngü tekrar baþa dönecek
                }
                else
                {
                    break; // login baþarýsýzsa veya kullanýcý çýkmak isterse döngüyü kýr
                }
            }
            Application.Exit();
            

        }
    }
}
