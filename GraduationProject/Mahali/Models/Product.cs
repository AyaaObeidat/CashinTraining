using System.ComponentModel.DataAnnotations;

namespace Mahali.Models
{
    public class Product
    {
    
        public Guid Id { get; set; }
        [Required]
        public string Name { get; private set; } = null!;
        [Required]
        public string Description { get; private set; } = null!;
        [Required]
        public int Quantity { get; private set; } 
        [Required]
        public decimal Price { get; private set;} = 0!;
        [Required]
        public string ImageUri { get; private set; } =null!;
        [Required]
        public Guid CategoryId { get;private set; }
        [Required]
        public Guid ShopId { get; private set; }
        [Required]
        public List<Colors> ColorsList { get; private set; }
        [Required]
        public List<Sizes> SizesList { get; private set; }

        public List<CartProducts> Carts {  get; private set; }

        private Product() { }
        private Product(string name , string description , int quantity , decimal price , 
            string imageUri , List<Colors> colors , List<Sizes> sizes , Guid categoryId , Guid shopId)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            ImageUri = imageUri;
            ColorsList = colors;
            SizesList = sizes;
            CategoryId = categoryId;
            ShopId = shopId;

        }

        public static Product Create(string name, string description, int quantity, decimal price,
            string imageUri, List<Colors> colors, List<Sizes> sizes, Guid categoryId, Guid shopId)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(description)) { throw new ArgumentNullException(); }
            if (quantity < 0) { throw new ArgumentOutOfRangeException(); }
            if (price <= 0) { throw new ArgumentOutOfRangeException(); }
            if (string.IsNullOrEmpty(imageUri)) { throw new ArgumentNullException(); }
            if(colors == null) { throw new ArgumentNullException(); }
            if (sizes == null) { throw new ArgumentNullException(); }

            return new Product(name , description, quantity, price, imageUri, colors, sizes, categoryId, shopId);

        }

        public void SetCarts(List<CartProducts> carts)
        {
            Carts = carts;
        }
    }
}
