using HandsOnWithBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;

namespace HandsOnWithBlazor.Client.Components
{
    public partial class SignIn : ComponentBase
    {
        [Inject] private HttpClient _httpClient { get; set; }

        private string _token { get; set; } = string.Empty;

        private LoginUserModel _user = default!;

        private async Task HandleLoginClicked(MouseEventArgs e)
        {
           await _httpClient.PostAsJsonAsync("authenticate/signinwithrefresh", _user);
        }
    }
}
