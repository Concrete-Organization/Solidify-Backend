using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Application.E_Commerce.Products.Commands.DeleteProduct;
using Solidify.Application.E_Commerce.Products.Commands.UpdateProduct;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Application.E_Commerce.Products.Queries.GetAllProducts;
using Solidify.Application.E_Commerce.Products.Queries.GetProdocutById;

namespace Solidify.API.Controllers
{
    public class ProductController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsQuery query)
        {
            return await HandleCommand(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            return await HandleCommand(new GetProductByIdQuery(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]CreateProductCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]string id, [FromForm]UpdateProductDto dto)
        {
            var command = new UpdateProductCommand()
            {
                Id = id,
                Image = dto.Image,
                Price = dto.Price,
                Stock = dto.Stock
            };

            return await HandleCommand(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            return await HandleCommand(new DeleteProductCommand(id));
        }
    }
}
