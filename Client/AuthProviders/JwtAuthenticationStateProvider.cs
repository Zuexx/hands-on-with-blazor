using HandsOnWithBlazor.Client.Models;
using HandsOnWithBlazor.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace HandsOnWithBlazor.Client.AuthProviders
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private SimpleStateContainerService<SimpleStateModel> _stateService { get; set; } = default!;

        public JwtAuthenticationStateProvider(SimpleStateContainerService<SimpleStateModel> stateService)
        {
            _stateService = stateService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymous = new ClaimsIdentity();

            var jwtToken = _stateService.Value.Token;

            //if(string.IsNullOrEmpty(jwtToken))
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
