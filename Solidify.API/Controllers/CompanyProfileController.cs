using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Companies.Commands.UpdateCompanyProfile;
using Solidify.Application.Companies.Dtos;
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
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProfile(string id,[FromForm] UpdateCompanyDto dto)
        {
            var command = new UpdateCompanyProfileCommand
            {
                Id = id,
                CoverImageUrl = dto.CoverImageUrl,
                CompanyName = dto.CompanyName,
                ProfileImageUrl = dto.ProfileImageUrl,
                Bio = dto.Bio,
                UserName = dto.UserName,
            };
            return await HandleCommand(command);
        }
    }
}
