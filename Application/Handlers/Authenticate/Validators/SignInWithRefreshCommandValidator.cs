using FluentValidation;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Commands;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Validators
{
    public class SignInRequestWithRefreshCommandValidator : AbstractValidator<SignInWithRefreshCommand>
    {
        public SignInRequestWithRefreshCommandValidator()
        {
            RuleFor(model => model.Email).NotEmpty();
            RuleFor(model => model.Password).NotEmpty();
        }
    }
}
