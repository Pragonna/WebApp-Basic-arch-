using Core.Application.Repositories.OrderDetailsRepositories;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.BusinessRules
{
    public class OrderBusinessRules(IOrderDetailsRepository orderDetailsRepository)
    {
        public async Task OrderProductsCanNotBeNull(ICollection<ProductListDto> products)
        {
            if (!products.Any())
                throw new Exception("this order is empty");
        }
        public async Task OrderPriceMustBeGreatThanZero(double price)
        {
            if (price <= 0)
                throw new Exception("the price must be great than zero");
        }
        public IEnumerable<OrderDetails> CheckOrderExistsInDb()
        {
            IEnumerable<OrderDetails>? orders =orderDetailsRepository.GetList().ToList();
            if (!orders.Any())
                throw new Exception("orders is empty or null");

            return orders;
        }

    }
}
