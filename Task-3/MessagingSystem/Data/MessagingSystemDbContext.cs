using MessagingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Data
{
    public class MessagingSystemDbContext : DbContext
    {
        public MessagingSystemDbContext() { }
        public MessagingSystemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageDistination> MessageDistinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
           .Property(o => o.Status)
           .HasConversion<string>();

            modelBuilder.Entity<MessageDistination>()
           .Property(o => o.Box)
           .HasConversion<string>();

        }
    }
}
