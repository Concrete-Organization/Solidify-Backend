namespace Solidify.Domain.Entities.Common
{
    public abstract class Favorite
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
