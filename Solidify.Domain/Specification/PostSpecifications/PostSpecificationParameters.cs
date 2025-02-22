using Solidify.Domain.Enums;

namespace Solidify.Domain.Specification.PostSpecifications
{
    public class PostSpecificationParameters
    {
        public string? SearchedPhrase { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
