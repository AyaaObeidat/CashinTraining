using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.CartProductsDtos
{
    public class CartProductsDetails
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } = 0!;
        public Colors Color { get; set; }
        public Sizes Size { get; set; }
    }
}
