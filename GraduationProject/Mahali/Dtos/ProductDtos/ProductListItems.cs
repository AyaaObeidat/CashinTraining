using Mahali.Models;

namespace Mahali.Dtos.ProductDtos
{
    public class ProductListItems
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
        public List<ProductColors> ColorsList { get; set; }
        public List<ProductSizes> SizesList { get; set; }
    }
}
