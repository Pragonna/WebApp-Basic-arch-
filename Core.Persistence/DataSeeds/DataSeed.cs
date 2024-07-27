using Core.Domain.Enums;
using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.DataSeeds
{
    public class DataSeed
    {
        public static OperationClaim[] OperationClaims => new[]
            {
                new OperationClaim(id:1,name:"Admin"),
                new OperationClaim(id:2,name:"SuperUser"),
                new OperationClaim(id:3,name:"User")
        };

        public static User User => UserSeed();

        private static User UserSeed()
        {
            const string PASSWORD = "admin123";
            byte[] passwordHash, passwordSalt;
            HashingHelper.GeneratePasswordHash(PASSWORD, out passwordHash, out passwordSalt);

            return new User(id: 1,
                            firstName: "admin-first-name",
                            lastName: "admin-last-name",
                            email: "admin@admin.com",
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
}
