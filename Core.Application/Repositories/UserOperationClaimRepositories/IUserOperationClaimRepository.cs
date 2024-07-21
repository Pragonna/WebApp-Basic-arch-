using Core.Security.Entities;


namespace Core.Application.Repositories.UserOperationClaimRepositories
{
    public interface IUserOperationClaimRepository:IWriteRepository<UserOperationClaim>,
                                                   IReadRepository<UserOperationClaim>
    {
    }
}
