using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;

namespace SupermarketSystem.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Product Create(ProductCreateParameters parameters);
        public List<ProductDetails> Details();
        public List<ProductListItems> List();
        public Product GetById(Guid id);
        public int Delete(Guid id);
        public void UpdatePrice(ProductUpdateParameters parameters);
        public void UpdateQuantity(ProductUpdateParameters parameters);


        
    }
}
