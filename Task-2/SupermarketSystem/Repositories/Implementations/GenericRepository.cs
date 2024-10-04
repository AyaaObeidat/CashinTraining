using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Data;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected  SupermarketSystemDbContext _dbcontext;

        public GenericRepository(SupermarketSystemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Set<T>().Update(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            T entity = await _dbcontext.Set<T>().FindAsync(id);
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }
    }



   
       
    
}
