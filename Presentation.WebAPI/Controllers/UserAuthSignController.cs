﻿using Core.Business.BusinessManager.UserBusinessManager;
using Core.Business.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthSignController(IUserManager userManager,
                                        ILogger<UserAuthSignController>logger) : ControllerBase
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
            var token = await userManager.Login(userLoginDto);
            return Ok(token);
        }
        [HttpPut("update-role")]
        [Authorize(policy: "OnlyAdmin")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModifyDto userModifyDto)
        {
            await userManager.ModifyUser(userModifyDto);
            return Ok("User roles modified is successfully");
        }
        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await userManager.GetAllUser();
            return Ok(result);
        }
    }
}
