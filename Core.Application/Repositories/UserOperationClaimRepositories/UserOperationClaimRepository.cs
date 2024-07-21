using Core.Persistence.Context;
using Core.Security.Entities;

namespace Core.Application.Repositories.UserOperationClaimRepositories
{
    public class UserOperationClaimRepository:BaseRepository<UserOperationClaim,EFDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(EFDbContext context):base(context)
        {
        }
    }
}
