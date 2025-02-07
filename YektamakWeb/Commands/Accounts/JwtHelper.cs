namespace YektamakWeb.Commands.Accounts
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            var jwtSetting = _configuration.GetSection("JwtSettings");
            var jwtSettings = new
            {
                SecretKey = jwtSetting.GetValue<string>("SecretKey"),
                Issuer = jwtSetting.GetValue<string>("Issuer"),
                Audience = jwtSetting.GetValue<string>("Audience")
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true
                };

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }
        public ClaimsPrincipal GetClaimsPrincipalFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var identity = new ClaimsIdentity(token.Claims, "jwt");
            return new ClaimsPrincipal(identity);
        }
    }

}
