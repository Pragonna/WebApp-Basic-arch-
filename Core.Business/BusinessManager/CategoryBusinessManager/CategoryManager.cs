using AutoMapper;
using Core.Application.Repositories.CategoryRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.CategoryDtos;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.BusinessManager.CategoryBusinessManager
{
    public class CategoryManager(ICategoryRepository categoryRepository,
                                 CategoryBusinessRules categoryBusinessRules,
                                 IMapper mapper) : ICategoryManager
    {
        public async Task<CategoryAddOrUpdateDto> Add(CategoryAddOrUpdateDto categoryAddOrUpdateDto)
        {
            await categoryBusinessRules.CategoryNameCanNotBeDuplicated(categoryAddOrUpdateDto.CategoryName);

            Category mappedCategory = mapper.Map<Category>(categoryAddOrUpdateDto);
            Category createdCategory = await categoryRepository.AddAsync(mappedCategory);
            return mapper.Map<CategoryAddOrUpdateDto>(createdCategory);
        }

        public async Task<IEnumerable<CategoryListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryAddOrUpdateDto> Modify(string name)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryAddOrUpdateDto> Remove(string name)
        {
            throw new NotImplementedException();
        }
    }
}
