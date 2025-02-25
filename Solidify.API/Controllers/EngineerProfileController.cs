using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Enginners.Queries.GetEngineerQuery;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineerProfileController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEngineerProfile(string id)
        {
            return await HandleCommand(new GetEngineerQuery(id));   
        }
    }
}
