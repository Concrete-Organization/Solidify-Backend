using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;

namespace Solidify.Application.E_Commerce.Products.Commands
{
    public class CreateProductCommandHandler(IUnitOfWork unitOfWork,
        IMapper mapper) 
        : IRequestHandler<CreateProductCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productRepository = unitOfWork.GetRepository<Product>();

            await productRepository.AddAsync(mapper.Map<Product>(request));
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status201Created, null,
                "Product Created Successfully");
        }
    }
}
