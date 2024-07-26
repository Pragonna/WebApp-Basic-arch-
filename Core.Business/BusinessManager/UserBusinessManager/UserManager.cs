using AutoMapper;
using Azure.Core;
using Core.Application.Repositories.OperationClaimRepositories;
using Core.Application.Repositories.UserOperationClaimRepositories;
using Core.Application.Repositories.UserRepositories;
using Core.Application.Services.AuthManager;
using Core.Business.BusinessRules;
using Core.Business.Dtos.UserDtos;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Core.Business.BusinessManager.UserBusinessManager
{
    public class UserManager(
        IUserRepository userRepository,
        IUserOperationClaimRepository userOperationClaimRepository,
        IOperationClaimRepository operationClaimRepository,
        UserBusinessRules userBusinessRules,
        IAuthenticationManager authenticationManager,
        IMapper mapper) : IUserManager
    {
        public async Task<UserRegisterDto> Registration(UserRegisterDto userRegisterDto)
        {
            await userBusinessRules.UserEmailCanNotDuplicatedWhenSignUp(userRegisterDto.Email);

            User mappedUser = mapper.Map<User>(userRegisterDto);

            byte[] passwordHash, passwordSalt;
            HashingHelper.GeneratePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;

            User createdUser = await userRepository.AddAsync(mappedUser);

            // UserOperationClaim is creating when new User insert in Database like a simple USER role (operationClaim)
            await userOperationClaimRepository.AddAsync(new UserOperationClaim(createdUser.Id, 3));
            UserRegisterDto mappedUserDto = mapper.Map<UserRegisterDto>(createdUser);

            return mappedUserDto;
        }
        public async Task<Core.Security.JWT.AccessToken> Login(UserLoginDto userLoginDto)
        {
            User user = await userBusinessRules.EmailExistsWhenSignIn(userLoginDto.Email);
            await userBusinessRules.UserPasswordCheckWhenSignIn(user, userLoginDto.Password);

            user.Status = true;
            Core.Security.JWT.AccessToken accessToken = await authenticationManager.CreateAccessToken(user);

            return accessToken;

        }
        public async Task ModifyUser(UserModifyDto userModifyDto)
        {
            User user = await userBusinessRules.EmailExistsWhenSignIn(userModifyDto.Email);

            IList<OperationClaim> operationClaims = await userBusinessRules.OperationClaimExistsInDb(userModifyDto.UserRoleDto.Roles);

            foreach (var operationClaim in operationClaims)
            {
                await userBusinessRules.UserOperationClaimCanNotDuplicated(user.Id, operationClaim.Id);
                await userOperationClaimRepository.AddAsync(new UserOperationClaim(user.Id, operationClaim.Id));
            }
        }

        public async Task<IEnumerable<UserListDto>> GetAllUser()
        {
            IEnumerable<User> users = userRepository.GetList();
            IEnumerable<UserListDto> mappedList = mapper.Map<IEnumerable<UserListDto>>(users);
            var userOperationClaims = userOperationClaimRepository.GetList().ToList();


            foreach (var user in mappedList)
            {
                foreach (var userOperationClaim in userOperationClaims)
                {
                    if (userOperationClaim.UserId == user.Id)
                    {
                        var operationClaim = await operationClaimRepository.FirstOrDefaultAsync(x => x.Id == userOperationClaim.OperationClaimId);

                        user.Roles.Add(operationClaim.Name);
                    }
                }
            }

            return mappedList;
        }
    }
}
