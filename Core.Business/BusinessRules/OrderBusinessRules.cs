
using Core.Application.CrossCuttingConcerns.Exceptions;
using Core.Application.Repositories.ProductRepositories;
using Core.Business.Dtos.ProductDtos;
using Core.Business.Messages.Exceptions;
using Core.Domain.Entities;
using FluentValidation;

namespace Core.Business.BusinessRules
{
    public class OrderBusinessRules(IProductRepository productRepository)
    {
        public async Task OrderDetailsMembersCanNotBeNullOrEmpty(string shippingAddress,
                                                                 string postalCode,
                                                                 double price)
        {
            if (string.IsNullOrEmpty(shippingAddress) || string.IsNullOrEmpty(postalCode)) throw new ValidationException(ExceptionMessages.FieldCanNotBeNullOrEmpty);

            if (price <= 0) throw new ValidationException(ExceptionMessages.PriceGreatThanZero);

        }

        public async Task CheckProductExistsInDb(IList<ProductListDto> products)
        {
            if (!products.Any()) throw new BusinessException(ExceptionMessages.ProductCanNotBeNull);

            IEnumerable<Product> _products = productRepository.GetList(p => products.Any(c => c.Id == p.Id));

            if (!_products.Any()) throw new BusinessException(ExceptionMessages.ProductNotFound);
        }
    }
}
