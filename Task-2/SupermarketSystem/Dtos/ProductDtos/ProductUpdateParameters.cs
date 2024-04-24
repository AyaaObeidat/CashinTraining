namespace SupermarketSystem.Dtos.ProductDtos
{
    public class ProductUpdateParameters
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get;  set; }
        public int Quantity { get;  set; }
    }
}
