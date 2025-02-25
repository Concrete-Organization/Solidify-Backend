using Solidify.Domain.Entities.Community.Likes;

namespace Solidify.Domain.Entities.Community
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string EngineerId { get; set; }
        public Engineer Engineer { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ICollection<ReplyLike>? Likes { get; set; } = new HashSet<ReplyLike>();
    }
}
