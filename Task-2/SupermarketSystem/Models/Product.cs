using Microsoft.AspNetCore.Server.IIS.Core;

namespace SupermarketSystem.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
       

        //===================================================
        public Product() {}
        public Product(string name , decimal unitPrice , int quantity)
        {
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        //====================================================
        public static Product Create(string name, decimal unitPrice, int quantity)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            if(unitPrice < 0) throw new ArgumentOutOfRangeException();
            if(quantity < 0) throw new ArgumentOutOfRangeException();

            return new Product(name, unitPrice, quantity);
        }

       
        public Product UpdatePrice(decimal price)
        {
            UnitPrice = price;
            return this;
        }
        public Product UpdateQuantity(int quantity)
        {
            Quantity = quantity;
            return this;
        }

    }
}
