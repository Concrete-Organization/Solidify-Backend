using Solidify.Domain.Entities.ECommerce.Companies;

namespace Solidify.Domain.Entities.ECommerce
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; } = new HashSet<Product>();
    }
}
