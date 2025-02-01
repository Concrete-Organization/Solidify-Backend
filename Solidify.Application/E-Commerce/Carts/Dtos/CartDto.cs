using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.Carts.Dtos;

public class CartDto
{
    public decimal TotalPrice { get; set; }
    public virtual ICollection<CartItem>? Items { get; set; }
}