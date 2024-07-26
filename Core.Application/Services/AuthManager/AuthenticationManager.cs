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
            IEnumerable<int> operationClaimIds = userOperationClaimRepository.GetList(u => u.UserId == user.Id).Select(c => c.OperationClaimId).ToList();
            

            IList<OperationClaim> claims = new List<OperationClaim>();

            foreach (var oId in operationClaimIds)
            {
                OperationClaim? operationClaim = operationClaimRepository.GetById(oId);
                if(operationClaim != null)
                    claims.Add(operationClaim);
            }

            AccessToken accessToken = tokenHelper.CreateToken(user, claims);

            return accessToken;
        }

    }
}
