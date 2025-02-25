namespace Solidify.Domain.Entities.Community.Likes
{
    public class PostLike : Like
    {
        public int PostId { get; set; }
        public Post Comment { get; set; }
    }
}
