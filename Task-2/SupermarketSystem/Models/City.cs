namespace SupermarketSystem.Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        private City() { }
        private City(string name)
        {
            
            Name = name;
        }

        public static City Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            return new City(name);
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(); }
            Name = name;
        }
    }
}
