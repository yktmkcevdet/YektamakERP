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
            });
            // SSL sertifikası olmayan sunucular için
            //        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            //{
            //  ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            //});
            
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
