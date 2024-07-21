using Core.Application.Repositories.UserRepositories;
using Core.Business.Dtos.UserDtos;
using Core.Business.Messages.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.BusinessRules
{
    public class UserBusinessRules(IUserRepository userRepository)
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
            var user=await userRepository.FirstOrDefaultAsync(e => e.Email == email);

            if (user != null)
                throw new Exception(ExceptionMessages.EmailAlreadyRegistered);

            return user;
        }

        public async Task UserPasswordCheckWhenSignIn(User user,string password)
        {
           var success= HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);

            if (!success)
                throw new Exception(ExceptionMessages.EmailOrPasswordInCorrect);

        }
        
    }
}
