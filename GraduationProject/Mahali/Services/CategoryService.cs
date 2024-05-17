using Mahali.Dtos.CategoryDtos;
using Mahali.Dtos.ProductDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Services
{
    public class CategoryService
    {
        private readonly ICategoryInterface _categoryInterface;

        public CategoryService(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
        }

        public async Task AddAsync(CategoryCreateParameters parameters)
        {
            var categories = await _categoryInterface.GetAllAsync();
            foreach(var category in categories) 
            {
                if (category.Name == parameters.Name) return;
                else continue;
            }
            var newCategory = Category.Create(parameters.Name);
            await _categoryInterface.AddAsync(newCategory);
        }

        public async Task DeleteAsync(CategoryDeleteParameters parameters)
        {
            var category = await _categoryInterface.GetByIdAsync(parameters.CategoryId);
            if (category == null) return;
            await _categoryInterface.DeleteAsync(category);
               
        }

        public async Task ModifyCategoryNameAsync(CategoryUpdateParameters parameters)
        {
            var selectedCategory = await _categoryInterface.GetByIdAsync(parameters.CategoryId);
            if (selectedCategory == null) return;

            var categories = await _categoryInterface.GetAllAsync();
            foreach (var category in categories)
            {
                if (category.Name == parameters.UpdatedName) return;
                else continue;
            }
            selectedCategory.SetName(parameters.UpdatedName);
            await _categoryInterface.UpdateAsync(selectedCategory);
        }

        public async Task<List<CategoryListItems>?> GetAllAsync()
        {
            var categories = await _categoryInterface.GetAllAsync();
            if (categories == null) return null;
            return categories.Select(c => new CategoryListItems
            {
                Name = c.Name,
                Products = c.Products,
            }).ToList();
        }

        public async Task<CategoryListItems?> GetByIdAsync(CategoryGetByParameter parameter)
        {
            var category = await _categoryInterface.GetByIdAsync(parameter.CategoryId);
            if (category == null) return null;
            return  new CategoryListItems
            {
                Name = category.Name,
                Products = category.Products,
            };
        }

        public async Task<List<ProductListItems>?> GetCategoryProductsAsync(CategoryGetByParameter parameter)
        {
            var category = await _categoryInterface.GetByIdAsync(parameter.CategoryId);
            if (category == null) return null;
            return category.Products.Select(c => new ProductListItems
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                ColorsList = c.ColorsList,
                SizesList = c.SizesList,
                ShopId = c.ShopId,
            }).ToList();
        }
    }
}
