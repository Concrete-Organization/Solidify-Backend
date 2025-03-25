using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.E_Commerce.Orders.Commands.CancelOrder;
using Solidify.Application.E_Commerce.Orders.Commands.CreateOrder;
using Solidify.Application.E_Commerce.Orders.Queries.GetAllOrders;
using Solidify.Application.E_Commerce.Orders.Queries.GetOrderById;

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

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            return await HandleCommand(new GetOrderByIdQuery(orderId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            return await HandleCommand(command);
        }

        [HttpPost("cancel/{orderId}")]
        public async Task<IActionResult> CancelOrder(string orderId)
        {
            return await HandleCommand(new CancelOrderCommand(orderId));
        }
    }
}
