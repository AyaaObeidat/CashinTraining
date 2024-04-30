using Messaging_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Messaging_System.Data
{
    public class MessagingSystemDbContext : DbContext
    {
        public MessagingSystemDbContext()
        {
        }

        public MessagingSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<Message>()
           .Property(o => o.Status)
           .HasConversion<string>();

        }


    }
}
