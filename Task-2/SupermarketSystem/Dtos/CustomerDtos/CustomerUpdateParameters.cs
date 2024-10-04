namespace SupermarketSystem.Dtos.CustomerDtos
{
    public class CustomerUpdateParameters
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public Guid Id { get; set; }
    }
}
