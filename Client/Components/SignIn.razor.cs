using HandsOnWithBlazor.Client.Models;
using HandsOnWithBlazor.Client.Services;
using HandsOnWithBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;

namespace HandsOnWithBlazor.Client.Components
{
    public partial class SignIn : ComponentBase, IDisposable
    {
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private SimpleStateContainerService<SimpleStateModel> _state { get; set; } = default!;

        [Inject] private AuthenticationService _auth { get; set; } = default!;



        private LoginUserModel _user = default!;

        protected override void OnInitialized()
        {
            _state.OnStateChange += StateHasChanged;
        }

        private async Task HandleLoginClicked(MouseEventArgs e)
        {
            var result = await _auth.Login(_user);
            
            if (result.IsAuthSuccessful)
            { 
            }            
        }

        public void Dispose()
        {
            _state.OnStateChange -= StateHasChanged;
        }
    }
}
