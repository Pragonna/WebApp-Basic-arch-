using Core.Business.BusinessManager.UserBusinessManager;
using Core.Business.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthSignController(IUserManager userManager) : ControllerBase
    {
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            UserRegisterDto registerDto = await userManager.Registration(userRegisterDto);

            return Ok(registerDto);
        }
        [HttpPost("signin")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var token= await userManager.Login(userLoginDto);
            return Ok(token);
        }

    }
}
