using SupermarketSystem.Data;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly SupermarketSystemDbContext _dbContext;

        public CategoryRepository(SupermarketSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //=================================================================
        public Category Create(CategoryCreateParameters parameters)
        {
            var category = Category.Create(parameters.Name );
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }

        public int Delete(Guid id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) { return -1; }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return 0;
        }

        public List<CategoryDetails> Details()
        {
            var categories = _dbContext.Categories.Select(c => new CategoryDetails()
            {
                Id = c.Id,
                Name = c.Name,
                ProductsList = c.ProductsList
            }).ToList();

            return categories;
        }

        public Category GetById(Guid id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) { return null; }
            return category;
        }

        public List<CategoryListItems> List()
        {
            var categories = _dbContext.Categories.Select(c => new CategoryListItems
            {
                Id= c.Id,
                Name = c.Name,
            }).ToList();

            return categories;
        }

        public Category AddProduct(CategoryUpdateParameters parameters)
        {

            List<Product> products = new List<Product>();

            var category = _dbContext.Categories.FirstOrDefault(c => c.Id==parameters.Id);
            var product = _dbContext.Products.FirstOrDefault(p => p.Id==parameters.ProductId);
            if (category == null || product == null) return null;
            
            products.Add(product);
            category.SetProductList(products);
            _dbContext.SaveChanges();
            return category;
        }

        public Category RemoveProduct(CategoryUpdateParameters parameters)
        {
           

            var category = _dbContext.Categories.FirstOrDefault(c => c.Id ==parameters.Id);
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == parameters.ProductId);
            if (category == null || product == null) return null;
            
            category.ProductsList.Remove(product);
            _dbContext.SaveChanges();
            return category;
            
        }
    }
}
