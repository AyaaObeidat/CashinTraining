namespace Mahali.Dtos.ReviewsRequestDtos
{
    public class ReviewRequestListItems
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public string ReviewContentBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public RequestStatus Status { get; set; }
    }
}
