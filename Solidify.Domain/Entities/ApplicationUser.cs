using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string? Address { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? RegisterDate { get; set; }  

        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public virtual ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
        //public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
        //public virtual ICollection<Like>? likes { get; set; } = new HashSet<Like>();
        //public virtual ICollection<Post>? Posts { get; set; } = new HashSet<Post>();
        //public virtual ICollection<Notification>? Notifications { get; set; } = new HashSet<Notification>();
        //public virtual ICollection<Session>? Sessions { get; set; } = new HashSet<Session>();
    }
}
