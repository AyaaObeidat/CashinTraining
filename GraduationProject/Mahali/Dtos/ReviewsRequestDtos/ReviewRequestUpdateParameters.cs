namespace Mahali.Dtos.ReviewsRequestDtos
{
    public class ReviewRequestUpdateParameters
    {
        public Guid Id { get; set; }
        public string ReviewContentBody { get; set; }
        public RequestStatus Status { get; set; }
    }
}
