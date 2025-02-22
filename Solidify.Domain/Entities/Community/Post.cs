namespace Solidify.Domain.Entities.Community
{
    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public List<string> ImageUris { get; set; } = new List<string>();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Like>? Likes { get; set; } = new HashSet<Like>();

    }
}
