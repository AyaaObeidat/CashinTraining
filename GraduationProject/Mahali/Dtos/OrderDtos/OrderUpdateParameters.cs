using Mahali.Models;

namespace Mahali.Dtos.OrderDtos
{
    public class OrderUpdateParameters
    {
        public int Id { get; set; }
        public decimal TotalAmount { get;  set; }
        public List<OrderProducts> Products { get;  set; }
    }
}
