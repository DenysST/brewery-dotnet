using System.Linq.Expressions;
using brewery.Models;

namespace brewery.Repository.IRepository; 

public interface IBeerRepository : IRepository<Beer> {
}