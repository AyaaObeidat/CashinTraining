using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class TrashMessagesRepository : GenericRepository<TrashMessages>, ITrashMessagesRepository
    {
        public TrashMessagesRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
