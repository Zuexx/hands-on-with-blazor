using AuthPermissions.AspNetCore.JwtTokenCode;
using HandsOnWithBlazor.Application.Handlers.Authenticate.Commands;
using HandsOnWithBlazor.Shared.Models;
using MapsterMapper;
using MediatR;
using System.Net;

namespace HandsOnWithBlazor.Application.Handlers.Authenticate
{
    public class RefreshAuthenticationHandler : IRequestHandler<RefreshAuthenticationCommand, ApiResponse<AuthResponseDto>>
    {
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IMapper _mapper;

        public RefreshAuthenticationHandler(
            ITokenBuilder tokenBuilder,
            IMapper mapper)
        {
            _tokenBuilder = tokenBuilder;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AuthResponseDto>> Handle(RefreshAuthenticationCommand request, CancellationToken cancellation)
        {            
            var result =
                await _tokenBuilder.RefreshTokenUsingRefreshTokenAsync(
                    new TokenAndRefreshToken { Token = request.Token, RefreshToken = request.RefreshToken });

            ApiResponse<AuthResponseDto> response =
                new ApiResponse<AuthResponseDto>(HttpStatusCode.OK.ToString(), string.Empty, new AuthResponseDto()) ;

            if (result.updatedTokens ==null)
            {
                response.Message = "Something wrong to persist the refresh authentication request";
                response.Status = ((HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), result.HttpStatusCode)).ToString();
                return response;
            }
            
            response.Data =
                _mapper.Map<AuthResponseDto>(result.updatedTokens);

            return response;
        }       
    }
}
