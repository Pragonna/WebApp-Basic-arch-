using Core.Application.Repositories.OperationClaimRepositories;
using Core.Application.Repositories.UserOperationClaimRepositories;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Core.Application.Services.AuthManager
{
    public class AuthenticationManager(IUserOperationClaimRepository userOperationClaimRepository,
                                       IOperationClaimRepository operationClaimRepository,
                                       ITokenHelper tokenHelper) : IAuthenticationManager
    {
        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var operationClaimIds = userOperationClaimRepository.GetList(u => u.UserId == user.Id).Select(c => c.OperationClaimId).ToList();
            IList<OperationClaim>operationClaims=new List<OperationClaim>();
            foreach (var oId in operationClaimIds)
            {
               var operationClaim=await operationClaimRepository.GetByIdAsync(oId);
                operationClaims.Add(operationClaim);
            }
           

            AccessToken accessToken = tokenHelper.CreateToken(user, operationClaims);

            return accessToken;
        }

    }
}
