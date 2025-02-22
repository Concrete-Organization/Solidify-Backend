namespace Solidify.Domain.Entities.Community
{
    public class Like
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
