using SupermarketSystem.Data;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;

namespace SupermarketSystem.Repositories.Interfaces
{
    public interface ICategoryRepository
    {

        public Category Create(CategoryCreateParameters parameters);
        public List<CategoryDetails> Details();
        public List<CategoryListItems> List();
        public Category GetById(Guid id);
        public int Delete(Guid id);
        public Category AddProduct(CategoryUpdateParameters parameters);
        public Category RemoveProduct(CategoryUpdateParameters parameters);
    }
}
