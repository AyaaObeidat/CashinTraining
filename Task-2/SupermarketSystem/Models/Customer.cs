namespace SupermarketSystem.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        public long PhoneNumber { get;private set; } 
        public Guid AddressId { get; private set; }
        public List<Order> OrdersList { get; private set; }
        private Customer() { }
        private Customer ( string name, long phoneNumber , Guid addressId)
        {
            
            Name = name;
            PhoneNumber = phoneNumber;
            AddressId = addressId;
        }

        public static Customer Create( string name , long phoneNumber, Guid addressId)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(); }
            if(phoneNumber < 10) { throw new ArgumentOutOfRangeException(); }
            return new Customer ( name , phoneNumber, addressId);
        } 

        public void SetName (string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(); }
            Name = name; 
        }
        public void SetPhoneNumber(long phoneNumber)
        {
            if (phoneNumber < 10) { throw new ArgumentOutOfRangeException(); }
            PhoneNumber = phoneNumber;
        }

    }
}
