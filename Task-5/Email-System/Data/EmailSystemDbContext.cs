using Email_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Email_System.Data
{
    public class EmailSystemDbContext : DbContext
    {
        public EmailSystemDbContext() { }

        public EmailSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageDestination> MessageDestinations { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }
        public DbSet<InboxMessages> InboxMessages { get; set; }
        public DbSet<OutboxMessages> OutboxMessages { get; set; }
        public DbSet<TrashMessages> TrashMessages { get; set; }
        public DbSet<Outbox> outboxes { get; set; }
        public DbSet<Trash> Trashes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
           .Property(P => P.Status)
           .HasConversion<string>();

        }

    }
}
