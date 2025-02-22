using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Helper;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Dtos
{
    public class PostDto : EngineerInfo
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Content { get; set; }
        public List<string> ImageUris { get; set; }
        public  List<CommentDto> Comments { get; set; }
        public  List<Like> Likes { get; set; }

    }
}
