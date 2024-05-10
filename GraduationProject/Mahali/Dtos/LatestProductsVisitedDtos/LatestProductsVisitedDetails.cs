namespace Mahali.Dtos.LatestProductsVisitedDtos
{
    public class LatestProductsVisitedDetails
    {
        public Guid Id { get; set; }
        public DateTime VisitedDateTime { get;  set; }
        public Guid CustomerId { get;  set; }
        public Guid ProductId { get;  set; }
    }
}
