using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Application.Services.Caching;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Interfaces.Services.Cashing;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler(IUnitOfWork unitOfWork,
        ICurrentUser currentUser,
        ICacheService cacheService) : IRequestHandler<CreateReviewCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var productRepository = unitOfWork.GetRepository<Product>();
            var product = await productRepository.GetAsync(new ProductsSpecification(request.ProductId))
                          ?? throw new NotFoundException(nameof(Product), request.ProductId);

            var userId = currentUser.GetUserId();

            var review = new ProductReview()
            {
                Id = Guid.NewGuid().ToString(), Message = request.Message, ConcreteCompanyId = userId,
                ProductId = request.ProductId, UserRate = request.UserRate
            };

            await unitOfWork.GetRepository<ProductReview>().AddAsync(review);
            product.CalculateRate();
            await unitOfWork.Commit();

            await cacheService.RemoveByPrefixAsync("product");

            return GeneralResponse.CreateResponse(true, StatusCodes.Status201Created, null,
                "Review Created Successfully");
        }
    }
}
