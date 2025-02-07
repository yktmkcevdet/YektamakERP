using ApiService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorApp1.Features.Commands.Account.Login
{
    public class LoginHandler
    {
        private readonly IConfiguration _configuration;
        
        public LoginHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(Kullanici user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");
            var expirationMinutes = jwtSettings.GetValue<int>("ExpirationMinutes");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.ad),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("Role", user.rolId.ToString()),
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(expirationMinutes), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
