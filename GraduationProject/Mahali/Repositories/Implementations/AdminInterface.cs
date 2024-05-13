using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mahali.Repositories.Implementations
{
    public class AdminInterface : GenericInterface<Admin>, IAdminInterface
    {
        public AdminInterface (MahaliDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Admin?> GetByUserName(string userName)
        {
            return await _dbContext.Set<Admin>().Include(x => x.ShopRequests).Include(x => x.Reports).FirstOrDefaultAsync(a => a.UserName == userName);
        }

        public async Task<string> GetUserName()
        {
            var admin = await GetAllAsync();
            return admin.First().UserName;  
        }

    }
}

