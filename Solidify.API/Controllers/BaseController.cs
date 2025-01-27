using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Dtos;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController(IMediator mediator) : ControllerBase
    {
        internal async Task<IActionResult> HandleCommand<TCommand>(TCommand command) where TCommand : IRequest<GeneralResponseDto>
        {
            var result = await mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }
    }
}
