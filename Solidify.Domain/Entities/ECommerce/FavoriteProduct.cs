using Solidify.Domain.Entities.Common;

namespace Solidify.Domain.Entities.ECommerce
{
    public class FavoriteProduct : Favorite
    {
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
