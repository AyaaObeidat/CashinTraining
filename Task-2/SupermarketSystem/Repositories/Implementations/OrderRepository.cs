using SupermarketSystem.Data;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.OrderDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SupermarketSystemDbContext _dbContext;

        public OrderRepository(SupermarketSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //=================================================================

        public Order Create(OrderCreateParameters parameters)
        {
            List<Product> products = new List<Product>();
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == parameters.ProductID);
            product  = product.UpdateQuantity(product.Quantity-parameters.Quantity);
            if (product == null || product.Quantity < parameters.Quantity) return null;
            for(int i=1; i <= parameters.Quantity; i++)
            {
                products.Add(product);
               
            }
            var order = Order.Create(products);
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
            
        }

        public int Delete(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) { return -1; }
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return 0;
        }

        public List<OrderDetails> Details()
        {
            var orders = _dbContext.Orders.Select(o => new OrderDetails()
            {
                Id = o.Id,
                ProductsList = o.ProductsList,
                TotalPrice = o.TotalPrice,
            }).ToList();

            return orders;
        }

        public Order GetById(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) { return null; }
            return order;
        }

        public List<OrderListItems> List()
        {
            var orders = _dbContext.Orders.Select(o => new OrderListItems
            {
                Id=o.Id,
                TotalPrice=o.TotalPrice,
            }).ToList();

            return orders;
        }

        public Order AddProduct(OrderUpdateParameters parameters)
        {
            List<Product> products = new List<Product>();

            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == parameters.Id);
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == parameters.ProductId);
            if (order == null || product == null || product.Quantity < parameters.Quantity) return null;
            product = product.UpdateQuantity(product.Quantity - parameters.Quantity);

            for (int i = 1; i <= parameters.Quantity; i++)
            {
                products.Add(product);

            }
            order.SetProductList(products);
            order.SetTotalPrice();
            _dbContext.SaveChanges();
            return order;

        }

        public Order RemoveProduct(OrderUpdateParameters parameters)
        {
            List<Product> products = new List<Product>();

            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == parameters.Id);
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == parameters.ProductId);
            if (order == null || product == null || order.TotalPrice==0) return null;

            product = product.UpdateQuantity(product.Quantity + parameters.Quantity);
            products = order.ProductsList.ToList();

            for (int i = 1; i <= parameters.Quantity; i++)
            {
                products.Remove(product);

            }
            order.SetProductList(products);
            _dbContext.SaveChanges();
            order.SetTotalPrice();
            _dbContext.SaveChanges();
            return order;

        }
    }

}

