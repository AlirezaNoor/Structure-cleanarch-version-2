using Microsoft.Extensions.DependencyInjection;
using RES.Domain.Repository;
using RES.Domain.Repository.users;
using RES.Infrastructure.Repositories;
using RES.Infrastructure.Repositories.Users;

namespace RES.Infrastructure;

public static class InfraDiContainer
{
    public static IServiceCollection mycontainer(this IServiceCollection service)
    {
        service.AddScoped (typeof(IGenericrepository<>),typeof(Genericrepository<>));
        service.AddScoped<IUsersRepository, UsersRepository>();
        return service;
    }
}