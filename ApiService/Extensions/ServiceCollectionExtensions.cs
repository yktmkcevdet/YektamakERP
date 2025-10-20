using ApiService.Constants;
using ApiService.Implementetions;
using ApiService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace ApiService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddHttpClient<IApiService, ApiServiceClientNotDecoded>(client =>
            {
                client.BaseAddress = new Uri(ApiBaseUrl.server); // API'nin temel adresi
            })
            // SSL sertifikası olmayan sunucular için
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                });

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ISatinalmaTalepService, SatinalmaTalepService>();
            services.AddSingleton<ISatinalmaTeklifService, SatinalmaTeklifService>();
            services.AddSingleton<ISatisService, SatisService>();
            services.AddSingleton<IStokService, StokService>();
            services.AddSingleton<IProjeService, ProjeService>();
            services.AddSingleton<IKullaniciYetkiService, KullaniciYetkiService>();
            services.AddSingleton<IFirmaService, FirmaService>();
            services.AddSingleton<IPersonelService, PersonelService>();
            services.AddSingleton<IProjeService, ProjeService>();
            services.AddSingleton<ICariService, CariService>();
            services.AddSingleton<IDovizCinsiService, DovizCinsiService>();
            services.AddSingleton<IMaliyetService, MaliyetService>();
            services.AddSingleton<IAnaVeriService, AnaVeriService>();
            services.AddSingleton<IVadeService, VadeService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<ISatinalmaSiparisService, SatinalmaSiparisService>();
            return services;
        }
    }
}
