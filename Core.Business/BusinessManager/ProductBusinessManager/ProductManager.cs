using AutoMapper;
using Core.Application.Repositories.ProductRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.ProductDtos;
using Core.Business.Results;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public class ProductManager(IProductRepository productRepository,
                                ProductBusinessRules productBusinessRules,
                                IManager manager,
                                IMapper mapper) : IProductManager
    {
        public async Task<IActionResult> Add(ProductAddDto productAddOrUpdateDto)
        {
            await productBusinessRules.SameNameProductCanNotDuplicatedWhenInsert(productAddOrUpdateDto.ProductName);
            await productBusinessRules.CheckCategoryExistsWhenProductInsert(productAddOrUpdateDto.CategoryId);

            Product mappedProduct = mapper.Map<Product>(productAddOrUpdateDto);
            var createdProduct = await productRepository.AddAsync(mappedProduct);
            var result= mapper.Map<ProductListDto>(createdProduct);
            return manager.Result(result);
        }
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            IEnumerable<Product> products = productRepository.GetList(x => x.CategoryId == categoryId).ToList();
            var result= mapper.Map<IEnumerable<ProductListDto>>(products);
            return manager.Result(result);
        }
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product> products = productRepository.GetList(include: p => p.Include(x => x.Category),
                                                                      enableTracking: false);
            var result = mapper.Map<IEnumerable<ProductListDto>>(products);
            return manager.Result(result);
        }

        public async Task<IActionResult> Modify(ProductUpdateDto productUpdateDto)
        {
            var product = await productBusinessRules.CheckProductExistsWhenModifyOrRemove(productUpdateDto.Name);

            await productBusinessRules.SameNameProductCanNotDuplicatedWhenInsert(productUpdateDto.ProductAddDto.ProductName);

            product.ProductName = productUpdateDto.ProductAddDto.ProductName;
            product.Price = productUpdateDto.ProductAddDto.Price;
            product.CategoryId = productUpdateDto.ProductAddDto.CategoryId;
            product.Stock = productUpdateDto.ProductAddDto.Stock;

            Product modifiedProduct = await productRepository.ModifyAsync(product);
            var result= mapper.Map<ProductListDto>(modifiedProduct);
            return manager.Result(result);
        }

        public async Task<IActionResult> Remove(string name)
        {
            var product = await productBusinessRules.CheckProductExistsWhenModifyOrRemove(name);

            Product removedProduct = await productRepository.DeleteAsync(product);
            var result= mapper.Map<ProductListDto>(removedProduct);
            return manager.Result(result);
        }
    }
}
