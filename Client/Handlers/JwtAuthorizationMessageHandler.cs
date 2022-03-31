using HandsOnWithBlazor.Client.Models;
using HandsOnWithBlazor.Client.Services;
using System.Net.Http.Headers;

namespace HandsOnWithBlazor.Client.Handlers
{
    public class JwtAuthorizationMessageHandler : DelegatingHandler
    {
        private SimpleStateContainerService<SimpleStateModel> _stateService { get; set; } = default!;

        public JwtAuthorizationMessageHandler(SimpleStateContainerService<SimpleStateModel> stateService)
        { 
            _stateService = stateService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //getting token from the state service
            var jwtToken = _stateService.Value.Token;

            //adding the token in authorization header
            if (jwtToken != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            //sending the request
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
