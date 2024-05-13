using Mahali.Dtos.AdminDtos;
using Mahali.Dtos.ReportDtos;
using Mahali.Dtos.ShopRecuestDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Services
{
    public class AdminService
    {
        private readonly IAdminInterface _adminInterface;
        private readonly IShopInterface _shopInterface;
        private readonly IReportInterface _reportInterface;
        private readonly IShopRequestInterface _shopRequestInterface;
        public AdminService(IAdminInterface adminInterface , IShopInterface shopInterface, IReportInterface reportInterface , IShopRequestInterface shopRequestInterface)
        {
            _adminInterface = adminInterface;
            _shopInterface = shopInterface;
            _reportInterface = reportInterface;
            _shopRequestInterface = shopRequestInterface;
        }

        public async Task<AdminDetails?> RegisterAsync(AdminRegister parameters)
        {
            var admins = await _adminInterface.GetAllAsync(); 
            if(admins.Count <1)
            {
                var admin = Admin.Create(parameters.UserName, parameters.Email, parameters.Password);
                await _adminInterface.AddAsync(admin);
                return new AdminDetails
                {
                    Id = admin.Id,
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Password = admin.Password,
                    Reports = admin.Reports,
                    ShopRequests = admin.ShopRequests,

                };
            }
            return null;
            
        }

        public async Task<AdminDetails?> LoginAsync(string userName_Email , string password)
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            if(admin==null)
            if((userName_Email == admin.UserName || userName_Email==admin.Email) && password==admin.Password)
            {
                return new AdminDetails
                {
                    Id = admin.Id,
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Password = admin.Password,
                    Reports = admin.Reports,
                    ShopRequests = admin.ShopRequests,

                };
            }
            return null;
        }

        public  async Task<List<ShopRequestListItems>> GetAllShopRequestAsync()
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            return admin.ShopRequests.Select( x => new ShopRequestListItems
            {
                ShopId = x.ShopId,
                RequestStatus = x.Status

            }).ToList();
            return null;
        }

        public async Task<List<ReportListItems>> GetAllReportsAsync()
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            return admin.Reports.Select(x => new ReportListItems
            {
               ShopId = x.ShopId,
               ReportText = x.ReportText,
               CreatedAt = x.CreatedAt,
               LastModifiedTime = x.LastModifiedTime,

            }).ToList();
            return null;
        }

        public async Task ModifyAccountUserNameAsync(AdminUpdateParameters parameters)
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            admin.SetUserName(parameters.UserName);
            await _adminInterface.UpdateAsync(admin);
        }
        public async Task ModifyAccountPasswordAsync(AdminUpdateParameters parameters)
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            if (admin.Password == parameters.CurrentPassword)
            {
                admin.SetPassword(parameters.NewPassword);
                await _adminInterface.UpdateAsync(admin);
            }
            else return;
        }

        public async Task WriteReportAsync(ReportCreateParameters parameters)
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            var shop = await _shopInterface.GetByNameAsync(parameters.ShopName);
            var request = await _shopRequestInterface.GetRequestByShopIdAsync(shop.Id);
            if(request.Status == RequestStatus.Approved)
            {
                var report = Report.Create(admin.Id, shop.Id, parameters.ReportText);
                await _reportInterface.AddAsync(report);
            }
            
        }
        public async Task EditReportTextAsync(ReportUpdateParameters parameters)
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            var shop = await _shopInterface.GetByNameAsync(parameters.ShopName);
            if (shop == null) return;
            var reports = await _reportInterface.GetAllAsync();
            var report = reports.FirstOrDefault(x => x.ShopId== shop.Id && x.AdminId==admin.Id);
            if (report == null) return;
            report.SetReportText(parameters.ReportText);
            await _reportInterface.UpdateAsync(report);
        }
        public async Task DeleteReportAsync(string shopName)
        {
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            var shop = await _shopInterface.GetByNameAsync(shopName);
            if (shop == null) return;
            var reports = await _reportInterface.GetAllAsync();
            var report = reports.FirstOrDefault(x => x.ShopId == shop.Id && x.AdminId == admin.Id);
            if (report == null) return;
            await _reportInterface.DeleteAsync(report);
        }

        public async Task UpdateShopRequestStatusAsync(string shopName , RequestStatus status)
        {
            var shop = await _shopInterface.GetByNameAsync(shopName);
            var request = await _shopRequestInterface.GetRequestByShopIdAsync(shop.Id);
            if (request.Status == RequestStatus.Pending)
            {
                if (status == RequestStatus.Approved) request.SetRequestStatus(RequestStatus.Approved);
                else if (status == RequestStatus.Rejected) request.SetRequestStatus(RequestStatus.Rejected);
                else return;
                await _shopRequestInterface.UpdateAsync(request);
            }
            else return;
        }
    }
}
