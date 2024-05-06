using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Repositories.Implementations
{
    public class UserInterface : GenericInterface<User>, IUserInterface
    {
        public UserInterface(MessagingSystemDbContext context) : base(context)
        {
        }
        public override async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Set<User>().Include(u => u.Messages).ToListAsync();
        }


        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<User>().Include(u => u.Messages).FirstOrDefaultAsync(u => u.Id == id);
        }
    }

}
