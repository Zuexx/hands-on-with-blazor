using AuthPermissions.PermissionsCode;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Queries;
using HandsOnWithBlazor.Infrastructure.Security;
using HandsOnWithBlazor.Shared.Models;
using MediatR;
using System.Net;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate
{
    public class GetUserPermissionsHandler : IRequestHandler<GetUserPermissionsQuery, ApiResponse<List<string>>>
    {
        private readonly IUsersPermissionsService _usersPermissionsService;
        private readonly IUserAccessor _userAccessor;

        public GetUserPermissionsHandler(
            IUsersPermissionsService usersPermissionsService, IUserAccessor userAccessor)
        {
            _usersPermissionsService = usersPermissionsService;
            _userAccessor = userAccessor;
        }

        public async Task<ApiResponse<List<string>>> Handle(GetUserPermissionsQuery request, CancellationToken cancellation)
        {
            var result = _usersPermissionsService.PermissionsFromUser(_userAccessor.User);

            ApiResponse<List<string>> response =
                new ApiResponse<List<string>>(HttpStatusCode.OK.ToString(), string.Empty, result);

            if (result?.Count == 0)
            {
                response.Status = HttpStatusCode.BadRequest.ToString();
                response.Message = "Error occurs to retrieve the user's permissions";
            }

            return response;
        }

    }
}
