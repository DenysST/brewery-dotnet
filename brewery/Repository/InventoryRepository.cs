using brewery.Data;
using brewery.Models;
using brewery.Repository.IRepository;

namespace brewery.Repository; 

public class InventoryRepository : Repository<Inventory>, IInventoryRepository {
    public InventoryRepository(ApplicationDbContext dbContext) : base(dbContext) {
    }
}