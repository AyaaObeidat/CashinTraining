using Mahali.Dtos.ProductColorsDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Services
{
    public class ProductColorService
    {
        private readonly IProductColorInterface _productColorInterface;
        private readonly IProductInterface _productnterface;

        public ProductColorService(IProductColorInterface productColorInterface , IProductInterface productnterface)
        {
            _productColorInterface = productColorInterface;
            _productnterface = productnterface;
        }

        public async Task AddProductColorAsync (ProductColorsCreateParameters parameters)
        {
            var product = await _productnterface.GetByIdAsync (parameters.ProductId);
            if (product == null) { return; }

            var productColor = ProductColors.Create(parameters.ProductId, parameters.Color);
            await _productColorInterface.AddAsync (productColor);
        }

        public async Task DeleteProductColorAsync(ProductColorDeleteParameters parameters)
        {
            var product = await _productnterface.GetByIdAsync(parameters.ProductId);
            if (product == null) { return; }
            var productColor = await _productColorInterface.GetByIdAsync(parameters.ProductColorId);
            if (productColor == null) return;
            await _productColorInterface.DeleteAsync(productColor);
        }

        public async Task<List<ProductColorsDetails>> GetAllAsync()
        {
            var productsColors = await _productColorInterface.GetAllAsync();
            return productsColors.Select(c => new ProductColorsDetails
            {
                Id = c.Id,
                ProductId = c.ProductId,
                Color = c.Color,
            }).ToList();
        }

        public async Task<ProductColorsDetails?> GetByIdAsync(ProductColorGetByParameters parameters)
        {
            var productColor = await _productColorInterface.GetByIdAsync(parameters.Id);
            return new ProductColorsDetails
            {
                Id = productColor.Id,
                ProductId = productColor.ProductId,
                Color = productColor.Color,
            };
        }
    }
}
