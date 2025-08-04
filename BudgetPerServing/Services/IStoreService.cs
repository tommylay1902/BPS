

using System.Transactions;
using BudgetPerServing.Dao;
using BudgetPerServing.Data;
using BudgetPerServing.Data.Dto;
using BudgetPerServing.Data.Models;
using BudgetPerServing.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.Services;

public interface IStoreService
{
    public Task<Guid> CreateStoreAsync(CreateStoreRequest store);
    public Task<(Guid storeId, Guid locationId)> CreateStoreWithLocation(CreateStoreWithLocationRequest request);
    public Task<IList<Store>> GetAllStoresAsync();
    public Task<IList<Store>> GetAllStoresWithLocationEagerLoadAsync();
    public Task<Store?> GetStoreByIdAsync(Guid id);
    public Task UpdateStoreAsync(Guid id, StoreUpdateRequest request);
    public Task DeleteStoreAsync(Guid id);
    public Task BatchDeleteStoreAsync(IList<Guid> ids);
    
}

public class StoreService(IStoreDao storeDao, ILocationDao locationDao, IUnitOfWork unitOfWork) : IStoreService
{
    public async Task<Guid> CreateStoreAsync(CreateStoreRequest request)
    {
        var location = await locationDao.GetLocationByIdAsync(request.LocationId);
        if (location == null)
        {
            throw new KeyNotFoundException($"Location with ID {request.LocationId} not found");
        }

        if (await storeDao.StoreWithLocationIdExists(request.LocationId))
        {
            throw new ResourceConflictException($"Location with ID {request.LocationId} already exists" ){
                ResourceType = nameof(Store),
                ResourceId = location.Id,
            };
        }

        var store = new Store
        {
            LocationId = request.LocationId,
            Name = request.Name
        };
        return await storeDao.CreateStoreAsync(store);
    }

    public async Task<(Guid storeId, Guid locationId)> CreateStoreWithLocation(CreateStoreWithLocationRequest request)
    {
        using var transaction = unitOfWork.BeginTransaction();
        try
        {
            var location = new Location
            {
                Country = request.Location.Country,
                City = request.Location.City,
                State = request.Location.State,
                Street = request.Location.Street,
                Suite = request.Location.Suite,
                ZipCode = request.Location.ZipCode
            };
            
            var locationId = await locationDao.CreateLocationAsync(location);

            var store = new Store
            {
                Name = request.Name,
                LocationId = locationId
            };
                
            var storeId = await  storeDao.CreateStoreAsync(store);

            await unitOfWork.SaveChangesAsync();

            transaction.Commit();

            return (storeId, locationId);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
    }
    

    public Task<IList<Store>> GetAllStoresAsync()
    {
        return storeDao.GetAllStoresAsync();
    }

    public Task<IList<Store>> GetAllStoresWithLocationEagerLoadAsync()
    {
        return storeDao.GetAllStoresWithLocationEagerLoadAsync();
    }

    public async Task<Store?> GetStoreByIdAsync(Guid id)
    {
        return await storeDao.GetStoreByIdAsync(id);
    }

    public async Task UpdateStoreAsync(Guid id, StoreUpdateRequest request)
    {
        var store = await storeDao.GetStoreByIdAsync(id);
        
        if(store == null) throw new KeyNotFoundException($"Store with ID {id} not found");
        
        var hasUpdates = false;
        
        if ( request.LocationId.HasValue && await storeDao.StoreWithLocationIdExists(request.LocationId.Value))
        {
            throw new ResourceConflictException($"Location with ID {request.LocationId} already exists"){ResourceType = nameof(Store), ResourceId = store.LocationId};
        }

        if (request.Name != null && request.Name != store.Name && request.Name.Trim() != "")
        {
            store.Name = request.Name;
            hasUpdates = true;

        }

        if (request.LocationId.HasValue)
        {
            store.LocationId = request.LocationId.Value;
            hasUpdates = true;
        }
           
        
        if (!hasUpdates)
            throw new NoUpdateException("No update found on store request object")
                { ResourceType = nameof(Store), ResourceId = store.Id };
    
        
        await storeDao.UpdateStoreAsync(store);
    }

    public async Task DeleteStoreAsync(Guid id)
    {
        var store = await storeDao.GetStoreByIdAsync(id);
        
        if(store == null) throw new KeyNotFoundException($"Store with ID {id} not found");
        
        await storeDao.DeleteStoreAsync(store);
    }

    public async Task BatchDeleteStoreAsync(IList<Guid> ids)
    {
        using var transaction = unitOfWork.BeginTransaction();
        try
        {
            var rowsModified = await storeDao.BatchDeleteStoreAsync(ids);
            if (rowsModified == 0) throw new KeyNotFoundException("None of the provided Ids exist in the database");
            if (rowsModified != ids.Count)
            {
                throw new BadHttpRequestException("Not all items were deleted");
            }
            await unitOfWork.SaveChangesAsync();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
    }
}