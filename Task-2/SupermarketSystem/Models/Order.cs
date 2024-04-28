using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupermarketSystem.Models
{
    public enum OrderType { InStorePickup, Delivery }
    public enum OrderStatus { Paid, Cancelled }
    public enum PaymentType { Cash, Visa }
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal TotalPrice { get; private set; } = 0;
        public List<Product> ProductsList { get; private set; }
        public OrderType Type { get;private set; }
        public OrderStatus Status { get;private set; }
        public PaymentType PaymentType { get; private set; }
        public Guid CustomerId { get;private set; } 
        
        public Order()
        {
            
        }
        public Order(List<Product> products , Guid customerId , OrderType type , PaymentType paymentType)
        {
            ProductsList = products;
            CustomerId = customerId;
            PaymentType = paymentType;
            Type= type;
            UpdateTotalPrice();
        }
        public static Order Create(List<Product> products , Guid customerId , string type , string paymentType)
        {
            OrderType orderType;
            PaymentType payment;

            if (string.IsNullOrEmpty(type) ) throw new ArgumentNullException();
            if (type.ToUpper() == OrderType.InStorePickup.ToString().ToUpper())
            {
                orderType = OrderType.InStorePickup;
            }
            else if (type.ToUpper() == OrderType.Delivery.ToString().ToUpper())
            {
                orderType = OrderType.Delivery;
            }
            else throw new ArgumentException();
            if (paymentType.ToUpper() == PaymentType.Cash.ToString().ToUpper())
            {
                payment = PaymentType.Cash;
            }
            else if (paymentType.ToUpper() == PaymentType.Visa.ToString().ToUpper())
            {
                payment = PaymentType.Visa;
            }
            else throw new ArgumentException();
            return new Order(products , customerId , orderType , payment);
        }

        public void UpdateTotalPrice()
        {
           
            foreach(var product in ProductsList.ToList())
            {
               
                TotalPrice += product.UnitPrice;
                
            }
        }
        public void SetTotalPrice(decimal totalPrice)
        {
            TotalPrice = totalPrice;
        }
        public void SetProductList(List<Product> products)
        {
            ProductsList = products;
        }

        public void UpdateStatus(OrderStatus status)
        {
            if(status==OrderStatus.Cancelled)
            {
                Status  = OrderStatus.Cancelled;
            }
            else if (status == OrderStatus.Paid)
            {
                Status = OrderStatus.Paid;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
