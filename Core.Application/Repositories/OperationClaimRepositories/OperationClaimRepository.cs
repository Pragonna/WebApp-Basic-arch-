using Core.Persistence.Context;
using Core.Security.Entities;

namespace Core.Application.Repositories.OperationClaimRepositories
{
    public class OperationClaimRepository:BaseRepository<OperationClaim,EFDbContext>,IOperationClaimRepository
    {
        public OperationClaimRepository(EFDbContext context):base(context)
        {
        }
    }
}
