using Core.Business.BusinessManager.UserBusinessManager;
using Core.Business.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthSignController(IUserManager userManager,
                                        ILogger<UserAuthSignController> logger) : ControllerBase
    {
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
            => await userManager.Registration(userRegisterDto);
        [HttpPost("signin")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        => await userManager.Login(userLoginDto);

        [Authorize(policy: "OnlyAdmin")]
        [HttpPut("update-role")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModifyDto userModifyDto)
            => await userManager.ModifyUser(userModifyDto);

        [Authorize(policy: "OnlyAdmin")]
        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAllUser()
            => await userManager.GetAllUser();

        [Authorize(policy: "OnlyAdmin")]
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser([FromQuery] string email)
            => await userManager.DeleteUser(email);

        [Authorize(policy: "OnlyAdmin")]
        [HttpGet("getByEmail")]
        public async Task<IActionResult> FindByEmail([FromQuery] string email)
            => await userManager.FindUserByEmail(email);
    }
}
