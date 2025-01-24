using Solidify.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Solidify.Domain.Entities
{
    public class Engineer 
    {
        [Key]
        [ForeignKey("User")]
        public string EngineerId { get; set; }
        public ApplicationUser User { get; set; }
        public string? Cv { get; set; } 

        public string? SyndicateCard { get; set; }
        public int? ExperienceYear { get; set; }
        public RegisterStatus Status { get; set; } = RegisterStatus.Pending;
    }
}
