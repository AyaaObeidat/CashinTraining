using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ICategoryRepository categoryRepository , IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<List<CategoryDetails>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(c => new CategoryDetails
            {
                Id = c.Id,
                Name = c.Name,
                ProductsList = c.ProductsList

            }).ToList();
        }

        public async Task<CategoryDetails> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return new CategoryDetails
            {
                Id = category.Id,
                Name = category.Name,
                ProductsList = category.ProductsList
            };
        }

        public async Task AddAsync(CategoryCreateParameters parameters)
        {
            var category = Category.Create(parameters.Name);
            await _categoryRepository.AddAsync(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task AddProduct(CategoryUpdateParameters parameters)
        {
            List<Product> products = new List<Product>();

            Category category = await _categoryRepository.GetByIdAsync(parameters.Id);
            Product product = await _productRepository.GetByIdAsync(parameters.ProductId);
            if (category == null || product == null) return;

            products.Add(product);
            category.SetProductList(products);
            await  _categoryRepository.UpdateAsync(category);
        }

        public async Task RemoveProduct(CategoryUpdateParameters parameters)
        {
            Category category = await _categoryRepository.GetByIdAsync(parameters.Id);
            Product product = await _productRepository.GetByIdAsync(parameters.ProductId);
            if (category == null || product == null) return ;

            category.ProductsList.Remove(product);
            await _categoryRepository.UpdateAsync(category);

        }


    }
}
