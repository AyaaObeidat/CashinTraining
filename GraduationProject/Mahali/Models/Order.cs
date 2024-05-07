using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mahali.Models
{
    public class Order
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal TotalAmount { get;private set; } 
        public DateTime CreatedAt { get; private set; }
        public Guid CustomerId { get;private set; }
        public OrderType Type { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderProducts> Products { get; private set; }


        private Order() { }
        private Order(Guid customerId, OrderType type, OrderStatus status)
        {
            CustomerId = customerId;
            CreatedAt = DateTime.Now;
            Type = type;
            Status = status;
        }

        public static Order Create (Guid customerId, OrderType type, OrderStatus status)
        {
            if(customerId==Guid.Empty) { throw new ArgumentException(); }
            return new Order(customerId , type , status);
        }

        public void SetProducts(List<OrderProducts> products)
        {
            Products = products;
        }

        public void SetTotalAmount()
        {
            if (Products == null) { throw new ArgumentNullException(); }
            foreach(var product in Products)
            {
                TotalAmount += product.UnitPrice;
            }
        }
    }
}
