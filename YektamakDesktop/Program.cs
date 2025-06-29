using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar;
using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Formlar.Proje;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Satinalma.Teklif;
using YektamakDesktop.Formlar.Satis;
using YektamakDesktop.Formlar.Stok;
using YektamakDesktop.Formlar.Yetkilendirme;
using YektamakDesktop.Helpers;
using static YektamakDesktop.Formlar.Yetkilendirme.Menuler;

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
            DIContainer.GetService<EkranEkle>();
            DIContainer.GetService<FirmaGridForm>();
            DIContainer.GetService<PersonelKayitFormu>();
            DIContainer.GetService<ProjeDosyalari>();
            DIContainer.GetService<StokKartKayitFormu>();
            DIContainer.GetService<ExceldenVeriAlmaFormu>();
            DIContainer.GetService<SatisTeklifTalepKayitFormu>();
            DIContainer.GetService<SatisSiparisTeklifTalepGridForm>();
            DIContainer.GetService<SatinalmaTalepKayitFormu>();
            DIContainer.GetService<AltMenuEkle>();
            DIContainer.GetService<Menuler>();
            DIContainer.GetService<Monday>();
            DIContainer.GetService<StokKartGridForm>();
            DIContainer.GetService<YetkiTanimlari>();
            DIContainer.GetService<SatisTeklifMaliyetKayitFormu>();
            DIContainer.GetService<KullaniciKayitFormu>();
            DIContainer.GetService<SatinalmaTalepler>();
            DIContainer.GetService<SatinalmaTalepOnayFormu>();
            DIContainer.GetService<PermissionManager>();
            DIContainer.GetService<DataControlMenu>();
            DIContainer.GetService<SatinalmaTalepTeklifFormu>();
            DIContainer.GetService<ExcelTanimlamaFormu>();
            DIContainer.GetService<MailGonder>();
            DIContainer.GetService<SatinalmaTeklifKayitFormu>();
            DIContainer.GetService<SatinalmaTeklifTaleplerFormu>();
            GlobalData.Start();
            while (true)
            {
                
                var loginForm = DIContainer.GetService<UserLogin>();
                Application.Run(loginForm);

                if (loginForm.loginStatus)
                {
                    var mainForm = DIContainer.GetService<MainWindow>();
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
