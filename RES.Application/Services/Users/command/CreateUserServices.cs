using AutoMapper;
using RES.Commom;
using RES.Domain.Entity.Users;
using RES.Domain.Repository.users;
using RES.Infrastructure.context;

namespace RES.Application.Services.Users.command;

public class CreateUserServices:ICreateUserServices
{
    private readonly IUsersRepository _applicationContext;
    private readonly IMapper _mapper;
    public CreateUserServices(IUsersRepository applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public async Task<ResultDto<CreateUserResponseDto>> Execute(CreateUserRequestDto requestDto)
    {
        var getall = await _applicationContext.GetAll();
        var checking = getall.Where(x => x.username == requestDto.username);
        try
        {
            if (checking.Count()>0)
            {
                return new ResultDto<CreateUserResponseDto>()
                {
                    Issuccess = false,
                    Massegas = "کاربری با این نام کاربری موجود است",

                };
              
            }
            var user = _mapper.Map<User>(requestDto);
            var res = await _applicationContext.Create(user);
            return new ResultDto<CreateUserResponseDto>()
            {
                Issuccess = true,
                Massegas = "عملیات با موفقیت انجام شد",
                Data = new CreateUserResponseDto()
                {
                    Id = res.id
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ResultDto<CreateUserResponseDto>()
            {
                Issuccess = false,
                Massegas = "حادثه ایی رخ داده است",

            };

        }
    }
}