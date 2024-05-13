using Mahali.Dtos.AdminDtos;
using Mahali.Dtos.ShopDtos;
using Mahali.Dtos.ShopOrdersDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Mahali.Services
{
    public class ShopService
    {
        private readonly IShopInterface _shopInterface;
        private readonly IShopRequestInterface _shopRequestInterface;
        private readonly IAdminInterface _adminInterface;

        public ShopService(IShopInterface shopInterface,IShopRequestInterface shopRequestInterface, IAdminInterface adminInterface)
        {
            _shopInterface = shopInterface;
            _shopRequestInterface = shopRequestInterface;
            _adminInterface = adminInterface;
        }

        public async Task RegisterAsync(ShopRegister parameters)
        {
            var shops = await _shopInterface.GetAllAsync();
            foreach (var shop in shops)
            {
                if (shop.Name != parameters.Name && shop.Email != parameters.Email && shop.Password != parameters.Password) continue;
                else break;
            }
            var newShop = Shop.Create(parameters.Name, parameters.Description, parameters.Email, parameters.Password, parameters.PhoneNumber);
            await _shopInterface.AddAsync(newShop);
            var admin = await _adminInterface.GetByUserName(await _adminInterface.GetUserName());
            var request = ShopRequest.Create(admin.Id, newShop.Id);
            await _shopRequestInterface.AddAsync(request);
        }
        public async Task<ShopDetails?> LoginAsync(string userName_Email, string password)
        {
            var shops = await _shopInterface.GetAllAsync();
            foreach (var shop in shops)
            {
                if( ( shop.Name == userName_Email ||  shop.Email == userName_Email) && shop.Password == password)
                {
                    var request = await _shopRequestInterface.GetRequestByShopIdAsync(shop.Id);
                    if(request.Status == RequestStatus.Approved )
                    {
                        return new ShopDetails
                        {
                            Id = shop.Id,
                            Name = shop.Name,
                            Description = shop.Description,
                            Email = shop.Email,
                            Password = password,
                            PhoneNumber = shop.PhoneNumber,
                            Orders = shop.Orders,
                            Reviews = shop.Reviews,
                        };
                    }
                }
            }
            return null;
        }
        }
    }
