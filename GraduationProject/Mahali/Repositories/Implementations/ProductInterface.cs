using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class ProductInterface : GenericInterface<Product>, IProductInterface
    {
        public ProductInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}
