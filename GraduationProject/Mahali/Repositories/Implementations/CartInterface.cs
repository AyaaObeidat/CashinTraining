using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Implementations;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class CartInterface : GenericInterface<Cart>, ICartInterface
    {
        public CartInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
