using Mahali.Data;
using Mahali.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mahali.Repositories.Implementations
{
    public class GenericInterface<T> : IGenericInterface<T> where T : class
    {
        protected readonly MahaliDbContext _dbContext;

        public GenericInterface(MahaliDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
