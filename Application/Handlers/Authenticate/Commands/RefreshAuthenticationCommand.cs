using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Commands
{
    public class RefreshAuthenticationCommand : IRequest<ApiResponse<AuthResponseDto>>
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
