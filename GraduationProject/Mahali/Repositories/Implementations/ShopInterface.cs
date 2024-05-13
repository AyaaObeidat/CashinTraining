using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mahali.Repositories.Implementations
{
    public class ShopInterface : GenericInterface<Shop>, IShopInterface
    {
        public ShopInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Shop?> GetByName(string name)
        {
            return await _dbContext.Set<Shop>().Include(x => x.Orders).Include(x => x.Reviews).FirstOrDefaultAsync(a => a.Name == name);
        }
        
       
    }
}
