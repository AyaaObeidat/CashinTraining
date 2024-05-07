using System.ComponentModel.DataAnnotations;

namespace Mahali.Models
{
    public class ProductSizes
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Sizes Size { get; set; }

        private ProductSizes() { }
        private ProductSizes(Guid productId, Sizes size)
        {
            ProductId = productId;
            Size = size;
        }

        public static ProductSizes Create(Guid productId, Sizes size)
        {
            if (productId != Guid.Empty) { throw new ArgumentException(); }
            return new ProductSizes(productId, size);
        }
    }
}
