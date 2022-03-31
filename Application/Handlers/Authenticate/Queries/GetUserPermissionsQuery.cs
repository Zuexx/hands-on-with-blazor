using HandsOnWithBlazor.Shared.Models;
using MediatR;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate.Queries
{
    public class GetUserPermissionsQuery : IRequest<ApiResponse<List<string>>>
    {
        public GetUserPermissionsQuery()
        {
        }
    }
}
