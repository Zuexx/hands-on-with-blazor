using Microsoft.AspNetCore.Components;
using HandsOnWithBlazor.Shared;
using System.Net.Http.Json;

namespace HandsOnWithBlazor.Client.Pages
{
    public partial class FetchData:ComponentBase
    {
        [Inject] private HttpClient Http { get; set; }

        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
