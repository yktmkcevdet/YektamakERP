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
            services.AddHttpClient<IApiService, ApiServiceClient>(client =>
            {
                client.BaseAddress = new Uri(ApiBaseUrl.server); // API'nin temel adresi
            })
            // SSL sertifikası olmayan sunucular için
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISatinalmaService, SatinalmaService>();
            services.AddTransient<ISatisService, SatisService>();
            services.AddTransient<IStokService, StokService>();
            services.AddTransient<IProjeService, ProjeService>();
            services.AddTransient<IKullaniciYetkiService, KullaniciYetkiService>();
            services.AddTransient<IFirmaService, FirmaService>();
            services.AddTransient<IPersonelService, PersonelService>();
            services.AddTransient<IProjeService, ProjeService>();
            services.AddTransient<ICariService, CariService>();
            services.AddTransient<IDovizCinsiService, DovizCinsiService>();
            services.AddTransient<IMaliyetService, MaliyetService>();
            services.AddTransient<IAnaVeriService, AnaVeriService>();
            return services;
        }
    }
}
