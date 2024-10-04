namespace Email_System.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();    

    }
}
