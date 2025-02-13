using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Products.Commands.CreateProduct;
using Solidify.Application.Files;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;
using Solidify.Domain.Interfaces;
using System.Net.Http;

namespace Solidify.Application.E_Commerce.Products.Commands
{
    public class CreateProductCommandHandler(IUnitOfWork unitOfWork,
        IMapper mapper,
        IFileService fileService,
        IHttpContextAccessor httpContextAccessor) 
        : IRequestHandler<CreateProductCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productRepository = unitOfWork.GetRepository<Product>();
            var product = mapper.Map<Product>(request);

            product.Id = Guid.NewGuid().ToString();

            if (request.Image is not null)
            {
                var imageUploadResult = await fileService.UploadFileAsync(request.Image, FileType.ProductImage);

                if (!imageUploadResult.IsSucceeded)
                    return imageUploadResult;

                product.ImageUri = imageUploadResult.Model.ToString();
            }
            else
            {
                product.ImageUri = String.Empty;
            }

            await productRepository.AddAsync(product);
            await unitOfWork.Commit();

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            var productUri = $"{baseUri}/api/product/{product.Id}";

            return GeneralResponse.CreateResponse(true, StatusCodes.Status201Created, productUri,
                "Product Created Successfully");
        }
    }
}
