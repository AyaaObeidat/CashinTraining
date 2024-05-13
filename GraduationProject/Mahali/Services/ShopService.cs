using Mahali.Dtos.ProductDtos;
using Mahali.Dtos.ReviewsRequestDtos;
using Mahali.Dtos.ShopDtos;
using Mahali.Dtos.ShopOrdersDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

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

       
        public async Task ModifyShopNameAsync(ShopUpdateParameters parameters)
        {

           var request = await _shopRequestInterface.GetRequestByShopIdAsync(parameters.Id);
           var shops = await _shopInterface.GetAllAsync();
           if (request.Status == RequestStatus.Approved)
           {
              foreach (var shop in shops)
              {
                if (shop.Name != parameters.Name) { continue; }
                else break;
              }
              var selectedShop = await _shopInterface.GetByIdAsync(parameters.Id);
              selectedShop.SetName(parameters.Name);
              await _shopInterface.UpdateAsync(selectedShop);
           }
        }
        public async Task ModifyShopPasswordAsync(ShopUpdateParameters parameters)
        {
            var request = await _shopRequestInterface.GetRequestByShopIdAsync(parameters.Id);
            var shops = await _shopInterface.GetAllAsync();
            if (request.Status == RequestStatus.Approved)
            {
                foreach (var shop in shops)
                {
                    if (shop.Password != parameters.NewPassword) { continue; }
                    else break;
                }
                var selectedShop = await _shopInterface.GetByIdAsync(parameters.Id);
                if (selectedShop.Password == parameters.CurrentPassword)
                {
                    selectedShop.SetPassword(parameters.NewPassword);
                    await _shopInterface.UpdateAsync(selectedShop);
                }

            }
        }


        public async Task ModifyShopPhoneNumberAsync(ShopUpdateParameters parameters)
        {
            var request = await _shopRequestInterface.GetRequestByShopIdAsync(parameters.Id);
            var shops = await _shopInterface.GetAllAsync();
            if (request.Status == RequestStatus.Approved)

            {
                foreach (var shop in shops)
                {
                    if (shop.PhoneNumber != parameters.PhoneNumber) { continue; }
                    else break;
                }
                var selectedShop = await _shopInterface.GetByIdAsync(parameters.Id);
                selectedShop.SetPhoneNumber(parameters.PhoneNumber);
                await _shopInterface.UpdateAsync(selectedShop);
            }
        }

        public async Task ModifyShopDescriptionAsync(ShopUpdateParameters parameters)
        {
            var request = await _shopRequestInterface.GetRequestByShopIdAsync(parameters.Id);
            if (request.Status == RequestStatus.Approved)
            {

                var selectedShop = await _shopInterface.GetByIdAsync(parameters.Id);
                selectedShop.SetDescription(parameters.Description);
                await _shopInterface.UpdateAsync(selectedShop);
            }
        }

        public async Task<List<ShopOrdersDetails>> GetAllShopOrdersAsync(string shopName)
        {
            var shop = await _shopInterface.GetByNameAsync(shopName);
            var orders = shop.Orders.ToList();
            return orders.Select(x => new ShopOrdersDetails
            {
                Id = x.Id,
                ShopId = x.ShopId,
                OrderId = x.OrderId,
            }).ToList();
        }

        public async Task<List<ProductListItems>> GetAllShopProductsAsync(string shopName)
        {
            var shop = await _shopInterface.GetByNameAsync(shopName);
            var products = shop.Products.ToList();
            return products.Select(x => new ProductListItems
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Quantity = x.Quantity,
                Price = x.Price,
                ImageUri = x.ImageUri,
                ColorsList = x.ColorsList,
                SizesList = x.SizesList,
            }).ToList();
        }

        public async Task<List<ReviewRequestDetails>> GetAllReviewsListAsync(string shopName)
        {
            var shop = await _shopInterface.GetByNameAsync(shopName);
            var reviews = shop.Reviews.ToList();
            return reviews.Select(x => new ReviewRequestDetails
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                ReviewContentBody = x.ReviewContentBody,
                CreatedAt = x.CreatedAt,
                Status = x.Status,
            }).ToList();
        }

    }
}
   
