using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class MessageDestinationRepository : GenericRepository<MessageDestination>, IMessageDestinationRepository
    {
        public MessageDestinationRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
