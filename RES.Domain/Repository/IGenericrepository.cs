using System.Linq.Expressions;

namespace RES.Domain.Repository;

public interface IGenericrepository<T> where T :class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>>? wherevariable = null, string Join = "");
    Task<T> Create(T tentity);
    Task<bool> Exist(int Id);
    Task Update(T tentity);
    Task Delete(T tentity);
}