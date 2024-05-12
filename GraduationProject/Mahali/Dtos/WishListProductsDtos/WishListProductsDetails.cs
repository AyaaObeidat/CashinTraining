using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.WishListProductsDtos
{
    public class WishListProductsDetails
    {
        public Guid Id { get; set; }
        public Guid WishListId { get;  set; }
        public Guid ProductId { get;  set; }
    }
}
