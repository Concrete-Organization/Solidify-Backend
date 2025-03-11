using FluentValidation;

namespace Solidify.Application.E_Commerce.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(r => r.Message)
                .MaximumLength(500)
                .WithMessage("Review message cannot exceed 500 letter.");

            RuleFor(r => r.UserRate)
                .LessThanOrEqualTo(10)
                .GreaterThanOrEqualTo(1)
                .WithMessage("UserRate must be between 0 and 10.");
        }
    }
}
