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
        public async Task<OrderDetails> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            return new OrderDetails
            {
                Id = order.Id,
                TotalPrice = order.TotalPrice,
                ProductsList = order.ProductsList
                
            };
        }
        public async Task AddAsync(OrderCreateParameters parameters)
        {
            List<Product> products = new List<Product>();
            Product product = await _productRepository.GetByIdAsync(parameters.ProductID);
            product = product.UpdateQuantity(product.Quantity - parameters.Quantity);
            await _productRepository.UpdateAsync(product);
            if (product == null || product.Quantity < parameters.Quantity) return;
            for (int i = 1; i <= parameters.Quantity; i++)
            {
                products.Add(product); 

            }
            Order order = Order.Create(products);
            await _orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task AddProduct(OrderUpdateParameters parameters)
        {

            List<Product> products = new List<Product>();

            var order = await _orderRepository.GetByIdAsync(parameters.Id);
            var product = await _productRepository.GetByIdAsync(parameters.ProductId);

            if (order == null || product == null || product.Quantity < parameters.Quantity) return;
            product = product.UpdateQuantity(product.Quantity - parameters.Quantity);
            await _productRepository.UpdateAsync(product);
            products = order.ProductsList;
            decimal totalPrice = order.TotalPrice;

            for (int i = 1; i <= parameters.Quantity; i++)
            {
                products.Add(product);
                totalPrice += product.UnitPrice;

            }
            order.SetTotalPrice(totalPrice);
            order.SetProductList(products);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task RemoveProduct(OrderUpdateParameters parameters)
        {
            List<Product> products = new List<Product>();

            var order = await _orderRepository.GetByIdAsync(parameters.Id);
            var product = await _productRepository.GetByIdAsync(parameters.ProductId);
            if (order == null || product == null || order.TotalPrice == 0) return;

            product = product.UpdateQuantity(product.Quantity + parameters.Quantity);
            await _productRepository.UpdateAsync(product);

            products = order.ProductsList.ToList();
            decimal totalPrice = order.TotalPrice;

            for (int i = 1; i <= parameters.Quantity; i++)
            {
                products.Remove(product);
                totalPrice -= product.UnitPrice;
            }
            order.SetTotalPrice(totalPrice);
            order.SetProductList(products);
            await _orderRepository.UpdateAsync(order);
        }
    }
}
