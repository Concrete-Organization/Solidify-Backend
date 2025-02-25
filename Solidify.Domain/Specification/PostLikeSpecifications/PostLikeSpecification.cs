using Solidify.Domain.Entities.Community.Likes;

namespace Solidify.Domain.Specification.PostLikeSpecifications
{
    public class PostLikeSpecification : BaseSpecification<PostLike>
    {
        public PostLikeSpecification(string engineerId, int postId): base(p => p.EngineerId == engineerId && p.PostId == postId)
        {
            
        }
    }
}
