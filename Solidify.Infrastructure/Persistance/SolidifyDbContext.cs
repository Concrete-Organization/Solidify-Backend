using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities;

namespace Solidify.Infrastructure.Persistance
{
    public class SolidifyDbContext : IdentityDbContext<ApplicationUser>
    {
        public SolidifyDbContext(DbContextOptions<SolidifyDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
