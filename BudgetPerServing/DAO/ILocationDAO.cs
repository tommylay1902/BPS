using BudgetPerServing.Data;
using BudgetPerServing.Data.Models;

namespace BudgetPerServing.DAO;

public class LocationDao (ApplicationDbContext context): ILocationDao
{
    public async Task CreateLocationAsync(Location location)
    {
        await context.Locations.AddAsync(location);
        
        await context.SaveChangesAsync();
    }
}

public interface ILocationDao
{
    Task CreateLocationAsync(Location location);
}