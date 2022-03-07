using FluentValidation;
using HandsOnWithBlazor.Application.Queries;

namespace HandsOnWithBlazor.Application.Validators
{
    public class WeatherForcastRequestQueryValidator : AbstractValidator<WeatherForcastRequestQuery>
    {
        public WeatherForcastRequestQueryValidator()
        {
        }
    }
}
