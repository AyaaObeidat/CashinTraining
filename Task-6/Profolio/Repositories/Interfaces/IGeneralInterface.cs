namespace Profolio.Repositories.Interfaces
{
    public interface IGeneralInterface<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);  
        public Task UpdateAsync(T entity);

    }
}
