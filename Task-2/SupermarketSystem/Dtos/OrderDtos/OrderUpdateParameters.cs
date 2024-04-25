using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.OrderDtos
{
    public class OrderUpdateParameters
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
