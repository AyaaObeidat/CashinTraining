using System.ComponentModel.DataAnnotations;

namespace Mahali.Models
{
    public class ProductSizes
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Colors Color { get; set; }

        private ProductSizes() { }
        private ProductSizes(Guid productId, Colors color)
        {
            ProductId = productId;
            Color = color;
        }

        public static ProductSizes Create(Guid productId, Colors color)
        {
            if (productId != Guid.Empty) { throw new ArgumentException(); }
            return new ProductSizes(productId, color);
        }
    }
}
