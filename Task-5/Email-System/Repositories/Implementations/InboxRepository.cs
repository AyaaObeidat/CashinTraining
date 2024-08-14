using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Email_System.Repositories.Implementations
{
    public class InboxRepository : GenericRepository<Inbox>, IInboxRepository
    {
        public InboxRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<List<Inbox>?> GetAllAsync()
        {
            return await _dbContext.Set<Inbox>().Include(x => x.Messages).ToListAsync();
        }
        public override async Task<Inbox?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Inbox>().Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
