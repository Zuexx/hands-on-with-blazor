using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Queries
{
    public class SignInRequestQuery : IRequest<ApiResponse<string>>
    {
        public string Email { get; set; }
        
        public string Password { get; set; }


        public SignInRequestQuery()
        {            
        }
    }
}
