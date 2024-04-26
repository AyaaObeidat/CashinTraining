using Microsoft.EntityFrameworkCore;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.OrderDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Implementations;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository , IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<List<OrderDetails>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return orders.Select(c => new OrderDetails
            {
                Id = c.Id,
                ProductsList = c.ProductsList,
                TotalPrice = c.TotalPrice,
                 
            }).ToList();
        }
        public async Task<OrderListItems> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            return new OrderListItems
            {
                Id = order.Id,
                TotalPrice = order.TotalPrice
            };
        }
        public async Task AddAsync(OrderCreateParameters parameters)
        {
            List<Product> products = new List<Product>();
            Product product = await _productRepository.GetByIdAsync(parameters.ProductID);
            product = product.UpdateQuantity(product.Quantity - parameters.Quantity);
            if (product == null || product.Quantity < parameters.Quantity) return;
            for (int i = 1; i <= parameters.Quantity; i++)
            {
                products.Add(product);

            }
            Order order = Order.Create(products);
            _orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }




    }
}
