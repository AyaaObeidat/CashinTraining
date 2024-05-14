using Mahali.Dtos.ProductColorsDtos;
using Mahali.Dtos.ProductSizesDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Services
{
    public class ProductSizeService
    {
        private readonly IProductSizeInterface _productSizeInterface;
        private readonly IProductInterface _productnterface;

        public ProductSizeService(IProductSizeInterface productSizeInterface, IProductInterface productnterface)
        {
            _productSizeInterface = productSizeInterface;
            _productnterface = productnterface;
        }

        public async Task AddProductSizeAsync(ProductSizesCreateParameters parameters)
        {
            var product = await _productnterface.GetByIdAsync(parameters.ProductId);
            if (product == null) { return; }

            var productSize = ProductSizes.Create(parameters.ProductId, parameters.Size);
            await _productSizeInterface.AddAsync(productSize);
        }

        public async Task DeleteProductSizeAsync(ProductSizeDeleteParameters parameters)
        {
            var product = await _productnterface.GetByIdAsync(parameters.ProductId);
            if (product == null) { return; }
            var productSize = await _productSizeInterface.GetByIdAsync(parameters.ProductSizeId);
            if (productSize == null) return;
            await _productSizeInterface.DeleteAsync(productSize);
        }

        public async Task<List<ProductSizesDetails>> GetAllAsync()
        {
            var productsSizes = await _productSizeInterface.GetAllAsync();
            return productsSizes.Select(c => new ProductSizesDetails
            {
                Id = c.Id,
                ProductId = c.ProductId,
                Size = c.Size,
            }).ToList();
        }

        public async Task<ProductSizesDetails?> GetByIdAsync(ProductSizeGetByParameters parameters)
        {
            var productSize = await _productSizeInterface.GetByIdAsync(parameters.Id);
            return new ProductSizesDetails
            {
                Id = productSize.Id,
                ProductId = productSize.ProductId,
                Size = productSize.Size,
            };
        }
    }
}
