namespace RES.Application.Services.Users.command;

public class CreateUserRequestDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string  username { get; set; }
    public string  password { get; set; }
}