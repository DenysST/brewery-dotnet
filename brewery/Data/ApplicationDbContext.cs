using brewery.Models;
using Microsoft.EntityFrameworkCore;

namespace brewery.Data; 

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }
    
    public DbSet<Beer> Beers { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
}