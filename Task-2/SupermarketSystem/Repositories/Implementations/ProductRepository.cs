using SupermarketSystem.Data;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly SupermarketSystemDbContext _dbContext;

        public ProductRepository(SupermarketSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product Create(ProductCreateParameters parameters)
        {
            var product = Product.Create(parameters.Name , parameters.UnitPrice , parameters.Quantity);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
             return product;
        }

        public int Delete(Guid id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) { return -1; }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return 0;
        }

        public List<ProductDetails> Details()
        {
            var products = _dbContext.Products.Select(p => new ProductDetails()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.UnitPrice,
                Quantity = p.Quantity,
            }).ToList();

            return products;
        }

        public Product GetById(Guid id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if(product == null) { return null; }
            return product;
        }

        public List<ProductListItems> List()
        {
            var products = _dbContext.Products.Select(p => new ProductListItems()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();

            return products;    
        }

        public void UpdatePrice(ProductUpdateParameters parameters)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == parameters.Id);
            if(product == null) { return; }
            product = product.UpdatePrice(parameters.UnitPrice);
            _dbContext.SaveChanges();   
        }
        public void UpdateQuantity(ProductUpdateParameters parameters)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == parameters.Id);
            if (product == null) { return; }
            product = product.UpdateQuantity(parameters.Quantity);
            _dbContext.SaveChanges();
        }
       
    }
}
