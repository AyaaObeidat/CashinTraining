using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ReviewsRequestDtos
{
    public class ReviewRequestDetails
    {
        public Guid Id { get; set; }
        public string ReviewContentBody { get;  set; } 
        public DateTime CreatedAt { get;  set; }
        public Guid ProductId { get;  set; }
        public Guid CustomerId { get;  set; }
        public RequestStatus Status { get;  set; }
    }
}
