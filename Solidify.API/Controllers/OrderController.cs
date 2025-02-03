using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Orders.Commands.CreateOrder;
using Solidify.Application.E_Commerce.Orders.Queries.GetAllOrders;

namespace Solidify.API.Controllers
{
    [Authorize]
    public class OrderController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery]GetAllOrdersQuery query)
        {
            return await HandleCommand(query);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            return await HandleCommand(new CreateOrderCommand());
        }
    }
}
