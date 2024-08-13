using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;

namespace Email_System.Repositories.Implementations
{
    public class TrashRepository : GenericRepository<Trash>, ITrashRepository
    {
        public TrashRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
