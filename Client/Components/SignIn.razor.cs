using HandsOnWithBlazor.Client.Models;
using HandsOnWithBlazor.Client.Services;
using HandsOnWithBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;

namespace HandsOnWithBlazor.Client.Components
{
    public partial class SignIn : ComponentBase, IDisposable
    {
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private SimpleStateContainerService<SimpleStateModel> _stateService { get; set; } = default!;
        

        private LoginUserModel _user = default!;

        protected override void OnInitialized()
        {
            _stateService.OnStateChange += StateHasChanged;
        }

        private async Task HandleLoginClicked(MouseEventArgs e)
        {
            var response =
                await _httpClient.PostAsJsonAsync("authenticate/signinwithrefresh", _user);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<TokenDto>>();

                var stateModel = _stateService.Value;
                stateModel.Token = result.Data.Token;
                stateModel.RefreshToken = result.Data.RefreshToken;
                _stateService.SetValue(stateModel);

                //var param = new TokenDto { Token = stateModel.Token, RefreshToken = stateModel.RefreshToken };
                //await _httpClient.PostAsJsonAsync("authenticate/refreshauthentication", param);

                //await _httpClient.GetFromJsonAsync<List<string>>("authenticate/getuserpermissions");
            }
        }

        public void Dispose()
        {
            _stateService.OnStateChange -= StateHasChanged;
        }
    }
}
