using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Entities.Community.Likes;
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
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<ReplyLike> ReplyLikes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<PostLike>()
            //    .HasKey(pl => pl.Id);
            //modelBuilder.Entity<PostLike>()
            //    .HasOne(pl => pl.Post)
            //    .WithMany(p => p.Likes)
            //    .HasForeignKey(pl => pl.PostId);

            //modelBuilder.Entity<CommentLike>()
            //    .HasKey(cl => cl.Id);
            //modelBuilder.Entity<CommentLike>()
            //    .HasOne(cl => cl.Comment)
            //    .WithMany(c => c.Likes)
            //    .HasForeignKey(cl => cl.CommentId);

            //modelBuilder.Entity<ReplyLike>()
            //    .HasKey(rl => rl.Id);
            //modelBuilder.Entity<ReplyLike>()
            //    .HasOne(rl => rl.Reply)
            //    .WithMany(r => r.Likes)
            //    .HasForeignKey(rl => rl.ReplyId);
        }
    }
}
