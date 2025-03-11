using Solidify.Domain.Entities.Community.Likes;

namespace Solidify.Domain.Specification.CommentLikeSpecifications
{
    public class CommentLikeSpecification : BaseSpecification<CommentLike>
    {
        public CommentLikeSpecification(int commentId) : base(p => p.CommentId == commentId)
        {
            
        }
        public CommentLikeSpecification(string engineerId, int commentId): base(p => p.CommentId == commentId && p.EngineerId == engineerId)
        {
            
        }
    }
}
