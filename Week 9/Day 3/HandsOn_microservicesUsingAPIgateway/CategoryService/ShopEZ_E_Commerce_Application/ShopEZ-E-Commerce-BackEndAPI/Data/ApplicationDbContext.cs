using Microsoft.EntityFrameworkCore;
using ShopEZ_E_Commerce.API.Models;

namespace ShopEZ_E_Commerce.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UNIQUE PRODUCT NAME
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            // DECIMAL PRECISION FIX (VERY IMPORTANT)
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            // ORDER -> ORDER ITEMS
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // PRODUCT -> ORDER ITEMS
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId);

            // USER -> ORDERS (IMPORTANT)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
