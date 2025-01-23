using Solidify.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Solidify.Domain.Entities
{
    public class Company
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public string CompanyName { get; set; }
        public string CommericalNumber { get; set; }
        public long TaxId { get; set; }
        public string CommericalLicense { get; set; }
        public string? CompanyWebSite { get; set; }
        public string? FaceBookAccout { get; set; }
        public string? InstagramAccount { get; set; }
        public string? TwitterAccount { get; set; }
        public string BankAccount { get; set; }
        public string PaymentTerm { get; set; }


        /// public CompanyType CompanyType { get; set; }
        public RegisterStatus Status { get; set; } = RegisterStatus.Pending;
        //  public string? AdminId { get; set; }
        //   public ApplicationUser? Admin { get; set; }
        //public virtual ICollection<ProductSubmissionRequest>? SubmissionRequests { get; set; } = new HashSet<ProductSubmissionRequest>();
    }
}
