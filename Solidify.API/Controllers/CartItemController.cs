using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.CartItems.Commands.AddCartItem;
using Solidify.Application.E_Commerce.CartItems.Commands.DecrementCartItem;
using Solidify.Application.E_Commerce.CartItems.Commands.DeleteCartItem;
using Solidify.Application.E_Commerce.CartItems.Commands.IncrementCartItem;

namespace Solidify.API.Controllers
{
    public class CartItemController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("{id}")]
        public async Task<IActionResult> AddCartItem(string id)
        {
            return await HandleCommand(new AddCartItemCommand(id));
        }
        
        [HttpPost("{id}/increment")]
        public async Task<IActionResult> IncrementCartItem(string id)
        {
            return await HandleCommand(new IncrementCartItemCommand(id));
        }
        
        [HttpPost("{id}/decrement")]
        public async Task<IActionResult> DecrementCartItem(string id)
        {
            return await HandleCommand(new DecrementCartItemCommand(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(string id)
        {
            return await HandleCommand(new DeleteCartItemCommand(id));
        }
    }
}
