using Solidify.Application.Companies.Dtos;

namespace Solidify.Application.E_Commerce.Reviews.Dtos
{
    public class ReviewDto : CompanyInfoDto
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public int UserRate { get; set; }
    }
}
