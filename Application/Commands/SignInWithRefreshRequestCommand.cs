using AuthPermissions.AspNetCore.JwtTokenCode;
using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Queries
{
    public class SignInWithRefreshRequestCommand : IRequest<ApiResponse<TokenAndRefreshToken>>
    {
        public string Email { get; set; }
        
        public string Password { get; set; }


        public SignInWithRefreshRequestCommand()
        {            
        }
    }
}
