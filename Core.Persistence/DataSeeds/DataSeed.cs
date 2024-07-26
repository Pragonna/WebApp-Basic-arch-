
using Core.Domain.Enums;
using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Metrics;
using System.Net;

namespace Core.Persistence.DataSeeds
{
    public class DataSeed
    {


        public static OperationClaim[] OperationClaims =>
            [
                new OperationClaim(id:1,name:"Admin"),
                new OperationClaim(id:2,name:"SuperUser"),
                new OperationClaim(id:3,name:"User")
            ];

        public static User User => UserSeedCreate();
        public static UserOperationClaim[] UserOperationClaims => 
            [
                new UserOperationClaim(id:1,userId:User.Id,operationClaimId:OperationClaims[0].Id),
                new UserOperationClaim(id:2,userId:User.Id,operationClaimId:OperationClaims[1].Id),
                new UserOperationClaim(id:3,userId:User.Id,operationClaimId:OperationClaims[2].Id)
            ];
        private static User UserSeedCreate()
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.GeneratePasswordHash("admin123", out passwordHash, out passwordSalt);

            return new User(id: 1,
                      firstName: "admin-first-name",
                      lastName: "admin-last-name",
                      email: "admin@admin.com",
                      passwordHash: passwordHash,
                      passwordSalt: passwordSalt,
                      dateOfBirth: DateTime.Now,
                      address: "admin-address",
                      gender: Domain.Enums.Gender.Male,
                      country: "admin-country"
                      );
        }




    }
}
