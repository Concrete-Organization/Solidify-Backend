using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Reviews.Dtos;

namespace Solidify.Application.E_Commerce.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : CreateReviewDto, IRequest<GeneralResponseDto>
    {
        public string ProductId { get; set; }
    }
}
