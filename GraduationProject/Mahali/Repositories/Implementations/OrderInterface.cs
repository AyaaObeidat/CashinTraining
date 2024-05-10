using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class OrderInterface : GenericInterface<Order>, IOrderInterface
    {
        public OrderInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
