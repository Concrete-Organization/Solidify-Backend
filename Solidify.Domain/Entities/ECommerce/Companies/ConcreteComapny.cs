using Solidify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Entities.ECommerce.Companies
{
    public class ConcreteCompany
    {
        [Key]
        [ForeignKey("User")]
        public string CompanyId { get; set; }
        public ApplicationUser User { get; set; }
        public string CompanyName { get; set; }
        public string? CommericalNumber { get; set; }
        public long TaxId { get; set; }
        public string CommericalLicense { get; set; }


        public string? ProfileImageUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Bio { get; set; }
    }
}
