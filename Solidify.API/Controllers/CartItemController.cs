using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.CartItems.Commands.AddCartItem;
using Solidify.Application.E_Commerce.CartItems.Commands.DecrementCartItem;
using Solidify.Application.E_Commerce.CartItems.Commands.DeleteCartItem;
using Solidify.Application.E_Commerce.CartItems.Commands.IncrementCartItem;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class CartItemController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("{productId}")]
        public async Task<IActionResult> AddCartItem(string productId)
        {
            return await HandleCommand(new AddCartItemCommand(productId));
        }
        
        [HttpPost("{productId}/increment")]
        public async Task<IActionResult> IncrementCartItem(string productId)
        {
            return await HandleCommand(new IncrementCartItemCommand(productId));
        }
        
        [HttpPost("{productId}/decrement")]
        public async Task<IActionResult> DecrementCartItem(string productId)
        {
            return await HandleCommand(new DecrementCartItemCommand(productId));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteCartItem(string productId)
        {
            return await HandleCommand(new DeleteCartItemCommand(productId));
        }
    }
}
