using FluentValidation;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Commands;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Validators
{
    public class RefreshAuthenticationCommandValidator : AbstractValidator<RefreshAuthenticationCommand>
    {
        public RefreshAuthenticationCommandValidator()
        {
            RuleFor(model => model.Token).NotEmpty();
            RuleFor(model => model.RefreshToken).NotEmpty();
        }
    }
}
