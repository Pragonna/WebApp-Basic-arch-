using Core.Persistence.DataSeeds;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Extensions
{
    public static class AuthenticationModelBuilderExtensions
    {
        public static ModelBuilder AuthenticationModelBuilding(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(c => c.Id);
            });

            modelBuilder.Entity<OperationClaim>(o =>
            {
                o.HasKey(c => c.Id);
            });
            modelBuilder.Entity<UserOperationClaim>(uo =>
            {
                uo.HasKey(c => c.Id);

            });

            modelBuilder.Entity<OperationClaim>().HasData(DataSeed.OperationClaims);
            modelBuilder.Entity<User>().HasData(DataSeed.User);
            modelBuilder.Entity<UserOperationClaim>().HasData(DataSeed.UserOperationClaims);

            return modelBuilder;
        }
    }
}
