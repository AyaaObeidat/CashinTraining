namespace Mahali.Dtos.ProductSizesDtos
{
    public class ProductSizesUpdateParameters
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Sizes Size { get; set; }
    }
}
