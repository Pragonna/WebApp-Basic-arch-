using Core.Persistence.Context;
using Core.Security.Entities;

namespace Core.Application.Repositories.UserRepositories
{
    public class UserRepository : BaseRepository<User, EFDbContext>, IUserRepository
    {
        public UserRepository(EFDbContext context) : base(context)
        {
        }
    }
}
