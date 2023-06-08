
using brewery.Data;
using brewery.Models;
using brewery.Repository.IRepository;

namespace brewery.Repository; 

public class BeerRepository : Repository<Beer>, IBeerRepository {
    public BeerRepository(ApplicationDbContext dbContext) : base(dbContext) {
    }
}