using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Repositories.Implementations
{
    public class UserInterface : GenericInterface<User>, IUserInterface
    {
        public UserInterface(MessagingSystemDbContext context) : base(context)
        {
        }
    }
}
