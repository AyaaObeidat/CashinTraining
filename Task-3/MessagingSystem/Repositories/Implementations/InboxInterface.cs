using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Repositories.Implementations
{
    public class InboxInterface : GenericInterface<Inbox>, IInboxInterface
    {
        public InboxInterface(MessagingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<List<Inbox>> GetAllAsync()
        {
            return await _dbContext.Set<Inbox>().Include(i => i.Messages).ToListAsync();
        }

        public virtual async Task<Inbox> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Inbox>().Include(i => i.Messages).FirstOrDefaultAsync(i => i.Id==id);
        }
    }
}
