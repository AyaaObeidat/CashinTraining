using BookBorrowingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowingLibrary.Data
{
    public class BookBorrowingLibraryDbContext : DbContext
    {
        public BookBorrowingLibraryDbContext() { }

        public BookBorrowingLibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User>? Users { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<BorrowingTransaction>? BorrowingTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
           .Property(o => o.Status)
           .HasConversion<string>();

            modelBuilder.Entity<BorrowingTransaction>()
           .Property(o => o.ReturnStatus)
           .HasConversion<string>();

            modelBuilder.Entity<Book>()
           .Property(o => o.Classification)
           .HasConversion<string>();

           modelBuilder.Entity<User>()
          .Property(o => o.Gender)
          .HasConversion<string>();

           modelBuilder.Entity<User>()
           .Property(o => o.TotalPriceOfBorrowingBooks)
           .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity< Book>()
             .Property(o => o.Price)
             .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<BorrowingTransaction>()
          .Property(o => o.ArrangedFine)
          .HasColumnType("decimal(18, 2)");
        }

    }
}
