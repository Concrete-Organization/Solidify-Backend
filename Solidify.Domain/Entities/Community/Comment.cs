using Solidify.Domain.Entities.Community.Likes;

namespace Solidify.Domain.Entities.Community
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string EngineerId { get; set; }
        public Engineer Engineer { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Reply>? Replies { get; set; } = new HashSet<Reply>();
        public virtual ICollection<CommentLike>? Likes { get; set; } = new HashSet<CommentLike>();
    }
}
