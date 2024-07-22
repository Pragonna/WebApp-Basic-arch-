
using Core.Business.BusinessManager.ProductBusinessManager;
using Core.Business.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

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
    }
}
