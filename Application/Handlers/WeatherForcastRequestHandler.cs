using HandsOnWithBlazor.Application.Queries;
using HandsOnWithBlazor.Shared;
using MediatR;

namespace HandsOnWithBlazor.Application.Handlers
{
    public class WeatherForcastRequestHandler : IRequestHandler<WeatherForcastRequestQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        public WeatherForcastRequestHandler() { }

        public async Task<IEnumerable<WeatherForecast>> Handle(WeatherForcastRequestQuery query, CancellationToken cancellation)
        {

            IEnumerable<WeatherForecast> result = default!;

            await Task.Run(() =>
            {
                result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();
            });

            return result;
        }
    }
}
