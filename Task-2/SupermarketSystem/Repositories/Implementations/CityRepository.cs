using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(SupermarketSystemDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
