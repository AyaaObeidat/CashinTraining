namespace Mahali.Dtos.DiscountDtos
{
    public class DiscountUpdateParameters
    {
        public Guid Id { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ProductId { get; set; }
    }
}
