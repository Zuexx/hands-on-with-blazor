using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Commands
{
    public class SignOutCommand : IRequest<ApiResponse>
    {
        public SignOutCommand()
        {            
        }
    }
}
