using Microsoft.AspNetCore.Mvc;
using RES.Application.Services.Users.command;
using RES.WebHost.model;

namespace RES.WebHost.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ICreateUserServices _createUserServices;

    public UserController(ICreateUserServices createUserServices)
    {
        _createUserServices = createUserServices;
    }
[HttpPost]
    public async Task<IActionResult> Adduser(UserDto dto)
    {
        var result = await _createUserServices.Execute(new CreateUserRequestDto()
        {
            username = dto.username,
            Lastname = dto.Lastname,
            Firstname = dto.Firstname,
            password = dto.password
        });
        return Ok(result);
    }
}