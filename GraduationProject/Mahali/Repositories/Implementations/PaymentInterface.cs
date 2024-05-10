using Mahali.Data;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Repositories.Implementations
{
    public class PaymentInterface : GenericInterface<Payment>, IPaymentInterface
    {
        public PaymentInterface(MahaliDbContext dbContext) : base(dbContext)
        {
        }
    }
}

