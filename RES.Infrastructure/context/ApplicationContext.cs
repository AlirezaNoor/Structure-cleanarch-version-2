using Microsoft.EntityFrameworkCore;
using RES.Domain.Entity.Users;

namespace RES.Infrastructure.context;

public class ApplicationContext:DbContext,IApplicationContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<User> user { get; set; }
}