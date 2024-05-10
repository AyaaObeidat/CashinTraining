using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class CategoryInterface : GenericInterface<Category>, ICategoryInterface
    {
        public CategoryInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
