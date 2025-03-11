using Solidify.Domain.Enums;

namespace Solidify.Domain.Entities.Community.Likes
{
    public abstract class Like
    {
        public int Id { get; set; }
        public string EngineerId { get; set; }
        public virtual Engineer? Engineer { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
