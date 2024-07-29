using Core.Domain.Enums;
using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.Extensions.Configuration;

namespace Core.Persistence.DataSeeds
{
    public class DataSeed(IConfiguration configuration)
    {
        const string ADMIN = "Admin";
        const string SUPER_USER = "SuperUser";
        const string USER = "User";
        Admin? admin = configuration.GetSection(ADMIN).Get<Admin>();
        public static OperationClaim[] OperationClaims => new[]
            {
                new OperationClaim(id:1,name:ADMIN),
                new OperationClaim(id:2,name:SUPER_USER),
                new OperationClaim(id:3,name:USER)
        };

        public  User User => UserSeed();

        private  User UserSeed()
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.GeneratePasswordHash(admin.Password, out passwordHash, out passwordSalt);

            return new User(id: 1,
                            firstName: "admin-first-name",
                            lastName: "admin-last-name",
                            email: admin.Email,
                            passwordHash: passwordHash,
                            passwordSalt: passwordSalt,
                            dateOfBirth: DateTime.Now.Date,
                            address: "admin-address",
                            gender: Gender.Male,
                            country: "admin-country");
        }

        public static UserOperationClaim[] UserOperationClaims => new[]
        {
            new UserOperationClaim(id:1,userId:1,operationClaimId:1),
            new UserOperationClaim(id:2,userId:1,operationClaimId:2),
            new UserOperationClaim(id:3,userId:1,operationClaimId:3),
        };
    }
    internal class Admin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
