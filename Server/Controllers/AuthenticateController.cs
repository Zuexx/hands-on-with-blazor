using HandsOnWithBlazor.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HandsOnWithBlazor.Shared.Models;
using AuthPermissions.AspNetCore.JwtTokenCode;

namespace HandsOnWithBlazor.Server.Controllers
{
    [AllowAnonymous]
    public class AuthenticateController : MediatRControllerBase
    {
        [HttpPost("signin")]
        public async Task<ApiResponse<string>> Authenticate(SignInRequestQuery query)
            => await Mediator.Send(query);

        [HttpPost("signinwithrefresh")]
        public async Task<ApiResponse<TokenAndRefreshToken>> AuthenticateWithRefresh(SignInWithRefreshRequestCommand command)
            => await Mediator.Send(command);

        /*
        [HttpPost]
        [Route("refreshauthentication")]
        public async Task<ActionResult<TokenAndRefreshToken>> RefreshAuthentication(TokenAndRefreshToken tokenAndRefresh)
        {
            var result = await _tokenBuilder.RefreshTokenUsingRefreshTokenAsync(tokenAndRefresh);
            if (result.updatedTokens != null)
                return result.updatedTokens;

            return StatusCode(result.HttpStatusCode);
        }

        [Authorize]
        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult> Logout([FromServices] IDisableJwtRefreshToken service)
        {
            var userId = User.GetUserIdFromUser();
            await service.MarkJwtRefreshTokenAsUsedAsync(userId);

            return Ok();
        }

        [HttpGet]
        [Route("getuserpermissions")]
        public ActionResult<List<string>> GetUsersPermissions([FromServices] IUsersPermissionsService service)
        {
            return service.PermissionsFromUser(User);
        }
        */
    }
}