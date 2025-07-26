

using BudgetPerServing.Dao;
using BudgetPerServing.Data.Dto;
using BudgetPerServing.Data.Models;

namespace BudgetPerServing.Services;

public interface IStoreService
{
    public Task CreateStoreAsync(CreateStoreRequest store);
    public Task<IList<Store>> GetAllStoresAsync();
    public Task<Store?> GetStoreByIdAsync(Guid id);
}

public class StoreService(IStoreDao storeDao, ILocationDao locationDao) : IStoreService
{
    public async Task CreateStoreAsync(CreateStoreRequest request)
    {
        var location = await locationDao.GetLocationByIdAsync(request.LocationId);
        if (location == null)
        {
            throw new KeyNotFoundException($"Location with ID {request.LocationId} not found");
        }

        var store = new Store
        {
            LocationId = request.LocationId,
            Name = request.Name

        };
        await storeDao.CreateStoreAsync(store);
    }

    public Task<IList<Store>> GetAllStoresAsync()
    {
        return storeDao.GetAllStoresAsync();
    }

    public async Task<Store?> GetStoreByIdAsync(Guid id)
    {
        return await storeDao.GetStoreByIdAsync(id);
    }
}