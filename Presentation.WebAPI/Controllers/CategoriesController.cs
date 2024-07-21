using Core.Business.BusinessManager.CategoryBusinessManager;
using Core.Business.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy:"OnlyUser")]
    public class CategoriesController([FromBody]ICategoryManager categoryManager) : ControllerBase
    {
        [HttpPost("post")]

        public async Task<IActionResult> CreateCategory([FromBody] CategoryAddOrUpdateDto categoryAddOrUpdateDto)
        {
            return Ok(await categoryManager.Add(categoryAddOrUpdateDto));
        }
    }
}
