using Blazored.LocalStorage;
using HandsOnWithBlazor.Client.AuthProviders;
using HandsOnWithBlazor.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HandsOnWithBlazor.Client.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }
        public async Task<AuthResponseDto> Login(LoginUserModel userForAuthentication)
        {
            var authResult = await _client.PostAsJsonAsync("authenticate/signinwithrefresh", userForAuthentication);
            var result = await authResult.Content.ReadFromJsonAsync<ApiResponse<AuthResponseDto>>();
            if (!authResult.IsSuccessStatusCode)
                return result.Data;
            
            await _localStorage.SetItemAsync("authToken", result.Data.Token);
            ((JwtAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(userForAuthentication.Email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.Token);

            return result.Data;
        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((JwtAuthenticationStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }

    }
}
