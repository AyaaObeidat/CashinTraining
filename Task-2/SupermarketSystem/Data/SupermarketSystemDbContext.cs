using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SupermarketSystem.Models;
using System.Reflection.Metadata;

namespace SupermarketSystem.Data
{
    public class SupermarketSystemDbContext : DbContext
    {
        public SupermarketSystemDbContext() { }

        public SupermarketSystemDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country>  Countries{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
               .Property(o => o.TotalPrice)
               .HasColumnType("decimal(18, 2)");


            modelBuilder.Entity<Order>()
           .Property(o => o.Status)
           .HasConversion<string>();

        }
    }
    
}
