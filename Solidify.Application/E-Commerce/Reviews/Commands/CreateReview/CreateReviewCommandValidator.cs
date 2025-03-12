using FluentValidation;
using Solidify.Application.E_Commerce.Reviews.Dtos;

namespace Solidify.Application.E_Commerce.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(r => r.Message)
                .MaximumLength(500)
                .WithMessage("Review message cannot exceed 500 letter.");

            RuleFor(r => r.UserRate)
                .InclusiveBetween(1, 10)
                .WithMessage($"UserRate must be between 1 and 10.");
        }
    }
}
