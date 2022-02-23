using Microsoft.AspNetCore.Components;
using HandsOnWithBlazor.Shared;
using System.Net.Http.Json;

namespace HandsOnWithBlazor.Client.Pages
{
    public partial class FetchData : ComponentBase
    {
        [Inject] private HttpClient _httpClient { get; set; }

        private WeatherForecast[]? forecasts;

        public FetchData(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
