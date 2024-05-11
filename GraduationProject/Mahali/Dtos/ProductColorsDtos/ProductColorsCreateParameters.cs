using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductColorsDtos
{
    public class ProductColorsCreateParameters
    {

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Colors Color { get; set; }
    }
}
