using Mahali.Models;
using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.CartDtos
{
    public class CartDetails
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get;  set; }
        public Guid CustomerId { get;  set; }
        public List<CartProducts> Products { get;  set; }
    }
}
