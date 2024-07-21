using AutoMapper;
using Core.Application.Repositories.ProductRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public class ProductManager(IProductRepository productRepository,
                                ProductBusinessRules productBusinessRules,
                                IMapper mapper) : IProductManager
    {
        public async Task<ProductAddDto> Add(ProductAddDto productAddOrUpdateDto)
        {
            await productBusinessRules.SameNameProductCanNotDuplicatedWhenInsert(productAddOrUpdateDto.ProductName);
            await productBusinessRules.CheckCategoryExistWhenProductInsert(productAddOrUpdateDto.CategoryId);

            Product mappedProduct = mapper.Map<Product>(productAddOrUpdateDto);
            var createdProduct = await productRepository.AddAsync(mappedProduct);
            return mapper.Map<ProductAddDto>(createdProduct);
        }

        public Task<IEnumerable<ProductListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductAddDto> Modify(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ProductAddDto> Remove(string name)
        {
            throw new NotImplementedException();
        }
    }
}
