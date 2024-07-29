using AutoMapper;
using Core.Business.BusinessRules;
using Core.Business.Dtos.UserDtos;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Core.Business.BusinessManager.UserBusinessManager
{
    public interface IUserManager
    {
        Task<Core.Security.JWT.AccessToken> Login(UserLoginDto userLoginDto);
        Task<UserRegisterOrListDto> Registration(UserRegisterOrListDto userRegisterDto);
        Task ModifyUser(UserModifyDto userModifyDto);
        Task<IEnumerable<UserListDto>> GetAllUser();
        Task<UserRegisterOrListDto> FindUserByEmail(string email);
        Task<UserRegisterOrListDto> DeleteUser(string email);
    }
}