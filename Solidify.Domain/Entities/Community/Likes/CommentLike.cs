namespace Solidify.Domain.Entities.Community.Likes
{
    public class CommentLike : Like
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
