using ApiService;
using ApiService.Implementations;
using ApiService.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Configuration;
using Models.Models.Configuration;
using System;
using Utilities;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar;
using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Formlar.Projemodul;
using YektamakDesktop.Formlar.ProjeModul;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Satinalma.İrsaliye;
using YektamakDesktop.Formlar.Satinalma.Siparis;
using YektamakDesktop.Formlar.Satinalma.Talep;
using YektamakDesktop.Formlar.Satinalma.Teklif;
using YektamakDesktop.Formlar.Satis;
using YektamakDesktop.Formlar.Stok;
using YektamakDesktop.Formlar.Yetkilendirme;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Common
{
    public static class DIContainer
    {
        public static ServiceProvider serviceProvider;

        public static void ConfigureServices()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
            var services = new ServiceCollection();

            // Servisleri ekleyin
            services.AddTransient(typeof(AnaVeriTanimlamaFormu<>));
            services.AddTransient<AdresTanimlamaFormu>();
            services.AddTransient<AltMenuEkleForm>();
            services.AddTransient<BoyutTanimFormu>();
            services.AddTransient<DataControl>();
            services.AddTransient<DataControlFirma>();
            services.AddTransient<DataControlMenu>();
            services.AddTransient<DataControlProjeDosya>();
            services.AddTransient<DataControlSatinalmaTalepDetay>();
            services.AddTransient<DataControlStokKartDosya>();
            services.AddTransient<DosyalamaParametreleri>();
            services.AddTransient<EkranEkle>();
            services.AddTransient<ExcelGrupParametreForm>();
            services.AddTransient<ExcelTanimlamaFormu>();
            services.AddTransient<ExceldenVeriAlmaCakisanKodlar>();
            services.AddTransient<ExcelVeriAlmaCakisanOnayFormu>();
            services.AddTransient<ExceldenVeriAlmaFormu>();
            services.AddTransient<FirmaTanimFormu>();
            services.AddTransient<GirisOzetEkran>();
            services.AddTransient<GridSettingsManager>();
            services.AddTransient<IrsaliyeListesi>();
            services.AddTransient<KullaniciKayitFormu>();
            services.AddTransient<LogoEntegrasyon>();
            services.AddTransient<MailAyarlari>();
            services.AddTransient<MailAyarlarim>();
            services.AddTransient<MailGonder>();
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<MailService>();
            services.AddTransient<MainForm>();
            services.AddTransient<MalzemeAltGrupTanimFormu>();
            services.AddTransient<MalzemeAltGrup2TanimFormu>();
            services.AddTransient<MalzemeGirisFormu>();
            services.AddTransient<MalzemeGrupTanimFormu>();
            services.AddTransient<Menuler>();
            services.AddTransient<Monday>();
            services.AddTransient<PdfGoruntuleme>();
            services.AddTransient<PermissionManager>();
            services.AddTransient<PersonelKayitFormu>();
            services.AddTransient<ProjeBelgeOnay>();
            services.AddTransient<ProjeDosyalari>();
            services.AddTransient<ProjeDosyaAgacStil>();
            services.AddTransient<ProjeSorumlusuAtamaFormu>();
            services.AddTransient<ProjeTanimlamaFormu>();
            services.AddTransient<SatinalmaSiparisKayitFormu>();
            services.AddTransient<SatinalmaSiparisler>();
            services.AddTransient<SatinalmaTalepHelper>();
            services.AddTransient<SatinalmaTalepKayitFormu>();
            services.AddTransient<SatinalmaTalepler>();
            services.AddTransient<SatinalmaTalepOlusturmaAltForm>();
            services.AddTransient<SatinalmaTalepOlusturmaFormu>();
            services.AddTransient<SatinalmaTalepOnayFormu>();
            services.AddTransient<SatinalmaTalepSatirDetayForm>();
            services.AddTransient<SatinalmaTalepTeklifFormu>();
            services.AddTransient<SatinalmaTeklifKayitFormu>();
            services.AddTransient<SatinalmaTeklifTaleplerFormu>();
            services.AddTransient<SatinalmaTekliflerFormu>();
            services.AddTransient<StokGrupTanimFormu>();
            services.AddTransient<StokGrupTanimlari>();
            services.AddTransient<StokKartHamVeri>();
            services.AddTransient<StokKartKayitFormu>();
            services.AddTransient<StokKartGridForm>();
            services.AddTransient<UniversalGrid>();
            services.AddTransient<UserLogin>();
            services.AddTransient<YetkiTanimlari>();
            services.Configure<PasswordHashingOptions>(options =>
            {
                options.Iterations = 120000; // Higher for more security
                options.MinPasswordLength = 6;
            });
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ISatinalmaTalepHelper, SatinalmaTalepHelper>();
            services.AddUtilities();
            services.AddApiServices();

            // ServiceProvider oluştur ve sakla
            serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return serviceProvider.GetRequiredService<T>();
        }
        public static void Reset()
        {
            if(serviceProvider != null)
            {
                var caches = serviceProvider.GetServices<ICache>();
                foreach (var cache in caches)
                {
                    cache.Reset();
                }
            }
        }

    }
}