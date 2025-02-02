using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.Common.User;
using Solidify.Application.E_Commerce.Orders.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.OrderSpecifications;

namespace Solidify.Application.E_Commerce.Orders.Queries.GetAllOrders;

public class GetAllOrdersQueryHandle(IUnitOfWork unitOfWork,
    IMapper mapper,
    ICurrentUser user) : IRequestHandler<GetAllOrdersQuery, GeneralResponseDto>
{
    public async Task<GeneralResponseDto> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orderRepository = unitOfWork.GetRepository<Order>();

        var (orders, count) =
            await orderRepository.GetAllAsync(new OrderSpecification(user.GetUserId(), request.ActiveOrders
                ? new OrderStatus[]
                {
                    OrderStatus.Pending, OrderStatus.Approved, OrderStatus.Processing, OrderStatus.Shipped
                }
                : new OrderStatus[]
                {
                    OrderStatus.Deliverd, OrderStatus.Cancelled, OrderStatus.Refunded
                }, request.PageSize, request.PageNumber));

        return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK,
            new PagedResponse<GetAllOrdersDto>(mapper.Map<IEnumerable<GetAllOrdersDto>>(orders), request.PageSize,
                request.PageNumber, count),
            "");
    }
}