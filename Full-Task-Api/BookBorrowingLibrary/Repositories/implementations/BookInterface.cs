using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;

namespace BookBorrowingLibrary.Repositories.implementations
{
    public class BookInterface : GenericInterface<Book>, IBookInterface
    {
        public BookInterface(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
