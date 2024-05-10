using Mahali.Models;

namespace Mahali.Dtos.CartDtos
{
    public class CartUpdateParameters
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartProducts> Products { get; set; }
    }
}
