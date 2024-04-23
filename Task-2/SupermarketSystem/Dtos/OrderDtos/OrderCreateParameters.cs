using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.OrderDtos
{
    public class OrderCreateParameters
    {
        public List<Product> ProductsList { get;  set; }
    }
}
