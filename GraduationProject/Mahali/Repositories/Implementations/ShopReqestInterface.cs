using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class ShopReqestInterface : GenericInterface<ShopRequest>, IShopRequestInterface
    {
        public ShopReqestInterface (MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}

