using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SupermarketSystemDbContext dbcontext) : base(dbcontext)
        {
        }

        public override async Task<List<Category>> GetAllAsync()
        {
            return await _dbcontext.Categories.Include(o => o.ProductsList).ToListAsync();
        }

        public override async Task<Category> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Categories.Include(o => o.ProductsList).FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
