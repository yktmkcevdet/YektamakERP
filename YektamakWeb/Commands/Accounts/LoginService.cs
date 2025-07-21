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
        public LoginService(CustomAuthStateProvider authStateProvider, NavigationManager navigationManager, IConfiguration configuration,IUserService userService, IPasswordService passwordService)
        {
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
            _configuration = configuration;
            _userService = userService;
            _passwordService = passwordService;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            ILoginHelper loginHelper = new LoginHelper();
            JwtHelper jwtHelper = new JwtHelper(_configuration);
            Kullanici user = new Kullanici();
            user = await _userService.GetKullaniciAsync(username);
            string sifre = loginHelper.ComputeHash(password, user.salt);
            if (_passwordService.VerifyPassword(password, user.sifre))
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
