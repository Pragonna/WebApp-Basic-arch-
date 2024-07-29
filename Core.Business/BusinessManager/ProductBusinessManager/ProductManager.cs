using AutoMapper;
using Core.Application.Repositories.ProductRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public class ProductManager(IProductRepository productRepository,
                                ProductBusinessRules productBusinessRules,
                                IMapper mapper) : IProductManager
    {
        public async Task<ProductListDto> Add(ProductAddDto productAddOrUpdateDto)
        {
            await productBusinessRules.SameNameProductCanNotDuplicatedWhenInsert(productAddOrUpdateDto.ProductName);
            await productBusinessRules.CheckCategoryExistsWhenProductInsert(productAddOrUpdateDto.CategoryId);

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
            IEnumerable<Product> products = productRepository.GetList(include: p => p.Include(x => x.Category),
                                                                      enableTracking: false);
            return mapper.Map<IEnumerable<ProductListDto>>(products);
        }

        public async Task<ProductListDto> Modify(ProductUpdateDto productUpdateDto)
        {
            var product = await productBusinessRules.CheckProductExistsWhenModifyOrRemove(productUpdateDto.Name);

            await productBusinessRules.SameNameProductCanNotDuplicatedWhenInsert(productUpdateDto.ProductAddDto.ProductName);

            product.ProductName = productUpdateDto.ProductAddDto.ProductName;
            product.Price = productUpdateDto.ProductAddDto.Price;
            product.CategoryId = productUpdateDto.ProductAddDto.CategoryId;
            product.Stock = productUpdateDto.ProductAddDto.Stock;

            Product modifiedProduct = await productRepository.ModifyAsync(product);
            return mapper.Map<ProductListDto>(modifiedProduct);
        }

        public async Task<ProductListDto> Remove(string name)
        {
            var product = await productBusinessRules.CheckProductExistsWhenModifyOrRemove(name);

            Product removedProduct = await productRepository.DeleteAsync(product);
            return mapper.Map<ProductListDto>(removedProduct);
        }
    }
}
