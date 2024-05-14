using Mahali.Dtos.AdminDtos;
using Mahali.Dtos.ShopRecuestDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;
using System.Reflection.Metadata;

namespace Mahali.Services
{
    public class AdminService
    {
        private readonly IAdminInterface _adminInterface;
        private readonly IShopInterface _shopInterface;
        private readonly IShopRequestInterface _shopRequestInterface;
        public AdminService(IAdminInterface adminInterface , IShopInterface shopInterface,  IShopRequestInterface shopRequestInterface)
        {
            _adminInterface = adminInterface;
            _shopInterface = shopInterface;
            _shopRequestInterface = shopRequestInterface;
        }

        public async Task<AdminListItems?> RegisterAsync(AdminRegister parameters)
        {
            var admins = await _adminInterface.GetAllAsync(); 
            if(admins.Count <1)
            {
                var admin = Admin.Create(parameters.UserName, parameters.Email, parameters.Password);
                await _adminInterface.AddAsync(admin);
                return new AdminListItems
                {
                   
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Reports = admin.Reports,
                    ShopRequests = admin.ShopRequests,

                };
            }
            return null;
            
        }

        public async Task<AdminListItems?> LoginAsync(AdminLogin login)
        {
            var admin = await _adminInterface.GetByIdAsync(await _adminInterface.GetIdAsync());
            if (admin == null) return null;
            if((login.UserName_Email == admin.UserName || login.UserName_Email==admin.Email) && login.Password==admin.Password)
            {
                return new AdminListItems
                {
                    
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Reports = admin.Reports,
                    ShopRequests = admin.ShopRequests,

                };
            }
            return null;
        }

        public async Task ModifyAccountUserNameAsync(AdminUpdateParameters parameters)
        {
            var admin = await _adminInterface.GetByIdAsync(await _adminInterface.GetIdAsync());
            admin.SetUserName(parameters.UserName);
            await _adminInterface.UpdateAsync(admin);
        }

        public async Task ModifyAccountPasswordAsync(AdminUpdateParameters parameters)
        {
            var admin = await _adminInterface.GetByIdAsync(await _adminInterface.GetIdAsync());
            if (admin.Password == parameters.CurrentPassword)
            {
                admin.SetPassword(parameters.NewPassword);
                await _adminInterface.UpdateAsync(admin);
            }
            else return;
        }

        public async Task<List<ShopRequestListItems>> GetAllShopRequestAsync()
        {
            var admin = await _adminInterface.GetByIdAsync(await _adminInterface.GetIdAsync());
            return admin.ShopRequests.Select(x => new ShopRequestListItems
            {
                ShopId = x.ShopId,
                RequestStatus = x.Status

            }).ToList();
        }


        public async Task UpdateShopRequestStatusAsync(ShopRequestUpdateParameters parameters)
        {
            var shop = await _shopInterface.GetByIdAsync(parameters.ShopId);
            var request = await _shopRequestInterface.GetRequestByShopIdAsync(shop.Id);
            if (request.Status == RequestStatus.Pending)
            {
                if (parameters.Status == RequestStatus.Approved) request.SetRequestStatus(RequestStatus.Approved);
                else if (parameters.Status == RequestStatus.Rejected) request.SetRequestStatus(RequestStatus.Rejected);
                else return;
                await _shopRequestInterface.UpdateAsync(request);
            }
            else return;
        }
    }
}
