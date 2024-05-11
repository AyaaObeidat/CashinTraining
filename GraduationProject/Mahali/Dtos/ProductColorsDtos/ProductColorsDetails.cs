using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ProductColorsDtos
{
    public class ProductColorsDetails
    {
        public Guid Id { get; set; }
        public Guid ProductId { get;  set; }
        public Colors Color { get;  set; }
    }
}
