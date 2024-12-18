﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Solidify.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string? Address { get; set; }
        public bool IsDeleted { get; set; } = false;
        //public virtual Cart Cart { get; set; }
        //public virtual ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
        //public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
        //public virtual ICollection<Like>? likes { get; set; } = new HashSet<Like>();
        //public virtual ICollection<Post>? Posts { get; set; } = new HashSet<Post>();
        //public virtual ICollection<Notification>? Notifications { get; set; } = new HashSet<Notification>();
        //public virtual ICollection<Session>? Sessions { get; set; } = new HashSet<Session>();
    }
}
