namespace Mahali.Dtos.PaymentDtos
{
    public class PaymentCreateParameters
    {
        public int OrderId { get;  set; }
        public PaymentType Type { get; set; }
    }
}
