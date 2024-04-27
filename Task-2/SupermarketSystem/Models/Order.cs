using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupermarketSystem.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal TotalPrice { get; private set; } = 0;
        public List<Product> ProductsList { get; private set; }
        public Order()
        {
            
        }
        public Order(List<Product> products)
        {
            ProductsList = products;
            UpdateTotalPrice();
        }
        public static Order Create(List<Product> products)
        { 
            return new Order(products);
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
    }
}
