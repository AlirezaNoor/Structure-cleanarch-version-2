using RES.Commom;

namespace RES.Application.Services.Users.command;

public interface ICreateUserServices
{
    ResultDto<CreateUserResponseDto> Execute(CreateUserRequestDto requestDto);
}