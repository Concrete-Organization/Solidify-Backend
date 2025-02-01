using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Orders.Commands.CreateOrder;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class OrderController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var userId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            return await HandleCommand(new CreateOrderCommand(userId));
        }
    }
}
