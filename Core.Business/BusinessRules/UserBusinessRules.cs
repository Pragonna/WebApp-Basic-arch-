using Core.Application.CrossCuttingConcerns.Exceptions;
using Core.Application.Repositories.OperationClaimRepositories;
using Core.Application.Repositories.UserOperationClaimRepositories;
using Core.Application.Repositories.UserRepositories;
using Core.Business.Messages.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Core.Business.BusinessRules
{
    public class UserBusinessRules(IUserRepository userRepository,
                                   IOperationClaimRepository operationClaimRepository,
                                   IUserOperationClaimRepository userOperationClaimRepository)
    {
        public async Task<User> EmailExistsWhenSignIn(string email)
        {
            var user = await userRepository.FirstOrDefaultAsync(e => e.Email == email);

            if (user == null)
                throw new BusinessException(ExceptionMessages.EmailOrPasswordInCorrect);

            return user;
        }
        public async Task<User> UserEmailCanNotDuplicatedWhenSignUp(string email)
        {
            var user = await userRepository.FirstOrDefaultAsync(e => e.Email == email);

            if (user != null)
                throw new BusinessException(ExceptionMessages.EmailAlreadyRegistered);

            return user;
        }

        public async Task UserPasswordCheckWhenSignIn(User user, string password)
        {
            var success = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);

            if (!success)
                throw new AuthorizationException(ExceptionMessages.EmailOrPasswordInCorrect);

        }

        public async Task<IList<OperationClaim>> OperationClaimExistsInDb(string[] roles)
        {
            IList<OperationClaim> operationClaims = operationClaimRepository.GetList(
                o => roles.Any(role => role == o.Name)).ToList();
            if (!operationClaims.Any())
                throw new AuthorizationException(ExceptionMessages.ClaimRoleNotFound);

            return operationClaims;
        }

        public async Task UserOperationClaimCanNotDuplicated(int userId, int operationClaimId)
        {
            IEnumerable<UserOperationClaim>? userOperationClaims = userOperationClaimRepository.GetList(x => x.UserId == userId && x.OperationClaimId == operationClaimId).ToList();

            if (userOperationClaims.Any())
                throw new BusinessException(ExceptionMessages.RoleAlreadyAdded);
        }

    }
}
