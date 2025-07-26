using BudgetPerServing.Data;
using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.DAO;

public class LocationDao (ApplicationDbContext context): ILocationDao
{
    public async Task CreateLocationAsync(Location location)
    {
        await context.Locations.AddAsync(location);
        
        await context.SaveChangesAsync();
    }

    public async Task<Location?> GetLocationByIdAsync(Guid id)
    {
        var location = await context.Locations.FindAsync(id);
        return location;
    }

    public async Task<IList<Location>?> GetAllLocationsAsync()
    {
        return  await context.Locations.ToListAsync();
    }
}

public interface ILocationDao
{
    Task CreateLocationAsync(Location location);
    Task<Location?> GetLocationByIdAsync(Guid id);
    Task<IList<Location>?> GetAllLocationsAsync();
}