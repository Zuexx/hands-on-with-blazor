using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Queries
{
    public class SignInQuery : IRequest<ApiResponse<string>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public SignInQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
