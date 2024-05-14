using Mahali.Models;

namespace Mahali.Dtos.AdminDtos
{
    public class AdminListItems
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<Report> Reports { get;  set; }
        public List<ShopRequest> ShopRequests { get;  set; }

    }
}
