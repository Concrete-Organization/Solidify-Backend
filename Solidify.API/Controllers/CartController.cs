using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Carts.Queries.GetCart;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class CartController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
           return await HandleCommand(new GetCartQuery());
        }
    }
}
