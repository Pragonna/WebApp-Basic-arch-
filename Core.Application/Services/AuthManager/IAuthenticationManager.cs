using Core.Security.Entities;
using Core.Security.JWT;

namespace Core.Application.Services.AuthManager
{
    public interface IAuthenticationManager
    {
        Task<AccessToken> CreateAccessToken(User user);
    }
}