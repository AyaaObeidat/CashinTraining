using Mahali.Dtos.ProductDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Services
{
    public class ProductService
    {
        private readonly IProductInterface _productInterface;
        private readonly IShopInterface _shopInterface;

        public ProductService(IProductInterface productInterface , IShopInterface shopInterface)
        {
            _productInterface = productInterface;
            _shopInterface = shopInterface;
        }

        public async Task AddAsync(ProductCreateParameters parameters)
        {
            var shop = await _shopInterface.GetByIdAsync(parameters.shopId);
            foreach(var product in shop.Products.ToList())
            {
                if (product.Name != parameters.Name) continue;
                else break;
            }
            var newProduct = Product.Create(parameters.Name, parameters.Description, parameters.Quantity, parameters.Price, parameters.ImageUri, shop.Id);
            await _productInterface.AddAsync(newProduct);
        }

        public async Task DeleteAsync(ProductDeleteParameters parameters)
        {
            var product = await _productInterface.GetByIdAsync(parameters.ProductId);
            await _productInterface.DeleteAsync(product);
        }

        public async Task<List<ProductListItems>?> GetAllAsync()
        {
            var products = await _productInterface.GetAllAsync();
            if (products == null) return null;
            return products.Select(p => new ProductListItems
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ShopId = p.ShopId,
                ColorsList = p.ColorsList,
                SizesList = p.SizesList,
                Carts = p.Carts,
                WishLists = p.WishLists,
                Orders = p.Orders,
                Reviews = p.Reviews,
            }).ToList();
        }

        public async Task<ProductListItems?> GetByIdAsync(ProductGetByParameter parameter)
        {
            var product = await _productInterface.GetByIdAsync(parameter.ProductId);
            if (product == null) return null;
            return new ProductListItems
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ShopId = product.ShopId,
                ColorsList = product.ColorsList,
                SizesList = product.SizesList,
                Carts = product.Carts,
                WishLists = product.WishLists,
                Orders = product.Orders,
                Reviews = product.Reviews,
            };
        }

        public async Task ModifyProductNameAsync(ProductUpdateParameters parameters)
        {
            var selectedProduct = await _productInterface.GetByIdAsync(parameters.Id);
            if (selectedProduct == null) return;
            var shop =await _shopInterface.GetByIdAsync(selectedProduct.ShopId);
            foreach(var product in shop.Products.ToList())
            {
                if (product.Name == parameters.NewName) break;
                else continue;
            }

            selectedProduct.SetName(parameters.NewName);
            await _productInterface.UpdateAsync(selectedProduct);
        }

        public async Task ModifyProductDescriptionAsync(ProductUpdateParameters parameters)
        {
            var selectedProduct = await _productInterface.GetByIdAsync(parameters.Id);
            if (selectedProduct == null) return;
            
            selectedProduct.SetDescription(parameters.NewDescription);
            await _productInterface.UpdateAsync(selectedProduct);
        }

        public async Task ModifyProductQuantityAsync(ProductUpdateParameters parameters)
        {
            var selectedProduct = await _productInterface.GetByIdAsync(parameters.Id);
            if (selectedProduct == null) return;
            
            selectedProduct.SetQuantity(parameters.NewQuantity);
            await _productInterface.UpdateAsync(selectedProduct);
        }

        public async Task ModifyProductPriceAsync(ProductUpdateParameters parameters)
        {
            var selectedProduct = await _productInterface.GetByIdAsync(parameters.Id);
            if (selectedProduct == null) return;

            selectedProduct.SetPrice(parameters.NewPrice);
            await _productInterface.UpdateAsync(selectedProduct);
        }

        public async Task ModifyProductImageUriAsync(ProductUpdateParameters parameters)
        {
            var selectedProduct = await _productInterface.GetByIdAsync(parameters.Id);
            if (selectedProduct == null) return;
            var shop = await _shopInterface.GetByIdAsync(selectedProduct.ShopId);
            foreach (var product in shop.Products.ToList())
            {
                if (product.ImageUri == parameters.NewImageUri) break;
                else continue;
            }

            selectedProduct.SetImageUri(parameters.NewImageUri);
            await _productInterface.UpdateAsync(selectedProduct);
        }

        public async Task AddToCategoryAsync(ProductGetByParameter parameter)
        {
            var product = await _productInterface.GetByIdAsync(parameter.ProductId);
            if (product == null) return;
            product.SetCategoryId(parameter.CategoryId);    
            await _productInterface.UpdateAsync(product);
        }
    }
}
