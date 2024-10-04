using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;
using EmailSystemDtos.UserDtos;
using Microsoft.EntityFrameworkCore;

namespace Email_System.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<List<User>?> GetAllAsync()
        {
            return await _dbContext.Set<User>().Include(x => x.Messages).ToListAsync();
        }
        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<User>().Include(x=>x.Messages).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
