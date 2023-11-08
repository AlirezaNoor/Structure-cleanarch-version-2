using RES.Commom;
using RES.Infrastructure.context;

namespace RES.Application.Services.Users.Dto;

public class GetUserServeces:IGetUserServeces
{
    private readonly IApplicationContext _applicationContext;

    public GetUserServeces(IApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public ResultDto<ResponseGetUser> Execute(RequestGetUser requestGetUser)
    {
        try
        {
            var user = _applicationContext.user.AsQueryable();
            if (requestGetUser.Id != 0)
            {
                user = user.Where(u => u.id == requestGetUser.Id);
            }

            var userindto = user.Select(x => new UsersDto()
            {
                username = x.username,
                Lastname = x.Lastname,
                Firstname = x.Firstname,
                password = x.password
            }).ToList();
            return new ResultDto<ResponseGetUser>()
            {
                Data = new ResponseGetUser()
                {
                    userdto = userindto,
                },
                Issuccess = true,
                Massegas = "دریافت شد "
                
            };
        }
        catch (Exception e)
        {
            return new ResultDto<ResponseGetUser>()
            {
                Data = new ResponseGetUser()
                {
                    userdto = null,
                },
                Issuccess = true,
                Massegas = "دریافت شد "
                
            };
        }
        }
    }
