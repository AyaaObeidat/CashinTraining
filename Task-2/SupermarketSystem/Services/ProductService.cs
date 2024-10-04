using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDetails>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDetails
            {
               Id = p.Id,
               Name = p.Name,
               Price = p.UnitPrice,
               Quantity = p.Quantity,
               
            }).ToList();
        }

        public async Task<ProductListItems> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return new ProductListItems
            {
                Id = product.Id,
                Name = product.Name,
            };
        }

        public async Task AddAsync(ProductCreateParameters parameters)
        {
            var product = Product.Create(parameters.Name , parameters.UnitPrice , parameters.Quantity );
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task UpdatePrice(ProductUpdateParameters parameters)
        {
            Product product = await _productRepository.GetByIdAsync(parameters.Id);
            product = product.UpdatePrice(parameters.UnitPrice);
            await _productRepository.UpdateAsync(product);
        }

        public async Task UpdateQuantity(ProductUpdateParameters parameters)
        {
            Product product = await _productRepository.GetByIdAsync(parameters.Id);
            product = product.UpdateQuantity(parameters.Quantity);
            await _productRepository.UpdateAsync(product);
        }
    }
}
