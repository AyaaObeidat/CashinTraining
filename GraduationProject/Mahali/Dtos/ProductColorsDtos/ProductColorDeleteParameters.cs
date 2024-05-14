using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductColorsDtos
{
    public class ProductColorDeleteParameters
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid ProductColorId { get; set; }
    }
}
