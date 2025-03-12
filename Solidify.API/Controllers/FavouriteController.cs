using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Favourites.Commands.FavouriteProduct;
using Solidify.Application.E_Commerce.Favourites.Commands.UnFavouriteProduct;
using Solidify.Application.E_Commerce.Favourites.Queries.GetFavouriteProducts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class FavouriteController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet("products")]
        public async Task<IActionResult> GetFavouriteProduct()
        {
            return await HandleCommand(new GetFavouriteProductsQuery());
        }

        [HttpPost("product/{productId}")]
        public async Task<IActionResult> FavouriteProduct([FromRoute]FavouriteProductCommand command)
        {
            return await HandleCommand(command);
        }       
        
        [HttpDelete("product/{productId}")]
        public async Task<IActionResult> UnFavouriteProduct([FromRoute]UnFavouriteProductCommand command)
        {
            return await HandleCommand(command);
        }
    }
}
