using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Repositories.Implementations
{
    public class MessageDistinationInterface : GenericInterface<MessageDistination>, IMessageDistinationInterface
    {
        public MessageDistinationInterface(MessagingSystemDbContext context) : base(context)
        {
        }
    }
}
