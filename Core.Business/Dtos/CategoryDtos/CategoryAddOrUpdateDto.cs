using Core.Application.Repositories.CategoryRepositories;
using Core.Business.BusinessManager.CategoryBusinessManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Dtos.CategoryDtos
{
    public class CategoryAddOrUpdateDto
    {
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; } = string.Empty;
    }
}
