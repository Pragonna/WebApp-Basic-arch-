
using Core.Business.BusinessManager.ProductBusinessManager;
using Core.Business.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy:"OnlyUser")]

    public class ProductsController(IProductManager productManager) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductAddDto productAddDto)
            => await productManager.Add(productAddDto);
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
            => await productManager.GetAll();
        [HttpGet("getByCategoryId")]
        public async Task<IActionResult> GetByCategory([FromQuery] int categoryId)
            => await productManager.GetByCategoryId(categoryId);
        [HttpPut("update")]
        public async Task<IActionResult> Modify([FromBody] ProductUpdateDto productUpdateDto)
            => await productManager.Modify(productUpdateDto);
        [HttpDelete("delete")]
        public async Task<IActionResult> Remove([FromQuery] string name)
            => await productManager.Remove(name);
    }
}
