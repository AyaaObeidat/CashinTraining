using MessagingSystem.Data;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Repositories.Implementations
{
    public class MessageInterface : GenericInterface<Message>, IMessageInterface
    {
        public MessageInterface(MessagingSystemDbContext context) : base(context)
        {
        }

        public override async Task<List<Message>> GetAllAsync()
        {
            return await dbContext.Set<Message>().Include(m => m.Distinations).ToListAsync();
        }

        public override async Task<Message> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<Message>().Include(m => m.Distinations).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
