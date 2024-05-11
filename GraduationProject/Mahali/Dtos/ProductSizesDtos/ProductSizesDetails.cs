using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductSizesDtos
{
    public class ProductSizesDetails
    {
        public Guid Id { get; set; }
        public Guid ProductId { get;  set; }
        public Sizes Size { get;  set; }
    }
}
