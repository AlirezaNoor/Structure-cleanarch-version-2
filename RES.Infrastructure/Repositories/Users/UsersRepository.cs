using RES.Domain.Entity.Users;
using RES.Domain.Repository;
using RES.Domain.Repository.users;
using RES.Infrastructure.context;

namespace RES.Infrastructure.Repositories.Users;

public class UsersRepository:Genericrepository<User>,IUsersRepository
{
    public UsersRepository(ApplicationContext phoenBookeDbContext) : base(phoenBookeDbContext)
    {
    }
}