using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Models;

namespace SupermarketSystem.Data
{
    public class SupermarketSystemDbContext : DbContext
    {
        public SupermarketSystemDbContext() { }

        public SupermarketSystemDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    
}
