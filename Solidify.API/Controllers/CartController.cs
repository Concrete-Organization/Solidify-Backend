using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Carts.Queries.GetCart;

namespace Solidify.API.Controllers
{
    public class CartController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
           return await HandleCommand(new GetCartQuery());
        }
    }
}
