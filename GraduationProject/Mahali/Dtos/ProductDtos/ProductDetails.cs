using Mahali.Models;
using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductDtos
{
    public class ProductDetails
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; } 
        public int Quantity { get;  set; }
        public decimal Price { get;  set; } 
        public string ImageUri { get;  set; } 
        public Guid CategoryId { get;  set; }
        public Guid ShopId { get;  set; }
        public List<ProductColors> ColorsList { get;  set; }
        public List<ProductSizes> SizesList { get;  set; }
        public List<CartProducts> Carts { get;  set; }
        public List<WishListProducts> WishLists { get;  set; }
        public List<OrderProducts> Orders { get;  set; }
        public List<ReviewRequest> Reviews { get;  set; }
    }
}
