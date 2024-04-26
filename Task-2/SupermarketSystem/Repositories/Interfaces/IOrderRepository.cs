using SupermarketSystem.Models;

namespace SupermarketSystem.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
