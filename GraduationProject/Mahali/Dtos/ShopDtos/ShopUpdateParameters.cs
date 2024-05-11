namespace Mahali.Dtos.ShopDtos
{
    public class ShopUpdateParameters
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public Guid LocationId { get; set; }
    }
}
