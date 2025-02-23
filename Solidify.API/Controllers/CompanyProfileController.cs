using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Companies.Queries.GetCompanyQuery;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfileController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return await HandleCommand(new GetCompanyQuery(id));
        }
    }
}
