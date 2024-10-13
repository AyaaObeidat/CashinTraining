using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BookBorrowingLibrary.Repositories.implementations
{
    public class UserInterface : GenericInterface<User>, IUserInterface
    {
        public UserInterface(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
        public async override Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Id == id && u.IsAdmin==false);
        }
        public async Task<User> GetAdminAsync()
        {
            var users = await GetAllAsync();
            var Admin = users.FirstOrDefault(a => a.IsAdmin == true);
            return Admin;
        }

        public async Task<List<User>> GetAllCustomersAsync()
        {
            var users = await GetAllAsync();
            var customers = users.ToList().Where(c => c.IsAdmin == false).ToList();
            return customers;
        }
    }
}
