using MessagingSystem.Data;
using MessagingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Repositories.Implementations
{
    public class GenericInterface<T> : IGenericInterface<T> where T : class
    {
        protected readonly MessagingSystemDbContext dbContext;
        public GenericInterface(MessagingSystemDbContext context)
        {
            dbContext = context;
        }
        public async Task AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
