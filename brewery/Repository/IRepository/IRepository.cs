using System.Linq.Expressions;
using brewery.Models;

namespace brewery.Repository.IRepository; 

public interface IRepository<T> where T : class{
    Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
    Task<T> Get(Expression<Func<T, bool>>? filter = null);
    Task Create(T obj);

    Task Update(T obj);
    Task Remove(T obj);
    Task Save();
}