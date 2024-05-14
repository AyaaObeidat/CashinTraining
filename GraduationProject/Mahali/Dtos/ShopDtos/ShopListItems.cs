using Mahali.Models;

namespace Mahali.Dtos.ShopDtos
{
    public class ShopListItems
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public long PhoneNumber { get; set; }
        public List<ShopOrders> Orders { get;  set; }
        public List<ReviewRequest> Reviews { get;  set; }
    }
}
