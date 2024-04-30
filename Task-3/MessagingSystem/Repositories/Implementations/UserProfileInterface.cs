using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Repositories.Implementations
{
    public class UserProfileInterface : GenericInterface<UserProfile>, IUserProfileInterface
    {
        public UserProfileInterface(MessagingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserProfile> GetByUserEmail(string email)
        {
            return await _dbContext.Profiles.FirstAsync(p => p.Email == email); 
        }

    }
}
