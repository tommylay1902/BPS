using BudgetPerServing.DAO;
using BudgetPerServing.Data.Models;

namespace BudgetPerServing.Services;

public interface ILocationService
{
    Task CreateLocationAsync(Location location);
    Task<Location?> GetLocationByIdAsync(Guid id);
}

public class LocationService(ILocationDao locationDao) : ILocationService
{
    public async Task CreateLocationAsync(Location location)
    {
        await locationDao.CreateLocationAsync(location);
    }

    public async Task<Location?> GetLocationByIdAsync(Guid id)
    {
        return await locationDao.GetLocationByIdAsync(id);   
    }
}