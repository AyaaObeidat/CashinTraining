using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Profolio.Models;

namespace Profolio.Data
{
    public class ProfolioDbContext : DbContext
    {
        public ProfolioDbContext() { }
        public ProfolioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<Contact> contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .Property(p => p.ProfileStatus)
           .HasConversion<string>();
        }
    }
}
