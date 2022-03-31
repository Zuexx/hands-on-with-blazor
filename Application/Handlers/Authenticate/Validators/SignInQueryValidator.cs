using FluentValidation;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Queries;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Validators
{
    public class SignInQueryValidator : AbstractValidator<SignInQuery>
    {
        public SignInQueryValidator()
        {
            RuleFor(model => model.Email).NotEmpty();
            RuleFor(model => model.Password).NotEmpty();
        }
    }
}
