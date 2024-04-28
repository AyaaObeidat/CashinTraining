using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(SupermarketSystemDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
