using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Repositories.Implementations
{
    public class MessageInterface : GenericInterface<Message>, IMessageInterface
    {
        public MessageInterface(MessagingSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
