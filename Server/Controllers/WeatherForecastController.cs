using HandsOnWithBlazor.Application.Queries;
using HandsOnWithBlazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnWithBlazor.Server.Controllers
{
    public class WeatherForecastController : MediatRControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
            => await Mediator.Send(new WeatherForcastRequestQuery());
    }
}