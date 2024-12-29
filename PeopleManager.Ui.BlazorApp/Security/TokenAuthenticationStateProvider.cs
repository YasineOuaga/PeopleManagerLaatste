using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Vives.Presentation.Authentication;

namespace PeopleManager.Ui.BlazorApp.Security
{
    public class TokenAuthenticationStateProvider: AuthenticationStateProvider
    {
        private readonly IBearerTokenStore _tokenStore;

        public TokenAuthenticationStateProvider(IBearerTokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return GetAuthenticationStateFromToken();
        }

        public void AuthenticateUser()
        {
            var authenticationState = GetAuthenticationStateFromToken();

            NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
        }

        private AuthenticationState GetAuthenticationStateFromToken()
        {
            var token = _tokenStore.GetToken();

            if (string.IsNullOrWhiteSpace(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            JsonWebToken jwtToken = new JsonWebToken(token);

            
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");

            var principal = new ClaimsPrincipal(identity);

            return new AuthenticationState(principal);
        }
    }
}
