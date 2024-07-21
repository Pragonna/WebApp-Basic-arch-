using Core.Security.Entities;

namespace Core.Application.Repositories.OperationClaimRepositories
{
    public interface IOperationClaimRepository : IWriteRepository<OperationClaim>, 
                                                 IReadRepository<OperationClaim>
    {
    }
}
