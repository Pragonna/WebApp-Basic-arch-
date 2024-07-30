using Core.Business.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace Core.Business.BusinessManager.ProductBusinessManager
{
    public interface IProductManager
    {
        Task<IActionResult> Add(ProductAddDto productAddOrUpdateDto);
        Task<IActionResult> Modify(ProductUpdateDto productUpdateDto);
        Task<IActionResult> Remove(string name);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetByCategoryId(int categoryId);
    }
}