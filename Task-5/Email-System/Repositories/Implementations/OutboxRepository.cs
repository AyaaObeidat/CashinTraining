using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class OutboxRepository : GenericRepository<Outbox>, IOutboxRepository
    {
        public OutboxRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
