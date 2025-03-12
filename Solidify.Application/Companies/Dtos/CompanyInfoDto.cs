namespace Solidify.Application.Companies.Dtos
{
    public abstract class CompanyInfoDto
    {
        public string ConcreteCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
