using AutoMapper;
using RES.Application.Services.Users.command;
using RES.Domain.Entity.Users;

namespace RES.Application.profiler;

public class Mapperprofiler:Profile
{
    public Mapperprofiler()
    {
        CreateMap<User, CreateUserRequestDto>().ReverseMap();
     }
}