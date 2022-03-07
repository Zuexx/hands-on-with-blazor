using FluentValidation;
using HandsOnWithBlazor.Shared;
using MediatR;

namespace HandsOnWithBlazor.Application.Queries
{
    public class WeatherForcastRequestQuery : IRequest<IEnumerable<WeatherForecast>>
    {
        public WeatherForcastRequestQuery()
        {
        }
    }
}
