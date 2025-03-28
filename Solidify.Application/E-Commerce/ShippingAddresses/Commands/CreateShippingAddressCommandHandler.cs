using AutoMapper;
using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Application.Common;

namespace Solidify.Application.E_Commerce.ShippingAddresses.Commands
{
    public class CreateShippingAddressCommandHandler(IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateShippingAddressCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreateShippingAddressCommand request, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetRepository<ShippingAddress>();
            var shippingAddress = mapper.Map<ShippingAddress>(request);
            await repo.AddAsync(shippingAddress);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, 201, shippingAddress, "");
        }
    }
}
