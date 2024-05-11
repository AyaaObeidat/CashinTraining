using Mahali.Models;
using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.WishListDtos
{
    public class WishListDetails
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get;  set; }
        public List<WishListProducts> Products { get;  set; }
    }
}
