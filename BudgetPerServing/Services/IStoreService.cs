

using BudgetPerServing.Dao;
using BudgetPerServing.Data.Dto;
using BudgetPerServing.Data.Models;
using BudgetPerServing.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.Services;

public interface IStoreService
{
    public Task<Guid> CreateStoreAsync(CreateStoreRequest store);
    public Task<IList<Store>> GetAllStoresAsync();
    public Task<Store?> GetStoreByIdAsync(Guid id);
    public Task UpdateStoreAsync(Guid id, StoreUpdateRequest request);
}

public class StoreService(IStoreDao storeDao, ILocationDao locationDao) : IStoreService
{
    public async Task<Guid> CreateStoreAsync(CreateStoreRequest request)
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
        return await storeDao.CreateStoreAsync(store);
    }

    public Task<IList<Store>> GetAllStoresAsync()
    {
        return storeDao.GetAllStoresAsync();
    }

    public async Task<Store?> GetStoreByIdAsync(Guid id)
    {
        return await storeDao.GetStoreByIdAsync(id);
    }

    public async Task UpdateStoreAsync(Guid id, StoreUpdateRequest request)
    {
        var store = await storeDao.GetStoreByIdAsync(id);
        
        if(store == null) throw new KeyNotFoundException($"Store with ID {id} not found");
        
        if (store.Name.Equals(request.Name))
        {
            throw new NoUpdateException($"There was no valid update found on the request")
            {
                ResourceType = nameof(Store),
                ResourceId = store.Id,
            };
        }
        
        store.Name = request.Name;
        
        await storeDao.UpdateStoreAsync(store);
    }
}