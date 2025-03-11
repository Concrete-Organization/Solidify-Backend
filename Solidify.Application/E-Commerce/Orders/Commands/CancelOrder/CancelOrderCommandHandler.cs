using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.OrderSpecifications;

namespace Solidify.Application.E_Commerce.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CancelOrderCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var orderRepository = unitOfWork.GetRepository<Order>();

            var order = await orderRepository.GetAsync(new OrderSpecification(request.OrderId))
                        ?? throw new NotFoundException(nameof(Order), request.OrderId);

            if (order.OrderStatus != OrderStatus.Pending)
                return GeneralResponse.CreateResponse(false, StatusCodes.Status400BadRequest, null,
                    "Order status is not pending to cancel");

            order.OrderStatus = OrderStatus.Cancelled;
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null,
                $"Order #{request.OrderId} canceled successfully");
        }
    }
}
