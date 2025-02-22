using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Solidify.Domain.Enums;

namespace Solidify.Domain.Entities.ECommerce.Companies
{
    public class Supplier
    {
        [Key]
        [ForeignKey("User")]
        public string SupplierId { get; set; }
        public ApplicationUser User { get; set; }
        public string? SupplierName { get; set; }
        public string? CommericalNumber { get; set; }
        public long TaxId { get; set; }
        public string CommericalLicense { get; set; }
        public RegisterStatus Status { get; set; } = RegisterStatus.Pending;
    }
}
