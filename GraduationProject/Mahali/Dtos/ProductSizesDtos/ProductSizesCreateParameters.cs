using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductSizesDtos
{
    public class ProductSizesCreateParameters
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Sizes Size { get; set; }
    }
}
