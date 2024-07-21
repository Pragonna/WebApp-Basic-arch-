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

            modelBuilder.Entity<OperationClaim>().HasData(new[]
            {
                new OperationClaim(id:1,name:"Admin"),
                new OperationClaim(id:2,name:"SuperUser"),
                new OperationClaim(id:3,name:"User")

            });

            return modelBuilder;
        }
    }
}
