namespace Mahali.Dtos.ShopRecuestDtos
{
    public class ShopRequestDetails
    {
        public Guid Id { get; set; }
        public Guid AdminId { get;  set; }
        public Guid ShopId { get;  set; }
        public RequestStatus Status { get;  set; }

    }
}
