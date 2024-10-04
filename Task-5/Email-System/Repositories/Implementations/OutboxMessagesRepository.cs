using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class OutboxMessagesRepository : GenericRepository<OutboxMessages>, IOutboxMessagesRepository
    {
        public OutboxMessagesRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
