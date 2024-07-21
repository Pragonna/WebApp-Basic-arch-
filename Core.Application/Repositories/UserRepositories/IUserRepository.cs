using Core.Security.Entities;

namespace Core.Application.Repositories.UserRepositories
{
    public interface IUserRepository : IWriteRepository<User>, 
                                       IReadRepository<User>
    {
    }
}
