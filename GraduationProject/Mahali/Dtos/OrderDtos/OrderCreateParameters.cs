namespace Mahali.Dtos.OrderDtos
{
    public class OrderCreateParameters
    {
        public Guid CustomerId { get;  set; }
        public OrderType Type { get;  set; }
        public OrderStatus Status { get;  set; }
    }
}
