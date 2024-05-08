namespace Mahali.Models
{
    public class Payment
    {
         

        public Guid Id { get; set; }
        public int OrderId { get;private set; }
        public PaymentType Type { get; set; }
        private Payment() { }
        private Payment(int orderId , PaymentType type)
        {
            OrderId = orderId;
            Type = type;
        }

        public static Payment Create (int  orderId , PaymentType type)
        {
            if(orderId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Payment(orderId , type);
        }
    }
}
