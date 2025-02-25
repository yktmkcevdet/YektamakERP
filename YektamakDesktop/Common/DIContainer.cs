using ApiService;
using Microsoft.Extensions.DependencyInjection;
using System;
using Utilities;
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
            services.AddSingleton<StokKartTanimlamaFormu>();
            services.AddSingleton<SatinalmaTalepOlusturma>();
            services.AddSingleton<SatisProjeKayitFormu>();
            services.AddSingleton<AltMenuEkle>();
            services.AddSingleton<FirmaGridForm>();
            services.AddSingleton<ExceldenVeriAlmaFormu>();
            services.AddSingleton<SatisSiparisTeklifTalepKayitFormu>();
            services.AddSingleton<SatisSiparisTeklifTalepGridForm>();
            services.AddSingleton<Monday>();
            services.AddSingleton<Menuler>();
            services.AddSingleton<IDataGridHelper, DataGridHelper>();
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
