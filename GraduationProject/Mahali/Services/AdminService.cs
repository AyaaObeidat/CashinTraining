using Mahali.Dtos.AdminDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;
using System.Runtime.InteropServices;

namespace Mahali.Services
{
    public class AdminService
    {
        private readonly IAdminInterface _adminInterface;
        //public static Admin admin;

        public AdminService(IAdminInterface adminInterface)
        {
            _adminInterface = adminInterface;
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
            var admin = await _adminInterface.GetByIdAsync();

            if((userName_Email == admins.First().UserName || userName_Email==admins.First().Email) && password==admins.First().Password)
            {
                return new AdminDetails
                {
                    Id = admi.Id,
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Password = admin.Password,
                    Reports = admin.Reports,
                    ShopRequests = admin.ShopRequests,

                };
            }
            return null;
        }
    }
}
