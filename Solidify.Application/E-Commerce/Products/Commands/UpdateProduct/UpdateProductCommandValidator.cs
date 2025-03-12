using FluentValidation;
using Solidify.Application.E_Commerce.Products.Dtos;

namespace Solidify.Application.E_Commerce.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price Cannot be Negative value");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock Cannot be Negative value");
        }
    }
}
