using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Dtos
{
    public class PostDto
    {
        public string? Content { get; set; }
        public List<string> ImageUris { get; set; }
        public  List<Comment> Comments { get; set; }
        public  List<Like> Likes { get; set; }

    }
}
