using FluentValidation;
using HandsOnWithBlazor.Application.Queries;

namespace HandsOnWithBlazor.Application.Validators
{
    public class SignInRequestWithRefreshCommandValidator : AbstractValidator<SignInWithRefreshRequestCommand>
    {
        public SignInRequestWithRefreshCommandValidator()
        {
            RuleFor(model => model.Email).NotEmpty();
            RuleFor(model => model.Password).NotEmpty();
        }
    }
}
