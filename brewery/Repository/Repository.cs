using System.Linq.Expressions;
using brewery.Data;
using brewery.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace brewery.Repository; 

public class Repository<T> : IRepository<T> where T : class{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
        this._dbSet = dbContext.Set<T>();
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null) {
        IQueryable<T> query = _dbSet;
        if (filter != null) {
            query = query.Where(filter);
        }
        return await query.ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>>? filter = null) {
        IQueryable<T> query = _dbSet;
        if (filter != null) {
            query = query.Where(filter);
        }
        return await query.FirstOrDefaultAsync();
    }

    public async Task Create(T beer) {
        await _dbSet.AddAsync(beer);
        await Save();
    }

    public async Task Update(T beer) {
        _dbSet.Update(beer);
        await Save();
    }

    public async Task Remove(T beer) {
        _dbSet.Remove(beer);
        await Save();
    }

    public async Task Save() {
        await _dbContext.SaveChangesAsync();
    }
}