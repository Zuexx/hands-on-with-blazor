using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Commands
{
    public class RefreshAuthenticationCommand : IRequest<ApiResponse<TokenDto>>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public RefreshAuthenticationCommand(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
