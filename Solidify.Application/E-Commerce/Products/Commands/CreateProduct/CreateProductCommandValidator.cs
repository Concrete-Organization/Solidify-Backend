using FluentValidation;

namespace Solidify.Application.E_Commerce.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("The product name is required.")
            .MaximumLength(50)
            .WithMessage("The product name must not exceed 50 characters.");

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("The price cannot be a negative value.");

        RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("The stock quantity cannot be negative.");

        RuleFor(p => p.Description)
            .MaximumLength(500)
            .WithMessage("The product description must not exceed 500 characters.");

        RuleFor(p => p.Measurement)
            .IsInEnum()
            .WithMessage("The measurement unit is invalid.");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0)
            .WithMessage("The category ID must be a positive number.")
            .NotEmpty()
            .WithMessage("The company ID is required and cannot be empty.");

        RuleFor(p => p.BrandId)
            .GreaterThan(0)
            .WithMessage("The brand ID must be a positive number. Please ")
            .NotEmpty()
            .WithMessage("The company ID is required and cannot be empty.");

        RuleFor(p => p.CompanyId)
            .NotEmpty()
            .WithMessage("The company ID is required and cannot be empty.");
    }
}