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
        public async Task<Shop?> GetByNameAsync(string shopName)
        {
            return await _dbContext.Set<Shop>().Include(x => x.Orders).Include(x => x.Reviews).Include(x => x.Products).FirstOrDefaultAsync(a => a.Name == shopName);
        }
    }
}
