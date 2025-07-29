using BudgetPerServing.Data;
using BudgetPerServing.Data.Dto.Location;
using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.Dao;

public class LocationDao (ApplicationDbContext context): ILocationDao
{
    public async Task<Guid> CreateLocationAsync(Location location)
    {
        await context.Locations.AddAsync(location);
        
        await context.SaveChangesAsync();
        return location.Id;
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

    public async Task UpdateLocationAsync(Location location)
    {
        context.Locations.Update(location);
        await context.SaveChangesAsync();
    }

    public Task DeleteLocationAsync(Location location)
    {
        context.Locations.Remove(location);
        return context.SaveChangesAsync();

    }

    public async Task<bool> CheckIfLocationExistsAsync(Guid id)
    {
        return await context.Locations.AnyAsync(l => l.Id == id);
    }
}

public interface ILocationDao
{
    Task<Guid> CreateLocationAsync(Location location);
    Task<Location?> GetLocationByIdAsync(Guid id);
    Task<IList<Location>?> GetAllLocationsAsync();
    Task UpdateLocationAsync(Location location);
    Task DeleteLocationAsync(Location location);
    Task<bool> CheckIfLocationExistsAsync(Guid id);
}