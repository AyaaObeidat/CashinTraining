using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.OrderDtos
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public decimal TotalPrice { get;  set; } 
        public List<Product> ProductsList { get;  set; }
        public OrderType Type { get;  set; }
        public OrderStatus Status { get;  set; }
        public PaymentType PaymentType { get;  set; }
        public Guid CustomerId { get;  set; }

    }
}
