using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Application.E_Commerce.Products.Queries.GetProdocutById;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            return await HandleCommand(new GetProductByIdQuery(id));
        }
    }
}
