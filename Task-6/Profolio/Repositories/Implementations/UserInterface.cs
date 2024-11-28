using Microsoft.EntityFrameworkCore;
using Profolio.Models;
using Profolio.Repositories.Interfaces;

namespace Profolio.Repositories.Implementations
{
    public class UserInterface : GeneralInterface<User>, IUserInterface
    {
        public UserInterface(DbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>().Include(u => u.Skills).Include(u => u.experiences).ToListAsync();
        }

        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<User>().Include(u => u.Skills).Include(u => u.experiences).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
