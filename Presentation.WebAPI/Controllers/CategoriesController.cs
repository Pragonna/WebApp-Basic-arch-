using Core.Business.BusinessManager.CategoryBusinessManager;
using Core.Business.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "OnlyUser")]
    public class CategoriesController(ICategoryManager categoryManager) : ControllerBase
    {
        [HttpPost("post")]
        public async Task<IActionResult> Create([FromBody] CategoryAddOrUpdateDto categoryAddOrUpdateDto)
        {
            var result = await categoryManager.Add(categoryAddOrUpdateDto);
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await categoryManager.GetAll();
            return Ok(result);
        }
    }
}
