using BookBorrowingLibrary.Models;

namespace BookBorrowingLibrary.Repositories.Interfaces
{
    public interface IUserInterface : IGenericInterface<User>
    {
        public Task<User> GetAdminAsync();
        public Task<List<User>> GetAllCustomersAsync();
    }
}
