using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUtilities(this IServiceCollection services)
        {
            // Serilog'u yapılandır
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            //// Serilog'u .NET logging sistemine bağla
            //services.AddLogging(loggingBuilder =>
            //{
            //    loggingBuilder.ClearProviders();
            //    loggingBuilder.AddSerilog();
            //});

            // Utilities servislerini ekle
            services.AddSingleton<IAppLogger, AppLogger>();
            services.AddSingleton<ICache, Cache>();
            services.AddSingleton<IDataTableMapper, DataTableMapper>();
            services.AddSingleton<IJsonConverter, JsonConverter>();
            services.AddSingleton<ILoginHelper, LoginHelper>();
            services.AddSingleton<IMailHandler, MailHandler>();
            services.AddSingleton<IConvertHelper, ConvertHelper>();
            return services;
        }
    }
}
