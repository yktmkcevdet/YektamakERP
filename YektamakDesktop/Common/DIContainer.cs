using ApiService;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Configuration;
using System;
using Utilities;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Formlar;
using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Formlar.Proje;
using YektamakDesktop.Formlar.Satis;
using YektamakDesktop.Formlar.Stok;
using YektamakDesktop.Formlar.Yetkilendirme;

namespace YektamakDesktop.Common
{
    public static class DIContainer
    {
        private static ServiceProvider _serviceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Servisleri ekleyin
            services.AddSingleton<MainWindow>();
            services.AddSingleton<UserLogin>();
            services.AddSingleton<GlobalData>();
            services.AddSingleton<ProjeDosyalari>();
            services.AddSingleton<StokKartKayitFormu>();
            services.AddSingleton<SatinalmaTalepOlusturma>();
            services.AddSingleton<AltMenuEkle>();
            services.AddSingleton<FirmaGridForm>();
            services.AddSingleton<PersonelKayitFormu>();
            services.AddSingleton<ExceldenVeriAlmaFormu>();
            services.AddSingleton<SatisTeklifTalepKayitFormu>();
            services.AddSingleton<SatisSiparisTeklifTalepGridForm>();
            services.AddSingleton<Monday>();
            services.AddSingleton<Menuler>();
            services.AddSingleton<EkranEkle>();
            services.AddSingleton<StokKartGridForm>();
            services.AddSingleton<YetkiTanimlari>();
            services.AddSingleton<SatisTeklifMaliyetKayitFormu>();
            services.AddSingleton<KullaniciKayitFormu>();
            services.AddSingleton<MalzemeAltGrup2>();
            services.AddSingleton<SatinalmaTalepSatirDetayForm>();
            services.AddSingleton(typeof(AnaVeriTanimlamaFormu<>));
            services.AddSingleton<IDataGridHelper, DataGridHelper>();
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
