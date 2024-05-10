using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class ShopRecuestInterface : GenericInterface<ShopRequest>, IShopRecuestInterface
    {
        public ShopRecuestInterface (MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}

