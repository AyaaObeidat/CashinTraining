using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowingLibrary.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<User>().Include(x => x.Books).FirstOrDefaultAsync(u => u.Id == id);

        }

             public override async Task<List<User>?> GetAllAsync()
        {
            return await _dbContext.Set<User>().Include(x => x.Books).ToListAsync();
        }
    }
}
