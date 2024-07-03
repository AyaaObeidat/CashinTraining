using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;

namespace BookBorrowingLibrary.Repositories.Implementations
{
    public class BorrowingTransactionRepository : GenericRepository<BorrowingTransaction>, IBorrowingTransactionRepository
    {
        public BorrowingTransactionRepository(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
