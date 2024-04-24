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

        //===========================================================
        public Order()
        {
            
        }
        public Order(List<Product> products)
        {
            ProductsList = products;
            SetTotalPrice();
        }

        //=============================================================
        public static Order Create(List<Product> products)
        { 
            return new Order(products);
        }

        public void SetTotalPrice()
        {
            foreach(var product in ProductsList.ToList())
            {
                TotalPrice += product.UnitPrice;
            }
        }
    }
}
