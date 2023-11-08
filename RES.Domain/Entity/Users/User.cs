using System.Reflection.Metadata.Ecma335;
using RES.Domain.Entity.Base;

namespace RES.Domain.Entity.Users;

public class User:BaseEntity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string  username { get; set; }
    public string  password { get; set; }
}