namespace Mahali.Dtos.DiscountDtos
{
    public class DiscountListItems
    {
        public Guid Id { get; set; }
        public decimal DiscountPercentage { get; set; }
        public Guid ProductId { get; set; }
    }
}
