using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.OrderDtos
{
    public class OrderCreateParameters
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
