using SupermarketSystem.Models;

namespace SupermarketSystem.Dtos.CustomerDtos
{
    public class CustomerDetails
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public long PhoneNumber { get;  set; }
        public Guid AddressId { get;  set; }
        public List<Order> orders { get; set; }
    }
}
