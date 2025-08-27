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

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISatinalmaTalepService, SatinalmaTalepService>();
            services.AddScoped<ISatinalmaTeklifService, SatinalmaTeklifService>();
            services.AddScoped<ISatisService, SatisService>();
            services.AddScoped<IStokService, StokService>();
            services.AddScoped<IProjeService, ProjeService>();
            services.AddScoped<IKullaniciYetkiService, KullaniciYetkiService>();
            services.AddScoped<IFirmaService, FirmaService>();
            services.AddScoped<IPersonelService, PersonelService>();
            services.AddScoped<IProjeService, ProjeService>();
            services.AddScoped<ICariService, CariService>();
            services.AddScoped<IDovizCinsiService, DovizCinsiService>();
            services.AddScoped<IMaliyetService, MaliyetService>();
            services.AddScoped<IAnaVeriService, AnaVeriService>();
            services.AddScoped<IVadeService, VadeService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<ISatinalmaSiparisService, SatinalmaSiparisService>();
            return services;
        }
    }
}
