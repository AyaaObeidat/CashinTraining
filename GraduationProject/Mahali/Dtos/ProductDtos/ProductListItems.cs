using Mahali.Models;

namespace Mahali.Dtos.ProductDtos
{
    public class ProductListItems
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<ProductColors> ColorsList { get; set; }
        public List<ProductSizes> SizesList { get; set; }
        public Guid ShopId { get; set; }
    }
}
