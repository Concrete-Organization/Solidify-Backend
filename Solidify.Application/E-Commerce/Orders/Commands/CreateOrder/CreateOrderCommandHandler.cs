using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.E_Commerce.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IUnitOfWork unitOfWork,
        ICacheService cacheService,
        IMapper mapper,
        ICurrentUser user) : IRequestHandler<CreateOrderCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var cart = await cacheService.GetAsync<Cart>("cart", () => Task.FromResult(new Cart()),
                TimeSpan.FromDays(15));

            if (cart.Items.IsNullOrEmpty())
                return GeneralResponse.CreateResponse(false, StatusCodes.Status405MethodNotAllowed, null,
                    "There is no products to order");

            var orderRepository = unitOfWork.GetRepository<Order>();
            var orderItemRepository = unitOfWork.GetRepository<OrderItem>();

            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.GetUserId(),
                TotalPrice = cart.TotalPrice
            };

            await orderRepository.AddAsync(order);

            var orderItems = mapper.Map<IEnumerable<OrderItem>>(cart.Items).Select(o =>
            {
                o.OrderId = order.Id;
                return o;
            });

            await orderItemRepository.AddRangeAsync(orderItems);

            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null,
                $"Order #[{order.Id}] Created successfully");
        }
    }
}
