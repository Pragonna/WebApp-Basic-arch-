
using Core.Application.Repositories.ProductRepositories;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.BusinessRules
{
    public class OrderBusinessRules(IProductRepository productRepository)
    {
        public async Task OrderDetailsMembersCanNotBeNullOrEmpty(string shippingAddress,
                                                                 string postalCode,
                                                                 double price)
        {
            if (string.IsNullOrEmpty(shippingAddress) || string.IsNullOrEmpty(postalCode)) throw new Exception("the fields can not be empty or null");

            if (price <= 0) throw new Exception("Price must be great than zero");

        }

        public async Task CheckProductExistsInDb(IList<ProductListDto> products)
        {
            if (!products.Any()) throw new Exception("Products can not be null or empty");

            IEnumerable<Product> _products = productRepository.GetList(p => products.Any(c => c.Id == p.Id));

            if (!_products.Any()) throw new Exception("this products does not exists in database");
        }
    }
}
