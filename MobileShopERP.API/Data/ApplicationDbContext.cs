using Microsoft.EntityFrameworkCore;
using MobileShopERP.API.Models;

namespace MobileShopERP.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision
            modelBuilder.Entity<Product>()
                .Property(p => p.PurchasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.SellingPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Sale>()
                .Property(s => s.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SaleItem>()
                .Property(si => si.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SaleItem>()
                .Property(si => si.Total)
                .HasPrecision(18, 2);

            // Seed initial admin user
                modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1, // integer primary key
                        Username = "admin",
                        PasswordHash = "$2a$11$e0N9wVt8zHh3pYXzy4FZ..nA3YJxkK5H69YEXR5wOYUEd/Chy9FoO", // pre-hashed "admin123"
                        Role = "Admin",
                        FullName = "System Administrator",
                        Email = "admin@mobileshop.com",
                        Phone = "0000000000", // non-nullable
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 3, 3, 12, 0, 0) // static DateTime
                    }
                );
        }
    }
}