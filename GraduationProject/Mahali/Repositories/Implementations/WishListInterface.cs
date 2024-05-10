using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class WishListInterface : GenericInterface<WishList>, IWishListInterface
    {
        public WishListInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
