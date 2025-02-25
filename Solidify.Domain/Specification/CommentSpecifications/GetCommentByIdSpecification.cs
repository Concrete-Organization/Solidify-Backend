using Solidify.Domain.Entities.Community;

namespace Solidify.Domain.Specification.CommentSpecifications
{
    public class GetCommentByIdSpecification : BaseSpecification<Comment>
    {
        public GetCommentByIdSpecification(int commentId) : base(c => c.Id == commentId)
        {

        }
    }
}
