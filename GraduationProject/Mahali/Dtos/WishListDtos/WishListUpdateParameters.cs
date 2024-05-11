using Mahali.Models;

namespace Mahali.Dtos.WishListDtos
{
    public class WishListUpdateParameters
    {
        public Guid Id { get; set; }
        public List<WishListProducts> Products { get;  set; }
    }
}
