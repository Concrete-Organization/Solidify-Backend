using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Entities.ECommerce.Companies;

namespace Solidify.Infrastructure.Persistance
{
    public class SolidifyDbContext : IdentityDbContext<ApplicationUser>
    {
        public SolidifyDbContext(DbContextOptions<SolidifyDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierSales> SupplierSales { get; set; }
        public DbSet<ConcreteCompany> ConcreteCompanies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
