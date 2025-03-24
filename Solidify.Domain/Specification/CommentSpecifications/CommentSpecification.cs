using Solidify.Domain.Entities.Community;

namespace Solidify.Domain.Specification.CommentSpecifications
{
    public class CommentSpecification : BaseSpecification<Comment>
    {
        public CommentSpecification(int postId): base(c => c.PostId == postId)
        {
            AddIncludes(c => c.Engineer);
            AddIncludes($"{nameof(Comment.Replies)}.{nameof(Reply.Likes)}");
            AddIncludes($"{nameof(Comment.Replies)}.{nameof(Reply.Engineer)}");
            AddIncludes(c => c.Likes);
        }
    }
}
