namespace Mahali.Dtos.ProductColorsDtos
{
    public class ProductColorsUpdateParameters
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Colors Color { get; set; }
    }
}
