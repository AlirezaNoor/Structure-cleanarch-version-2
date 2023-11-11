using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RES.Domain.Repository;
using RES.Infrastructure.context;

namespace RES.Infrastructure.Repositories;

public class Genericrepository<T>:IGenericrepository<T> where T :class
{
    private readonly ApplicationContext _phoenBookeDbContext;

    public Genericrepository(ApplicationContext phoenBookeDbContext)
    {
        _phoenBookeDbContext = phoenBookeDbContext;
    }

    public async Task<T> Get(int id)
    {
        return await _phoenBookeDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>>? wherevariable = null, string Join = "")
    {
        var all = _phoenBookeDbContext.Set<T>().AsQueryable();
        if (wherevariable != null)
        {
            all = all.Where(wherevariable);
        }

        if (Join != "")
        {
            foreach (var j in Join.Split(','))
            {
                all = all.Include(j);
            }
        }

        var result = await all.ToListAsync();
        return result;
    }

    public async Task<T> Create(T tentity)
    { 
        await _phoenBookeDbContext.Set<T>().AddAsync(tentity);
        await _phoenBookeDbContext.SaveChangesAsync();
        return tentity;
    }

    public async Task<bool> Exist(int Id)
    {
        var result=await Get(Id);
        return result != null;
    }

    public async Task Update(T tentity)
    {
        _phoenBookeDbContext.Entry(tentity).State = EntityState.Modified;
        _phoenBookeDbContext.SaveChangesAsync();
    }

    public async Task Delete(T tentity)
    {
        _phoenBookeDbContext.Set<T>().Remove(tentity);
        _phoenBookeDbContext.SaveChangesAsync();
    }
}