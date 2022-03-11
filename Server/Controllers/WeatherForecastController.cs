using HandsOnWithBlazor.Application.Queries;
using HandsOnWithBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HandsOnWithBlazor.Server.Controllers
{
    [AllowAnonymous]
    public class WeatherForecastController : MediatRControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
            => await Mediator.Send(new WeatherForcastRequestQuery());
    }
}