using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.DiscountDtos
{
    public class DiscountCreateParameters
    {
        [Required(ErrorMessage = "Discount percentage is required")]
        public decimal DiscountPercentage { get; private set; }

        [Required(ErrorMessage = "Start date of discount is required")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Date and time must be in the format yyyy-MM-dd HH:mm:ss")]
        public string StartDate { get; private set; }

        [Required(ErrorMessage = "End date of discount is required")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Date and time must be in the format yyyy-MM-dd HH:mm:ss")]
        public string EndDate { get; private set; }
        public Guid ProductId { get; private set; }
    }
}
