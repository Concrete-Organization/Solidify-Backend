using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Brands.Queries;
using Solidify.Application.E_Commerce.Brands.Queries.GetBandQuery;
using Solidify.Application.E_Commerce.Carts.Queries.GetCart;
using Solidify.Application.E_Commerce.Categories.Queries;
using Solidify.Application.E_Commerce.Categories.Query.GetAllCategories;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBrandsQuery query)
        {
            return await HandleCommand(query);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, [FromQuery] GetBrandQuery query)
        {
            query.Id = Id;
            return await HandleCommand(query);
        }
    }
}
