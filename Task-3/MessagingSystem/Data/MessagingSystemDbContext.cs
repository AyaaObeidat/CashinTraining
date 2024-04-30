using MessagingSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace MessagingSystem.Data
{
    public class MessagingSystemDbContext : DbContext
    {
       
        protected MessagingSystemDbContext()
        {
        }
        public MessagingSystemDbContext(DbContextOptions options) : base(options)
        {
        }
           
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
           .Property(o => o.Status1)
           .HasConversion<string>();

            modelBuilder.Entity<Message>()
           .Property(o => o.Status2)
           .HasConversion<string>();

        }

    }
}
