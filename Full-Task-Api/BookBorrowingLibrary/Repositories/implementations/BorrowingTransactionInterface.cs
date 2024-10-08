using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;

namespace BookBorrowingLibrary.Repositories.implementations
{
    public class BorrowingTransactionInterface : GenericInterface<BorrowingTransaction>, IBorrowingTransactionInterface
    {
        public BorrowingTransactionInterface(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
