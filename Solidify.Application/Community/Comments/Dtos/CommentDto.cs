using Solidify.Application.Community.Helper;
using Solidify.Application.Community.Replies.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Comments.Dtos
{
    public class CommentDto : EngineerInfo
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int LikesCount { get; set; }
        public List<ReplyDto> Replies { get; set; }
    }
}
