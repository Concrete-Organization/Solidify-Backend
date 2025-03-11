using Solidify.Domain.Entities.Community.Likes;

namespace Solidify.Domain.Specification.ReplyLikeSpecifications
{
    public class ReplyLikeSpecification : BaseSpecification<ReplyLike>
    {
        public ReplyLikeSpecification(string engineerId, int replyId) : base(r => r.EngineerId == engineerId && r.ReplyId == replyId)
        {
            
        }
    }
}
