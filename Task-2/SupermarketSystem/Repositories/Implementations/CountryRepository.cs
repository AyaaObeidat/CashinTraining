using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(SupermarketSystemDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
