using SupermarketSystem.Dtos.OrderDtos;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;

namespace SupermarketSystem.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Order Create(OrderCreateParameters parameters);
        public List<OrderDetails> Details();
        public List<OrderListItems> List();
        public Order GetById(int id);
        public int Delete(int id);
       
    }
}
