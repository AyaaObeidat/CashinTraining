using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowingLibrary.Repositories.implementations
{
    public class GenericInterface<T> : IGenericInterface<T> where T : class
    {
        protected BookBorrowingLibraryDbContext _dbContext;

        public GenericInterface(BookBorrowingLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
          await this._dbContext.Set<T>().AddAsync(entity);
          await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            T? entity = await GetByIdAsync(id);
            if(entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

             
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?    > GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
