using Mahali.Dtos.ProductDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Services
{
    public class ProductService
    {
        private readonly IProductInterface _productInterface;
        private readonly IShopInterface _shopInterface;

        public ProductService(IProductInterface productInterface , IShopInterface shopInterface)
        {
            _productInterface = productInterface;
            _shopInterface = shopInterface;
        }

        public async Task AddAsync(ProductCreateParameters parameters)
        {
            var shop = await _shopInterface.GetByIdAsync(parameters.shopId);
            foreach(var product in shop.Products.ToList())
            {
                if (product.Name != parameters.Name) continue;
                else break;
            }
            var newProduct = Product.Create(parameters.Name, parameters.Description, parameters.Quantity, parameters.Price, parameters.ImageUri, shop.Id);
            await _productInterface.AddAsync(newProduct);
        }

        public async Task DeleteAsync(ProductDeleteParameters parameters)
        {
            var product = await _productInterface.GetByIdAsync(parameters.ProductId);
            await _productInterface.DeleteAsync(product);
        }

        public async Task<List<ProductListItems>?> GetAllAsync()
        {
            var products = await _productInterface.GetAllAsync();
            if (products == null) return null;
            return products.Select(p => new ProductListItems
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ShopId = p.ShopId,
                ColorsList = p.ColorsList,
                SizesList = p.SizesList,
            }).ToList();
        }
    }
}
