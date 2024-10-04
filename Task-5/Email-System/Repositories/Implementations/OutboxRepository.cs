using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Email_System.Repositories.Implementations
{
    public class OutboxRepository : GenericRepository<Outbox>, IOutboxRepository
    {
        public OutboxRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<List<Outbox>?> GetAllAsync()
        {
            return await _dbContext.Set<Outbox>().Include(x => x.Messages).ToListAsync();
        }
        public override async Task<Outbox?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Outbox>().Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
