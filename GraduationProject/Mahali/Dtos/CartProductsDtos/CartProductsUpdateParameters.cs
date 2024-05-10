namespace Mahali.Dtos.CartProductsDtos
{
    public class CartProductsUpdateParameters
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } = 0!;
        public Colors Color { get; set; }
        public Sizes Size { get; set; }
    }
}
