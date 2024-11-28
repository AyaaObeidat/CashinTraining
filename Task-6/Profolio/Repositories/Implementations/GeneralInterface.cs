﻿using Microsoft.EntityFrameworkCore;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class GeneralInterface<T> : IGeneralInterface<T> where T : class
    {
        protected DbContext _dbContext;

        public GeneralInterface(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity); 
            await _dbContext.SaveChangesAsync();    
        }

        public async Task DeleteAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);
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
        }
    }
}