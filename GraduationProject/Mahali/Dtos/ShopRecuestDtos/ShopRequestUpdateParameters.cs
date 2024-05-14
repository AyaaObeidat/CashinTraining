namespace Mahali.Dtos.ShopRecuestDtos
{
    public class ShopRequestUpdateParameters
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }

        public Guid ShopId { get; set; }
    }
}
