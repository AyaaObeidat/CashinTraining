using Microsoft.EntityFrameworkCore;
using Profolio.Data;
using Profolio.Models;
using Profolio.Repositories.Interfaces;
using ProfolioEnums;

namespace Profolio.Repositories.Implementations
{
    public class UserInterface : GenericInterface<User>, IUserInterface
    {
        public UserInterface(ProfolioDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>().Include(u => u.Skills).Include(u => u.Experiences).ToListAsync();
        }

        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<User>().Include(u => u.Skills).Include(u => u.Experiences).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<User>> GetAllPublicUsersAsync()
        {
            return _dbContext.Set<User>().Include(u => u.Skills).Include(u => u.Experiences).Where(u => u.ProfileStatus == ProfileStatus.Public).ToList();

        }
    }
}
