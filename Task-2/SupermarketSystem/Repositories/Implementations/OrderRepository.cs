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
            return await _dbcontext.Set<Order>().FindAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            Order entity = await _dbcontext.Set<Order>().FindAsync(id);
            _dbcontext.Set<Order>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }






    }
    }
