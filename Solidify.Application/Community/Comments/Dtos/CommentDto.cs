namespace Solidify.Application.Community.Comments.Dtos
{
    public class CommentDto
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string UserImageUri { get; set; }

    }
}
