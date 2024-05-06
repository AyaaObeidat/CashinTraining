using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Repositories.Implementations
{
    public class MessageDistenationInterface : GenericInterface<MessageDistination>, IMessageDistenationInterface
    {
        public MessageDistenationInterface(MessagingSystemDbContext context) : base(context)
        {
        }
    }
}
