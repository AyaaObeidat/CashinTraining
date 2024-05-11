namespace Mahali.Dtos.PaymentDtos
{
    public class PaymentDetails
    {
        public Guid Id { get; set; }
        public int OrderId { get;  set; }
        public PaymentType Type { get; set; }
    }
}
