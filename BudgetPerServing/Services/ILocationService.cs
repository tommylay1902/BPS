using BudgetPerServing.Dao;
using BudgetPerServing.Data.Dto.Location;
using BudgetPerServing.Data.Models;
using BudgetPerServing.Exceptions;


namespace BudgetPerServing.Services;

public interface ILocationService
{
    Task<Guid> CreateLocationAsync(LocationCreateRequest location);
    Task<Location?> GetLocationByIdAsync(Guid id);
    public Task<IList<Location>?> GetAllLocationsAsync();
    public Task UpdateLocationAsync(Guid id, LocationUpdateRequest updateRequest);
    public Task DeleteLocationAsync(Guid id);
}

public class LocationService(ILocationDao locationDao) : ILocationService
{
    public async Task<Guid> CreateLocationAsync(LocationCreateRequest request)
    {
        var location = new Location
        {
            City = request.City,
            State = request.State,
            Country = request.Country,
            Street = request.Street,
            Suite = request.Suite,
            ZipCode = request.ZipCode,
        };
         return await locationDao.CreateLocationAsync(location);
    }

    public async Task<Location?> GetLocationByIdAsync(Guid id)
    {
        return await locationDao.GetLocationByIdAsync(id);   
    }

    public async Task<IList<Location>?> GetAllLocationsAsync()
    {
        return await locationDao.GetAllLocationsAsync();
    }

    public async Task UpdateLocationAsync(Guid id, LocationUpdateRequest updateRequest)
    {
        var locationToUpdate = await GetLocationByIdAsync(id);
        if (locationToUpdate == null)
            throw new KeyNotFoundException($"Location with Id {id} not found");

        var hasUpdates = false;
        if (updateRequest.Country != null && updateRequest.Country != locationToUpdate.Country)
        {
            locationToUpdate.Country = updateRequest.Country;
            hasUpdates = true;
        }


        if (updateRequest.City != null && updateRequest.City != locationToUpdate.City)
        {
            locationToUpdate.City = updateRequest.City;
            hasUpdates = true;
        }


        if (updateRequest.State != null && updateRequest.State != locationToUpdate.State)
        {
            locationToUpdate.State = updateRequest.State;
            hasUpdates = true;
        }


        if (updateRequest.Zipcode != null && updateRequest.Zipcode != locationToUpdate.ZipCode)
        {
            locationToUpdate.ZipCode = updateRequest.Zipcode;
            hasUpdates = true;
        }


        if (updateRequest.Street != null && updateRequest.Street != locationToUpdate.Street)
        {
            locationToUpdate.Street = updateRequest.Street;
            hasUpdates = true;
        }

        if (updateRequest.Suite != null && updateRequest.Suite != locationToUpdate.Suite)
        {
            locationToUpdate.Suite = updateRequest.Suite;
            hasUpdates = true;
        }

        if (!hasUpdates)
            throw new NoUpdateException("No updates found on the location object")
                { ResourceType = nameof(Location), ResourceId = locationToUpdate.Id };
    
        
        await locationDao.UpdateLocationAsync(locationToUpdate);
    }

    public async Task DeleteLocationAsync(Guid id)
    {
        var location = await GetLocationByIdAsync(id);
        if(location == null) throw new KeyNotFoundException($"Location with Id {id} not found");
        
        await locationDao.DeleteLocationAsync(location);
    }
}