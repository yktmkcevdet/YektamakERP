using ApiService.Interfaces;
using BlazorApp1.Features.Commands.Account.Login;
using Microsoft.AspNetCore.Components;
using Models;
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
        private readonly IPasswordService _passwordService;
        private readonly ICache _cache;
        public LoginService(CustomAuthStateProvider authStateProvider, NavigationManager navigationManager, IConfiguration configuration,IUserService userService, 
            IPasswordService passwordService, ICache cache)
        {
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
            _configuration = configuration;
            _userService = userService;
            _passwordService = passwordService;
            _cache = cache;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            ILoginHelper loginHelper = new LoginHelper();
            JwtHelper jwtHelper = new JwtHelper(_configuration);
            _cache.kullanici = await _userService.GetKullaniciAsync(username);
            if (_passwordService.VerifyPassword(password, _cache.kullanici.sifre))
            {
                var jwtToken = new LoginHandler(_configuration).GenerateJwtToken(_cache.kullanici);
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
