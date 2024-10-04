using Email_System.Data;
using Email_System.Models;
using Email_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Email_System.Repositories.Implementations
{
    public class TrashRepository : GenericRepository<Trash>, ITrashRepository
    {
        public TrashRepository(EmailSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Trash>?> GetAllAsync()
        {
            return await _dbContext.Set<Trash>().Include(x => x.Messages).ToListAsync();
        }
        public override async Task<Trash?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Trash>().Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
