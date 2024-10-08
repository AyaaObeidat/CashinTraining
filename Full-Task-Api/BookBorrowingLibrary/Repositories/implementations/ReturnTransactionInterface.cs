using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;

namespace BookBorrowingLibrary.Repositories.implementations
{
    public class ReturnTransactionInterface : GenericInterface<ReturnTransaction>, IReturnTransactionInterface
    {
        public ReturnTransactionInterface(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
