using Api.Business;
using Api.Converters;
using Api.Factory;
using Api.Interfaces;
using Api.TokenJobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api
{
    // Program.cs veya Startup.cs
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IDbConnectionFactory, MySqlConnectionFactory>();
            builder.Services.AddScoped<IDataAccessLayer, DataAccesLayerMySqlLocal>();
            builder.Services.AddScoped<IStokService, StokKartRepository>();
            builder.Services.AddScoped<IProjeStokKartService, ProjeStokKartService>();

            //builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()) // Eðer BasePath yanlýþsa doðru yolu belirtin
            //              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            // JWT Ayarlarýný yapýlandýrma
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
                };
            });
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new MultiFormatDateTimeConverter());
                });
            builder.Services.AddAuthorization();

            // TokenService'i DI'ye ekleyin
            string secretKey = jwtSettings["SecretKey"];
            builder.Services.AddSingleton<TokenService>(sp => new TokenService(jwtSettings["SecretKey"]));

            var app = builder.Build();
            
            // Middleware ayarlarý
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers(); // Controller'larý kullanabilmek için
            app.Run();
        }
    }


}
