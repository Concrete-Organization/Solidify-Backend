using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities.Community;

namespace Solidify.Domain.Specification.PostSpecifications
{
    public class PostSpecification : BaseSpecification<Post>
    {
        public PostSpecification(PostSpecificationParameters args): base(p => (
        String.IsNullOrEmpty(args.SearchedPhrase) || EF.Functions.Like(p.Content.ToLower(), $"%{args.SearchedPhrase.ToLower()}%")
            ))
        {
            AddIncludes(p => p.Comments);
            AddIncludes(p => p.Likes);
            AddPagination(args.PageSize, (args.PageNumber - 1) * args.PageSize);
            AddSortAsc(p => p.CreationDate);
        }
    }
}
