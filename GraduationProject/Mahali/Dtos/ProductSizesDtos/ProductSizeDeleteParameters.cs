using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductSizesDtos
{
    public class ProductSizeDeleteParameters
    {

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid ProductSizeId { get; set; }
    }
}
