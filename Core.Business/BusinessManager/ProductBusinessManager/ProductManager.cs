using AutoMapper;
using Core.Application.Repositories.ProductRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.CategoryDtos;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public class ProductManager(IProductRepository productRepository,
                                ProductBusinessRules productBusinessRules,
                                IMapper mapper) : IProductManager
    {
        public async Task<ProductListDto> Add(ProductAddDto productAddOrUpdateDto)
        {
            await productBusinessRules.SameNameProductCanNotDuplicatedWhenInsert(productAddOrUpdateDto.ProductName);
            await productBusinessRules.CheckCategoryExistWhenProductInsert(productAddOrUpdateDto.CategoryId);

            Product mappedProduct = mapper.Map<Product>(productAddOrUpdateDto);
            var createdProduct = await productRepository.AddAsync(mappedProduct);
            return mapper.Map<ProductListDto>(createdProduct);
        }
        public async Task<IEnumerable<ProductListDto>> GetByCategoryId(int categoryId)
        {
            IEnumerable<Product> products = productRepository.GetList(x => x.CategoryId == categoryId).ToList();
            return mapper.Map<IEnumerable<ProductListDto>>(products);
        }
        public async Task<IEnumerable<ProductListDto>> GetAll()
        {
            IEnumerable<Product> products = productRepository.GetList().ToList();
            return mapper.Map<IEnumerable<ProductListDto>>(products);
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
