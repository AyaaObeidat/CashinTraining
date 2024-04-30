using MessagingSystem.Data;
using MessagingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Repositories.Implementations
{

    public abstract class GenericInterface<T> : IGenericInterface<T> where T : class
    {
        protected  MessagingSystemDbContext _dbContext;

        public GenericInterface(MessagingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            
             _dbContext.Set<T>().Remove(entity);
             await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
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
