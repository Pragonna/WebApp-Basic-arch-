using AutoMapper;
using Core.Application.Repositories.CategoryRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.CategoryDtos;
using Core.Business.Results;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Core.Business.BusinessManager.CategoryBusinessManager
{
    public class CategoryManager(ICategoryRepository categoryRepository,
                                 CategoryBusinessRules categoryBusinessRules,
                                 IManager manager,
                                 IMapper mapper) : ICategoryManager
    {
        public async Task<IActionResult> Add(CategoryAddOrUpdateDto categoryAddOrUpdateDto)
        {
            await categoryBusinessRules.CategoryNameCanNotBeDuplicated(categoryAddOrUpdateDto.CategoryName);

            Category mappedCategory = mapper.Map<Category>(categoryAddOrUpdateDto);
            Category createdCategory = await categoryRepository.AddAsync(mappedCategory);

            var result =mapper.Map<CategoryListDto>(createdCategory);
            return manager.Result(result);
        }

        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Category> categories = categoryRepository.GetList().ToList();
            var result= mapper.Map<IEnumerable<CategoryListDto>>(categories);
            return manager.Result(result);
        }

        public Task<IActionResult> Modify(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Remove(string name)
        {
            throw new NotImplementedException();
        }
    }
}
