namespace Solidify.Domain.Entities.Common
{
    public abstract class Review
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public int UserRate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
