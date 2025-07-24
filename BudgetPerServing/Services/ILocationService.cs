using BudgetPerServing.DAO;
using BudgetPerServing.Data.Models;

namespace BudgetPerServing.Services;

public interface ILocationService
{
    Task CreateLocationAsync(Location location);
}

public class LocationService(ILocationDao locationDao) : ILocationService
{
    public async Task CreateLocationAsync(Location location)
    {
        await locationDao.CreateLocationAsync(location);
    }
}