using RES.Commom;
using RES.Domain.Entity.Users;
using RES.Infrastructure.context;

namespace RES.Application.Services.Users.command;

public class CreateUserServices:ICreateUserServices
{
    private readonly IApplicationContext _applicationContext;

    public CreateUserServices(IApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public ResultDto<CreateUserResponseDto> Execute(CreateUserRequestDto requestDto)
    {
        var user = _applicationContext.user.AsQueryable();

        try
        {
            user = user.Where(x => x.username == requestDto.username);
            if (user.Count() > 0)
            {
                return new ResultDto<CreateUserResponseDto>()
                {
                    Issuccess = false,
                    Massegas = "این کاربر از قببل موجود است"
                };
            }

            var createduser = new User()
            {
                username = requestDto.username,
                Firstname = requestDto.Firstname,
                password = requestDto.password,
                Lastname = requestDto.Lastname,
            };
         _applicationContext.user.Add(createduser);
            _applicationContext.SaveChanges();
            return new ResultDto<CreateUserResponseDto>()
            {
                Issuccess = true,
                Massegas = "ذخیره سازی با موفقیت انجام گردید",
                Data = new CreateUserResponseDto()
                {
                    Id = createduser.id
                }
                
            };
        }
        catch (Exception e)
        {
            return new ResultDto<CreateUserResponseDto>()
            {
                Issuccess = false,
                Massegas = "این کاربر از قببل موجود است"
            };
        }
    }
}