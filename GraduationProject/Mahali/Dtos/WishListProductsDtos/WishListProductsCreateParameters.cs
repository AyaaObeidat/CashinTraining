using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.WishListProductsDtos
{
    public class WishListProductsCreateParameters
    {
        [Required]
        public Guid WishListId { get; private set; }
        [Required]
        public Guid ProductId { get; private set; }
    }
}
