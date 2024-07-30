using Core.Business.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;


namespace Core.Business.BusinessManager.CategoryBusinessManager
{
    public interface ICategoryManager
    {
        Task<IActionResult> Add(CategoryAddOrUpdateDto categoryAddOrUpdateDto);
        Task<IActionResult> Modify(string name);
        Task<IActionResult> Remove(string name);
        Task<IActionResult> GetAll();
    }
}
