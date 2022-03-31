using AuthPermissions.AspNetCore.Services;
using AuthPermissions.CommonCode;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Commands;
using HandsOnWithBlazor.Infrastructure.Security;
using HandsOnWithBlazor.Shared.Models;
using MediatR;
using System.Net;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate
{
    public class SignOutHandler : IRequestHandler<SignOutCommand, ApiResponse>
    {
        private readonly IDisableJwtRefreshToken _disableJwtRefreshToken;
        private readonly IUserAccessor _userAccessor;

        public SignOutHandler(
            IDisableJwtRefreshToken disableJwtRefreshToken,
            IUserAccessor userAccessor)
        {
            _disableJwtRefreshToken = disableJwtRefreshToken;
            _userAccessor = userAccessor; 
        }

        public async Task<ApiResponse> Handle(SignOutCommand request, CancellationToken cancellation)
        {
            var userId = _userAccessor.User.GetUserIdFromUser();
            await _disableJwtRefreshToken.MarkJwtRefreshTokenAsUsedAsync(userId);

            return new ApiResponse
            {
                Message = "Sign Out...",
                Status = HttpStatusCode.OK.ToString()
            };
        }       
    }
}
