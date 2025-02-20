using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Orders.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.OrderSpecifications;

namespace Solidify.Application.E_Commerce.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<GetOrderByIdQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var orderRepository = unitOfWork.GetRepository<Order>();

            var order = await orderRepository.GetAsync(new OrderSpecification(request.OrderId))
                        ?? throw new NotFoundException(nameof(Order), request.OrderId);

            var orderDetailsDto = mapper.Map<OrderDetailsDto>(order);
            orderDetailsDto.OrderItems = mapper.Map<List<OrderItemDto>>(order.Items);
            orderDetailsDto.ShippingAddress = mapper.Map<ShippingAddressDto>(order.ShippingAddress);

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, orderDetailsDto, "");
        }
    }
}
