using Microsoft.Extensions.DependencyInjection;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUtilities(this IServiceCollection services)
        {
            services.AddScoped<ICache, Cache>();
            services.AddScoped<IDataTableHelper, DataTableHelper>();
            services.AddScoped<IJsonConvertHelper, JsonConvertHelper>();
            services.AddScoped<ILoginHelper, LoginHelper>();
            services.AddScoped<IMailHandler, MailHandler>();
            return services;
        }
    }
}
