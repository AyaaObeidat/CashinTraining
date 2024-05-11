namespace Mahali.Dtos.OrderProductsDtos
{
    public class OrderProductsUpdateParameters
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Colors Color { get; set; }
        public Sizes Size { get; set; }
    }
}
