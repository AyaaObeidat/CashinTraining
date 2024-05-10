using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class LatestProductsVisitedInterface : GenericInterface<LatestProductsVisited>, ILatestProductVisitedInterface
    {
        public LatestProductsVisitedInterface (MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}

