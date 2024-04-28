namespace SupermarketSystem.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        private Country() { }
        private Country( string name)
        {
            
            Name = name;
        }

        public static Country Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return new Country( name);
        }

    }
}
