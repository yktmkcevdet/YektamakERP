using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace YektamakWeb.Commands.Accounts
{
    public class UserService 
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public UserService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<string?> GetCurrentUsernameAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            return authState.User.Identity?.Name;
        }

        public async Task<List<string>> GetUserRolesAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            return authState.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            return authState.User.Identity?.IsAuthenticated ?? false;
        }
    }
}
