using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Products.Commands.UpdateProduct;
using Solidify.Application.Enginners.Commands.DeleteEngineerProfile;
using Solidify.Application.Enginners.Commands.UpdateEngineerProfile;
using Solidify.Application.Enginners.Dtos;
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProfile([FromRoute] string id, [FromForm] UpdateEngineerDto dto)
        {
            var a = new UpdateEngineerProfileCommand()
            {
                Id = id,
                ProfileImageUrl = dto.ProfileImageUrl
            };

            return await HandleCommand(a);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(string id)
        {
            return await HandleCommand(new DeleteEngineerProfileCommand(id));
        }

    }
}
