using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Commands
{
    public class SignInWithRefreshCommand : IRequest<ApiResponse<TokenDto>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public SignInWithRefreshCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
