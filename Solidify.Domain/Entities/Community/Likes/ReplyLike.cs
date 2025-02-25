namespace Solidify.Domain.Entities.Community.Likes
{
    public class ReplyLike : Like
    {
        public int ReplyId { get; set; }
        public Reply Reply { get; set; }
    }
}
