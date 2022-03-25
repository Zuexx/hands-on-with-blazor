using FluentValidation;
using HandsOnWithBlazor.Application.Queries;

namespace HandsOnWithBlazor.Application.Validators
{
    public class SignInRequestQueryValidator : AbstractValidator<SignInRequestQuery>
    {
        public SignInRequestQueryValidator()
        {
            RuleFor(model => model.Email).NotEmpty();
            RuleFor(model => model.Password).NotEmpty();
        }
    }
}
