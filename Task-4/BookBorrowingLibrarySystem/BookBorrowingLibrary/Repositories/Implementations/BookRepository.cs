using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowingLibrary.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookBorrowingLibraryDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Book>().Include(x => x.Users).FirstOrDefaultAsync(u => u.Id == id);

        }

        public override async Task<List<Book>?> GetAllAsync()
        {
            return await _dbContext.Set<Book>().Include(x => x.Users).ToListAsync();
        }
    }
}
