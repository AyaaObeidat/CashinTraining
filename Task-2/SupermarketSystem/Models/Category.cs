namespace SupermarketSystem.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;

        public List<Product> ProductsList { get; private set; }

        //==================================================
        public Category()
        {
            
        }
        public Category(string name )
        {
            Name = name;
        }
        //===================================================
        public Category Create(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return new Category(name);
        }

        public void SetProductsList(List<Product> products)
        {
            ProductsList = products;
        }
    }
}
