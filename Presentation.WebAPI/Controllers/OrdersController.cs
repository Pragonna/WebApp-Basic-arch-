using Core.Business.BusinessManager.OrderBusinessManager;
using Core.Business.Dtos.OrderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy ="OnlyUser")]
    public class OrdersController (IOrderManager orderManager) : ControllerBase
    {
        [HttpPost("post")]
        public async Task<IActionResult> CreateOrder([FromBody]OrderCreateDto orderCreateDto)
        {
            var result=await orderManager.CreateOrder(orderCreateDto);
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await orderManager.GetAllOrders();

            return Ok(result);
        }
    }
}
