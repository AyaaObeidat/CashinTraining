using Mahali.Models;

namespace Mahali.Dtos.AdminDtos
{
    public class AdminDetails
    {
        public Guid Id { get; set; }
        public string UserName { get;  set; } 
        public string Password { get;  set; }
        public string Email { get;  set; } 
        public List<Report> Reports { get;  set; }
        public List<ShopRequest> ShopRequests { get;  set; }
    }
}
