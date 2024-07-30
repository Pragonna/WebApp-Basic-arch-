using Core.Business.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
namespace Core.Business.BusinessManager.UserBusinessManager
{
    public interface IUserManager
    {
        Task<IActionResult> Login(UserLoginDto userLoginDto);
        Task<IActionResult> Registration(UserRegisterDto userRegisterDto);
        Task <IActionResult>ModifyUser(UserModifyDto userModifyDto);
        Task<IActionResult> GetAllUser();
        Task<IActionResult> FindUserByEmail(string email);
        Task<IActionResult> DeleteUser(string email);
    }
}