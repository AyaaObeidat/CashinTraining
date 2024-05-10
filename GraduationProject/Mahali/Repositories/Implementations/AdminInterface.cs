using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class AdminInterface : GenericInterface<Admin>, IAdminInterface
    {
        public AdminInterface (MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}

