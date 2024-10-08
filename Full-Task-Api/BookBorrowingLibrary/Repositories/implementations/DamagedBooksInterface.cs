using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;

namespace BookBorrowingLibrary.Repositories.implementations
{
    public class DamagedBooksInterface : GenericInterface<DamagedBooks> , IDamagedBooksInterface
    {
        public DamagedBooksInterface(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
