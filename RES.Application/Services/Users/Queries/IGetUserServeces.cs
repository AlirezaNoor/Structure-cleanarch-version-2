using RES.Commom;

namespace RES.Application.Services.Users.Dto;

public interface IGetUserServeces
{
    ResultDto<ResponseGetUser> Execute(RequestGetUser requestGetUser);
}