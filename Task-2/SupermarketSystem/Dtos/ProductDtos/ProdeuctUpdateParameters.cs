namespace SupermarketSystem.Dtos.ProductDtos
{
    public class ProdeuctUpdateParameters
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get;  set; }
        public int Quantity { get;  set; }
        public Guid CategoryId { get;  set; }
    }
}
