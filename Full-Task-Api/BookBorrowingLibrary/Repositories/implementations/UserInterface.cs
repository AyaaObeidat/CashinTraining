using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;

namespace BookBorrowingLibrary.Repositories.implementations
{
    public class UserInterface : GenericInterface<User>, IUserInterface
    {
        public UserInterface(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
