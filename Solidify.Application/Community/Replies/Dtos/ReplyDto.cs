using Solidify.Application.Community.Helper;

namespace Solidify.Application.Community.Replies.Dtos
{
    public class ReplyDto : EngineerInfo
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int LikesCount { get; set; }
    }
}
