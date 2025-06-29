using ApiService;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Configuration;
using System;
using Utilities;
using Utilities.Implementations;
using Utilities.Interfaces;
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

namespace YektamakDesktop.Common
{
    public static class DIContainer
    {
        private static ServiceProvider _serviceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Servisleri ekleyin
            services.AddTransient<MainWindow>();
            services.AddTransient<UserLogin>();
            services.AddTransient<GlobalData>();
            services.AddTransient<ProjeDosyalari>();
            services.AddTransient<StokKartKayitFormu>();
            services.AddTransient<SatinalmaTalepKayitFormu>();
            services.AddTransient<AltMenuEkle>();
            services.AddTransient<FirmaGridForm>();
            services.AddTransient<PersonelKayitFormu>();
            services.AddTransient<ExceldenVeriAlmaFormu>();
            services.AddTransient<SatisTeklifTalepKayitFormu>();
            services.AddTransient<SatisSiparisTeklifTalepGridForm>();
            services.AddTransient<Monday>();
            services.AddTransient<Menuler>();
            services.AddTransient<EkranEkle>();
            services.AddTransient<StokKartGridForm>();
            services.AddTransient<YetkiTanimlari>();
            services.AddTransient<SatisTeklifMaliyetKayitFormu>();
            services.AddTransient<KullaniciKayitFormu>();
            services.AddTransient<MalzemeAltGrup2>();
            services.AddTransient<SatinalmaTalepler>();
            services.AddTransient<SatinalmaTalepOnayFormu>();
            services.AddTransient<PermissionManager>();
            services.AddTransient<DataControlMenu>();
            services.AddTransient<SatinalmaTalepTeklifFormu>();
            services.AddTransient<ExcelTanimlamaFormu>();
            services.AddSingleton<MailGonder>();
            services.AddSingleton<SatinalmaTeklifTaleplerFormu>();
            services.AddSingleton<SatinalmaTeklifKayitFormu>();
            services.AddTransient(typeof(AnaVeriTanimlamaFormu<>));
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
            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }
        
    }
}
