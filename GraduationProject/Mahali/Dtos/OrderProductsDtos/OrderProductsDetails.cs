using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.OrderProductsDtos
{
    public class OrderProductsDetails
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } 
        public Colors Color { get; set; }
        public Sizes Size { get; set; }
    }
}
