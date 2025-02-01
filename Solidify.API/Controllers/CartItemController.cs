using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.CartItems.Commands.AddCartItem;

namespace Solidify.API.Controllers
{
    [Route("api/[controller]")]
    public class CartItemController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("{id}")]
        public async Task<IActionResult> AddCartItem(string id)
        {
            return await HandleCommand(new AddCartItemCommand(id));
        }
    }
}
