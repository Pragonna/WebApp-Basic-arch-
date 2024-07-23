
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
        {
            ProductListDto result = await productManager.Add(productAddDto);
            return Ok(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductListDto> result = await productManager.GetAll();
            return Ok(result);
        }
        [HttpGet("getByCategoryId")]
        public async Task<IActionResult> GetByCategory([FromQuery] int categoryId)
        {
            IEnumerable<ProductListDto> result = await productManager.GetByCategoryId(categoryId);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Modify([FromBody] ProductUpdateDto productUpdateDto)
        {
            ProductListDto result = await productManager.Modify(productUpdateDto);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Remove([FromQuery] string name)
        {
            ProductListDto result = await productManager.Remove(name);
            return Ok(result);
        }
    }
}
