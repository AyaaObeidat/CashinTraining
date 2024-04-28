using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SupermarketSystemDbContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<List<Customer>> GetAllAsync()
        {
            return await _dbcontext.Customers.Include(o => o.OrdersList).ToListAsync();
        }
        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Customers.Include(o => o.OrdersList).FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
