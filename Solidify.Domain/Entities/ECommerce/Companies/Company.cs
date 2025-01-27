﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Solidify.Domain.Enums;

namespace Solidify.Domain.Entities.ECommerce.Companies
{
    public class Company
    {
        [Key]
        [ForeignKey("User")]
        public string CompanyId { get; set; }
        public ApplicationUser User { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string? CommericalNumber { get; set; }
        public long TaxId { get; set; }
        public string CommericalLicense { get; set; }
        public string? CompanyWebSite { get; set; }
        public string? FaceBookAccout { get; set; }
        public string? InstagramAccount { get; set; }
        public string? TwitterAccount { get; set; }
        public string? BankAccount { get; set; }
        public string? PaymentTerm { get; set; }
        public CompanyType CompanyType { get; set; }
        public RegisterStatus Status { get; set; } = RegisterStatus.Pending;
        public string? AdminId { get; set; }
        public virtual ApplicationUser? Admin { get; set; }
    }
}
