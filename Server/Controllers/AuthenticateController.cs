using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HandsOnWithBlazor.Shared.Models;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Queries;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Commands;

namespace HandsOnWithBlazor.Server.Controllers
{
    public class AuthenticateController : MediatRControllerBase
    {
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ApiResponse<string>> Authenticate(SignInQuery query)
            => await Mediator.Send(query);

        [AllowAnonymous]
        [HttpPost("signinwithrefresh")]
        public async Task<ApiResponse<TokenDto>> AuthenticateWithRefresh(SignInWithRefreshCommand command)
           => await Mediator.Send(command);

        [AllowAnonymous]
        [HttpPost]
        [Route("refreshauthentication")]
        public async Task<ApiResponse<TokenDto>> RefreshAuthentication(RefreshAuthenticationCommand command)
            => await Mediator.Send(command);

        [HttpPost]
        [Route("logout")]
        public async Task<ApiResponse> Logout()
            => await Mediator.Send(new SignOutCommand());

        [HttpGet]
        [Route("getuserpermissions")]
        public async Task<ApiResponse<List<string>>> GetUsersPermissions()
             => await Mediator.Send(new GetUserPermissionsQuery());
    }
}