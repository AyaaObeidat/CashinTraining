using Mahali.Models;

namespace Mahali.Dtos.OrderDtos
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public decimal TotalAmount { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public Guid CustomerId { get;  set; }
        public OrderType Type { get;  set; }
        public OrderStatus Status { get;  set; }
        public List<OrderProducts> Products { get;  set; }
        public List<ShopOrders> Shops { get;  set; }
    }
}
