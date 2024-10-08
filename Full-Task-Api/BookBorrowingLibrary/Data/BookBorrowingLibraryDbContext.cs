using BookBorrowingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowingLibrary.Data
{
    public class BookBorrowingLibraryDbContext : DbContext
    {
        protected BookBorrowingLibraryDbContext()
        {
        }
        public BookBorrowingLibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<BorrowingTransaction>? BorrowingTransactions { get; set; }
        public DbSet<ReturnTransaction>? ReturnTransactions { get; set; }
        public DbSet<DamagedBooks>? DamagedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(p => p.Status)
            .HasConversion<string>();

            modelBuilder.Entity<BorrowingTransaction>()
           .Property(p => p.BookStatus)
           .HasConversion<string>();

            modelBuilder.Entity<BorrowingTransaction>()
          .Property(p => p.RequestStatus)
          .HasConversion<string>();

            modelBuilder.Entity<BorrowingTransaction>()
          .Property(p => p.DeliveryStatus)
          .HasConversion<string>();

            modelBuilder.Entity<ReturnTransaction>()
          .Property(p => p.BookStatus)
          .HasConversion<string>();

            modelBuilder.Entity<DamagedBooks>()
          .Property(p => p.DamageProceedings)
          .HasConversion<string>();
        }


    }
}
