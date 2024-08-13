using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class InboxMessagesRepository : GenericRepository<InboxMessages>,IInboxMessagesRepository 
    {
        public InboxMessagesRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
