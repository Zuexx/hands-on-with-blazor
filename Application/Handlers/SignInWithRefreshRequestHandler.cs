using AuthPermissions.AspNetCore.JwtTokenCode;
using HandsOnWithBlazor.Application.Queries;
using HandsOnWithBlazor.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace HandsOnWithBlazor.Application.Handlers
{
    public class SignInWithRefreshRequestHandler : IRequestHandler<SignInWithRefreshRequestCommand, ApiResponse<TokenAndRefreshToken>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenBuilder _tokenBuilder;

        public SignInWithRefreshRequestHandler(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ITokenBuilder tokenBuilder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<ApiResponse<TokenAndRefreshToken>> Handle(SignInWithRefreshRequestCommand request, CancellationToken cancellation)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            ApiResponse<TokenAndRefreshToken> response =
                new ApiResponse<TokenAndRefreshToken>(HttpStatusCode.OK.ToString(), string.Empty, new TokenAndRefreshToken()) ;

            if (!result.Succeeded)
            {
                response.Status = HttpStatusCode.BadRequest.ToString();
                response.Message = "Username or password is incorrect";

                return response;
            }
            var user = await _userManager.FindByEmailAsync(request.Email);

            response.Data = await _tokenBuilder.GenerateTokenAndRefreshTokenAsync(user.Id);

            return response;
        }
    }
}
