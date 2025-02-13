using ApiService.Implementetions;
using ApiService.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using Utilities.Interfaces;

namespace YektamakWeb.Commands.Accounts
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());
        private readonly IUserService _userService;
        private readonly ICache _cache;
        public event Action? OnChange;
        public CustomAuthStateProvider(ProtectedSessionStorage sessionStorage,IUserService userService,ICache cache)
        {
            _sessionStorage = sessionStorage;
            _userService = userService;
            _cache = cache;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var storedUser = await _sessionStorage.GetAsync<string>("authUser");

                if (storedUser.Success && !string.IsNullOrEmpty(storedUser.Value))
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, storedUser.Value)
                    }, "custom");

                    _currentUser = new ClaimsPrincipal(identity);
                    _cache.kullanici = await _userService.GetKullaniciAsync(identity.Name!);
                }
            }
            catch
            {
                _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            }

            return new AuthenticationState(_currentUser);
        }


        public async Task NotifyUserAuthentication(ClaimsPrincipal user)
        {
            _currentUser = user;
            await _sessionStorage.SetAsync("authUser", user.Identity?.Name ?? string.Empty);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            NotifyStateChanged();
        }

        public async Task NotifyUserLogout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            await _sessionStorage.DeleteAsync("authUser");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            NotifyStateChanged();
        }
        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
