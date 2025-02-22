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
                .MaximumLength(200)
                .WithMessage("The Content field must not exceed 200 characters.");
        }
    }
}
