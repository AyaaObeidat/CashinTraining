using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.OrderDtos
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public decimal TotalPrice { get;  set; }
        public List<Product> ProductsList { get;  set; }
    }
}
