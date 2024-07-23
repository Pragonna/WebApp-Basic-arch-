using Core.Application.Repositories.OperationClaimRepositories;
using Core.Application.Repositories.UserOperationClaimRepositories;
using Core.Application.Repositories.UserRepositories;
using Core.Business.Dtos.UserDtos;
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
                throw new Exception(ExceptionMessages.EmailOrPasswordInCorrect);

            return user;
        }
        public async Task<User> UserEmailCanNotDuplicatedWhenSignUp(string email)
        {
            var user = await userRepository.FirstOrDefaultAsync(e => e.Email == email);

            if (user != null)
                throw new Exception(ExceptionMessages.EmailAlreadyRegistered);

            return user;
        }

        public async Task UserPasswordCheckWhenSignIn(User user, string password)
        {
            var success = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);

            if (!success)
                throw new Exception(ExceptionMessages.EmailOrPasswordInCorrect);

        }

        public async Task<IList<OperationClaim>> OperationClaimExistsInDb(string[] roles)
        {
            IList<OperationClaim> operationClaims = operationClaimRepository.GetList(
                o => roles.Any(role => role == o.Name)).ToList();
            if (!operationClaims.Any())
                throw new Exception("this roles does not exists");

            return operationClaims;
        }

        public async Task UserOperationClaimCanNotDuplicated(int userId, int operationClaimId)
        {
            IEnumerable<UserOperationClaim>? userOperationClaims = userOperationClaimRepository.GetList(x => x.UserId == userId && x.OperationClaimId == operationClaimId).ToList();

            if (userOperationClaims.Any())
                throw new Exception("this role already added this user");
        }

    }
}
