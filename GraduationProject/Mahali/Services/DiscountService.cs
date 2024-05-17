using Mahali.Dtos.DiscountDtos;
using Mahali.Models;
using Mahali.Repositories.Interfaces;

namespace Mahali.Services
{
    public class DiscountService
    {
        private readonly IDiscountInterface _discountInterface;
        private readonly IProductInterface _productInterface;

        public DiscountService(IDiscountInterface discountInterface , IProductInterface productInterface)
        {
            _discountInterface = discountInterface;
            _productInterface = productInterface;
        }

        public async Task AddDiscountAsync(DiscountCreateParameters parameters)
        {
            var product = await _productInterface.GetByIdAsync(parameters.ProductId);
            if(product == null) { return; }

            var discounts = await _discountInterface.GetAllAsync();
            foreach (var discountItem in discounts)
            {
                if (discountItem.ProductId != parameters.ProductId) continue;
                else return;
            }

            var discount = Discount.Create(parameters.ProductId , parameters.DiscountPercentage , parameters.StartDate , parameters.EndDate );
            decimal priceBeforeDiscount = product.Price;
            decimal priceAfterDiscount = priceBeforeDiscount-(parameters.DiscountPercentage * priceBeforeDiscount);
            if(priceAfterDiscount <= 0) { return; }

            product.SetPrice(priceAfterDiscount);
            await _productInterface.UpdateAsync(product);

            await _discountInterface.AddAsync(discount);
        }

        public async Task DeleteDiscountAsync(DiscountDeleteParameters parameters)
        {
            var product = await _productInterface.GetByIdAsync(parameters.ProductId);
            if (product == null) { return; }

            decimal priceAfterDiscount = product.Price;
            decimal priceBeforeDiscount;


            var discounts = await _discountInterface.GetAllAsync();
            foreach (var discountItem in discounts)
            {
                if (discountItem.ProductId == parameters.ProductId)
                {
                    await _discountInterface.DeleteAsync(discountItem);
                    priceBeforeDiscount = priceAfterDiscount / (1 - discountItem.DiscountPercentage);
                    product.SetPrice(priceBeforeDiscount);
                    await _productInterface.UpdateAsync(product);
                }
                else return;
            }
        }
    }
}
