using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnWithBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediatRControllerBase : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
