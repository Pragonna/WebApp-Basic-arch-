using AutoMapper;
using Core.Application.Repositories.OperationClaimRepositories;
using Core.Application.Repositories.UserOperationClaimRepositories;
using Core.Application.Repositories.UserRepositories;
using Core.Application.Services.AuthManager;
using Core.Business.BusinessRules;
using Core.Business.Dtos.UserDtos;
using Core.Business.Results;
using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.AspNetCore.Mvc;

namespace Core.Business.BusinessManager.UserBusinessManager
{
    public class UserManager(
        IUserRepository userRepository,
        IUserOperationClaimRepository userOperationClaimRepository,
        IOperationClaimRepository operationClaimRepository,
        UserBusinessRules userBusinessRules,
        IAuthenticationManager authenticationManager,
        IManager manager,
        IMapper mapper) : IUserManager
    {
        public async Task<IActionResult> Registration(UserRegisterDto userRegisterDto)
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

            return manager.Result(mappedUserDto);
        }
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            User user = await userBusinessRules.EmailExistsWhenSignIn(userLoginDto.Email);
            await userBusinessRules.UserPasswordCheckWhenSignIn(user, userLoginDto.Password);

            Core.Security.JWT.AccessToken accessToken = await authenticationManager.CreateAccessToken(user);

            return manager.Result(accessToken);

        }
        public async Task<IActionResult> ModifyUser(UserModifyDto userModifyDto)
        {
            User user = await userBusinessRules.EmailExistsWhenSignIn(userModifyDto.Email);

            IList<OperationClaim> operationClaims = await userBusinessRules.OperationClaimExistsInDb(userModifyDto.UserRoleDto.Roles);

            foreach (var operationClaim in operationClaims)
            {
                await userBusinessRules.UserOperationClaimCanNotDuplicated(user.Id, operationClaim.Id);
                await userOperationClaimRepository.AddAsync(new UserOperationClaim(user.Id, operationClaim.Id));
            }

            return await FindUserByEmail(userModifyDto.Email);
        }
        public async Task<IActionResult> FindUserByEmail(string email)
        {
            User user = await userBusinessRules.EmailExistsWhenSignIn(email);
            UserListDto mappedDto = mapper.Map<UserListDto>(user);

           var listUserOperationClaims= userOperationClaimRepository.GetList(x => x.UserId == user.Id).ToList();
           var operationClaims= operationClaimRepository.GetList().ToList();

            foreach (var operationClaim in operationClaims)
            {
                listUserOperationClaims
                    .ForEach(x =>
                    {
                        if (x.OperationClaimId == operationClaim.Id)
                            mappedDto.Roles.Add(operationClaim.Name);
                    });
            }
            return manager.Result(mappedDto);
        }
        public async Task<IActionResult> DeleteUser(string email)
        {
            User user = await userBusinessRules.EmailExistsWhenSignIn(email);
            User deletedUser = await userRepository.DeleteAsync(user);

            var userOperationClaims = userOperationClaimRepository.GetList(predicate: x => x.UserId == deletedUser.Id)
                                                                    .ToList();

            userOperationClaims.ForEach(async x => await userOperationClaimRepository.DeleteAsync(x));
            var result= mapper.Map<UserRegisterDto>(user);
            return manager.Result(result);
        }
        public async Task<IActionResult> GetAllUser()
        {
            //                  - High resource -  
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

            return manager.Result(mappedList);
        }
    }
}
