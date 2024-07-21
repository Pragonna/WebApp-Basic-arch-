using Core.Business.Dtos.UserDtos;
using Core.Security.JWT;

namespace Core.Business.BusinessManager.UserBusinessManager
{
    public interface IUserManager
    {
        Task<Core.Security.JWT.AccessToken> Login(UserLoginDto userLoginDto);
        Task<UserRegisterDto> Registration(UserRegisterDto userRegisterDto);
    }
}