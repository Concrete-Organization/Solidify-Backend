using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Files;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IUnitOfWork unitOfWork,
        IMapper mapper,
        IFileService fileService,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateProductCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productRepository = unitOfWork.GetRepository<Product>();
            var product = await productRepository.GetAsync(new ProductsSpecification(request.Id))
                          ?? throw new NotFoundException(nameof(Product), request.Id);


            if (request.Image is not null)
            {
                var imageUploadResult = await fileService.UploadFileAsync(request.Image, FileType.ProductImage);

                if (!imageUploadResult.IsSucceeded)
                    return imageUploadResult;

                fileService.DeleteFile(product.ImageUri, FileType.ProductImage);

                product.ImageUri = imageUploadResult.Model.ToString();
            }


            productRepository.Update(mapper.Map(request, product));
            await unitOfWork.Commit();

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            var productUri = $"{baseUri}/api/product/{product.Id}";

            return GeneralResponse.CreateResponse(true, StatusCodes.Status201Created, productUri,
                "Product Updated Successfully");
        }
    }
}
