using Microsoft.EntityFrameworkCore;
using RES.Domain.Entity.Users;

namespace RES.Infrastructure.context;

public interface IApplicationContext
{
    public DbSet<User> user { get; set; }
    
    
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());  
}