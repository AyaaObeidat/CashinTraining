using Mahali.Models;
using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.WishListDtos
{
    public class WishListCreateParameters
    {
       
        [Required]
        public Guid CustomerId { get;  set; }
    }
}
