using FluentValidation;
using Solidify.Application.Community.Comments.Dtos;

namespace Solidify.Application.Community.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .WithMessage("Content is required.")
                .MaximumLength(500)
                .WithMessage("Content must not exceed 500 characters.");
        }
    }
}
