using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.OrderDtos
{
    public class OrderCreateParameters
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
        public string OrderType { get;  set; }
        public string PaymentType { get; set; }
    }
}
