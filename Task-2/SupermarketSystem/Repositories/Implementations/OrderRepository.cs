using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace SupermarketSystem.Repositories.Implementations
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SupermarketSystemDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbcontext.Orders.Include(o => o.ProductsList).FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task DeleteAsync(int id)
        {
            Order entity = await _dbcontext.Set<Order>().FindAsync(id);
            _dbcontext.Set<Order>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public override async Task<List<Order>> GetAllAsync()
        {
            return await _dbcontext.Orders.Include(o => o.ProductsList).ToListAsync();
        }




    }
}
