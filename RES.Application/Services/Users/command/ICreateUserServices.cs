using RES.Commom;

namespace RES.Application.Services.Users.command;

public interface ICreateUserServices
{
      Task<ResultDto<CreateUserResponseDto>> Execute(CreateUserRequestDto requestDto);
}