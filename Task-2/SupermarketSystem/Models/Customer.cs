namespace SupermarketSystem.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        public long NumberPhone { get;private set; } 
        public Guid AddressId { get; private set; }

        private Customer() { }
        private Customer ( string name, long numberPhone)
        {
            
            Name = name;
            NumberPhone = numberPhone;
        }

        public static Customer Create( string name , long numberPhone)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(); }
            if(numberPhone<10) { throw new ArgumentOutOfRangeException(); }
            return new Customer ( name , numberPhone);
        } 
    }
}
