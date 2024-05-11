using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ReviewsRequestDtos
{
    public class ReviewRequestCreateParameters
    {
        [Required(ErrorMessage = "Review content body is required")]
        public string ReviewContentBody { get; private set; } = null!;
        public Guid ProductId { get; private set; }
        public Guid CustomerId { get; private set; }
    }
}
