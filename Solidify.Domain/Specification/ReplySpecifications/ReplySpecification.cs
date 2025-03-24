using Solidify.Domain.Entities.Community;

namespace Solidify.Domain.Specification.ReplySpecifications
{
    public class ReplySpecification : BaseSpecification<Reply>
    {
        public ReplySpecification(int replyId) : base(r => r.Id == replyId)
        {
            AddIncludes(c => c.Engineer);
            //AddIncludes($"{nameof(Comment.Replies)}.{nameof(Reply.Likes)}");
        }
    }
}
