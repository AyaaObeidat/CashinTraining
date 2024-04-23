using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.OrderDtos
{
    public class OrderUpdateParameters
    {
        public int Id { get; set; }
        public List<Product> ProductsList { get; private set; }
    }
}
