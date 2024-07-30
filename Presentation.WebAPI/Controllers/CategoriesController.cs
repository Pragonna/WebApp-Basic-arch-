using Core.Business.BusinessManager.CategoryBusinessManager;
using Core.Business.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "OnlyAdmin")]
    public class CategoriesController(ICategoryManager categoryManager) : ControllerBase
    {
        [HttpPost("post")]
        public async Task<IActionResult> Create([FromBody] CategoryAddOrUpdateDto categoryAddOrUpdateDto)
            => await categoryManager.Add(categoryAddOrUpdateDto);

        [HttpGet("getall")]
        public async Task<IActionResult> GetList() => await categoryManager.GetAll();

    }
}
