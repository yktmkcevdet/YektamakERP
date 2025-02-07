using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
namespace YektamakWeb.Commands.Accounts
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public AuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Çerezden token'ı al
            var token = context.Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token))
            {
                JwtHelper jwtHelper = new JwtHelper(_configuration);
                // Token'ı doğrula ve kullanıcı bilgilerini bağla
                var claimsPrincipal = jwtHelper.ValidateToken(token);
                if (claimsPrincipal != null)
                {
                    context.User = claimsPrincipal;
                }
            }

            await _next(context);
        }
    }
}

