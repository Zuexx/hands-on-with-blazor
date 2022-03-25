using AuthPermissions.AspNetCore.JwtTokenCode;
using HandsOnWithBlazor.Application.Queries;
using HandsOnWithBlazor.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace HandsOnWithBlazor.Application.Handlers
{
    public class SignInRequestHandler : IRequestHandler<SignInRequestQuery, ApiResponse<string>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenBuilder _tokenBuilder;

        public SignInRequestHandler(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ITokenBuilder tokenBuilder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<ApiResponse<string>> Handle(SignInRequestQuery request, CancellationToken cancellation)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            ApiResponse<string> response =
                new ApiResponse<string>(HttpStatusCode.OK.ToString(), string.Empty, string.Empty);

            if (!result.Succeeded)
            {
                response.Status = HttpStatusCode.BadRequest.ToString();
                response.Message = "Username or password is incorrect";

                return response;
            }
            var user = await _userManager.FindByEmailAsync(request.Email);

            response.Data = await _tokenBuilder.GenerateJwtTokenAsync(user.Id);

            return response;
        }
    }
}
