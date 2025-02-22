using FluentValidation;

namespace Solidify.Application.Community.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(1000)
                .WithMessage("The Content must not exceed 1000 characters.");


            RuleFor(p => p.ImageUris)
                .Must(p => p.Count <= 5)
                .WithMessage("You can upload up to 5 images");
        }
    }
}
