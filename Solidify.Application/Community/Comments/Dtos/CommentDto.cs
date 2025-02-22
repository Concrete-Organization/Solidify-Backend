using Solidify.Application.Community.Helper;

namespace Solidify.Application.Community.Comments.Dtos
{
    public class CommentDto : EngineerInfo
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
