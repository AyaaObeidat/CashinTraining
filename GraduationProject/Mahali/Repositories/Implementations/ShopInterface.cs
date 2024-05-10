using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class ShopInterface : GenericInterface<Shop>, IShopInterface
    {
        public ShopInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
