using FluentValidation;

namespace Solidify.Application.E_Commerce.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(50);

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price Cannot be Negative value");

        RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock Cannot be Negative value");

        RuleFor(p => p.Description)
            .MaximumLength(500);

    }
}