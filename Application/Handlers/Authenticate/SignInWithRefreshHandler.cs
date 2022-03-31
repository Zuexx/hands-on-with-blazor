using AuthPermissions.AspNetCore.JwtTokenCode;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Commands;
using HandsOnWithBlazor.Shared.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate
{
    public class SignInWithRefreshHandler : IRequestHandler<SignInWithRefreshCommand, ApiResponse<AuthResponseDto>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IMapper _mapper;

        public SignInWithRefreshHandler(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ITokenBuilder tokenBuilder,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenBuilder = tokenBuilder;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AuthResponseDto>> Handle(SignInWithRefreshCommand request, CancellationToken cancellation)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            ApiResponse<AuthResponseDto> response =
                new ApiResponse<AuthResponseDto>(HttpStatusCode.OK.ToString(), string.Empty, new AuthResponseDto()) ;

            if (!result.Succeeded)
            {
                response.Status = HttpStatusCode.BadRequest.ToString();
                response.Message = "Username or password is incorrect";                
                return response;
            }
            var user = await _userManager.FindByEmailAsync(request.Email);

            response.Data =  
                _mapper.Map<AuthResponseDto>(await _tokenBuilder.GenerateTokenAndRefreshTokenAsync(user.Id));

            return response;
        }
    }
}
