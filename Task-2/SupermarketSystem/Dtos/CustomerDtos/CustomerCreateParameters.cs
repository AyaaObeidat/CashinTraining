namespace SupermarketSystem.Dtos.CustomerDtos
{
    public class CustomerCreateParameters
    {
        public string Name { get;  set; }
        public long PhoneNumber { get;  set; }
        public Guid AddressId { get;  set; }
    }
}
