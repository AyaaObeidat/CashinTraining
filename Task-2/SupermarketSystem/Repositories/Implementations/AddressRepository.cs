using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(SupermarketSystemDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
