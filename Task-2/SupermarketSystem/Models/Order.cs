using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupermarketSystem.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal TotalPrice { get; private set; }
        public List<Product> ProductsList { get; private set; }

        //===========================================================
        public Order()
        {
            
        }
        public Order(List<Product> products)
        {
            ProductsList = products;
        }

        //=============================================================
        public Order Create(List<Product> products)
        {
            if (products == null) throw new ArgumentNullException();
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
