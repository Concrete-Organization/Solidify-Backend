using Solidify.Domain.Entities.Community.Likes;

namespace Solidify.Domain.Entities.Community
{
    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public List<string> ImageUris { get; set; } = new List<string>();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string EngineerId { get; set; }
        public Engineer Engineer { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<PostLike>? Likes { get; set; } = new HashSet<PostLike>();

    }
}
