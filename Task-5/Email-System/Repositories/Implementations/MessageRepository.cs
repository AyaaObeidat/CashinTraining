using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
