using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class InboxRepository : GenericRepository<Inbox>, IInboxRepository
    {
        public InboxRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
