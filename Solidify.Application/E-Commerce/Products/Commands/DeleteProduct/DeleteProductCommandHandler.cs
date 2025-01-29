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

namespace Solidify.Application.E_Commerce.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IUnitOfWork unitOfWork,
        IFileService fileService) : IRequestHandler<DeleteProductCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productRepository = unitOfWork.GetRepository<Product>();

            var product = await productRepository.GetAsync(new ProductsSpecification(request.Id)) 
                          ?? throw new NotFoundException(nameof(Product), request.Id);

            if (!String.IsNullOrEmpty(product.ImageUri))
            {
                fileService.DeleteFile(product.ImageUri, FileType.ProductImage);
            }

            productRepository.Delete(product);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null,
                $"Product with id [{request.Id}] deleted successfully");
        }
    }
}
