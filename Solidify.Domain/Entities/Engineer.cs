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

        public string? EngineerName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Bio {  get; set; }

    }
}
