using ApiService;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Configuration;
using System;
using Utilities;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
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
using static YektamakDesktop.Formlar.Satinalma.SatinalmaTalepTeklifFormu;
using static YektamakDesktop.Formlar.Stok.StokKartKayitFormu;
using static YektamakDesktop.Formlar.Yetkilendirme.Menuler;

namespace YektamakDesktop.Common
{
    public static class DIContainer
    {
        public static ServiceProvider serviceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Servisleri ekleyin
            services.AddTransient(typeof(AnaVeriTanimlamaFormu<>));
            services.AddTransient<AltMenuEkleForm>();
            services.AddTransient<DataControl>();
            services.AddTransient<DataControlFirma>();
            services.AddTransient<DataControlMenu>();
            services.AddTransient<EkranEkle>();
            services.AddTransient<ExcelTanimlamaFormu>();
            services.AddTransient<ExceldenVeriAlmaFormu>();
            services.AddTransient<FirmaGridForm>();
            services.AddTransient<GlobalData>();
            services.AddTransient<GridSettingsManager>();
            services.AddTransient<KullaniciKayitFormu>();
            services.AddTransient<MailGonder>();
            services.AddTransient<MainWindow>();
            services.AddTransient<Menuler>();
            services.AddTransient<Monday>();
            services.AddTransient<PermissionManager>();
            services.AddTransient<PersonelKayitFormu>();
            services.AddTransient<ProjeDosyalari>();
            services.AddTransient<SatinalmaTalepKayitFormu>();
            services.AddTransient<SatinalmaTalepler>();
            services.AddTransient<SatinalmaTalepOnayFormu>();
            services.AddTransient<SatinalmaTalepSatirDetayForm>();
            services.AddTransient<SatinalmaTalepTeklifFormu>();
            services.AddTransient<SatinalmaTeklifKayitFormu>();
            services.AddTransient<SatinalmaTeklifTaleplerFormu>();
            services.AddTransient<SatisSiparisTeklifTalepGridForm>();
            services.AddTransient<SatisTeklifTalepKayitFormu>();
            services.AddTransient<SatisTeklifMaliyetKayitFormu>();
            services.AddTransient<StokKartKayitFormu>();
            services.AddTransient<StokKartGridForm>();
            services.AddTransient<UniversalGrid>();
            services.AddTransient<UserLogin>();
            services.AddTransient<YetkiTanimlari>();
            services.AddTransient<IDataGridHelper, DataGridHelper>();
            services.Configure<PasswordHashingOptions>(options =>
            {
                options.Iterations = 120000; // Higher for more security
                options.MinPasswordLength = 6;
            });
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddUtilities();
            services.AddApiServices();

            // ServiceProvider oluştur ve sakla
            serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return serviceProvider.GetRequiredService<T>();
        }
        
    }
}
