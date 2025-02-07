using ApiService.Implementetions;
using BlazorApp1.Features.Commands.Account.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakWeb.Commands.Accounts
{
    public class LoginService
    {
        private readonly CustomAuthStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public LoginService(CustomAuthStateProvider authStateProvider, NavigationManager navigationManager, IConfiguration configuration,IUserService userService)
        {
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            ILoginHelper loginHelper = new LoginHelper();
            JwtHelper jwtHelper = new JwtHelper(_configuration);
            Kullanici user = new Kullanici();
            user = await _userService.GetKullaniciAsync(username);
            string sifre = loginHelper.HashPassword(password, user.salt);
            if (CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(sifre), Encoding.UTF8.GetBytes(user.sifre)))
            {
                var jwtToken = new LoginHandler(_configuration).GenerateJwtToken(user);
                await _authStateProvider.NotifyUserAuthentication(jwtHelper.GetClaimsPrincipalFromToken(jwtToken));
                return jwtToken;
            }
            return null;
        }

        public async void LogoutAsync()
        {
            await _authStateProvider.NotifyUserLogout();
            _navigationManager.NavigateTo("/login", forceLoad: true);
        }
    }
}
