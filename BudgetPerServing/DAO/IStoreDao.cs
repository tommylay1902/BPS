using BudgetPerServing.Data;
using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BudgetPerServing.Dao;

public interface IStoreDao
{
    public Task<Guid> CreateStoreAsync(Store store);

    public Task<IList<Store>> GetAllStoresAsync();
    public Task<IList<Store>> GetAllStoresWithLocationEagerLoadAsync();

    public Task<Store?> GetStoreByIdAsync(Guid id);
    public Task UpdateStoreAsync(Store store);
    public Task DeleteStoreAsync(Store store);
    public Task<int> BatchDeleteStoreAsync(IEnumerable<Guid> ids);
    public Task<bool> StoreWithLocationIdExists(Guid locationId);
    
}

public class StoreDao(ApplicationDbContext context) : IStoreDao
{
    public async Task<Guid> CreateStoreAsync(Store store)
    {
        await context.AddAsync(store);
        /*await context.SaveChangesAsync();*/

        return store.Id;
    }
    
    public async Task<IList<Store>> GetAllStoresAsync()
    {
        // .Include() to include location object reference
       return await context.Stores.ToListAsync();
    }

    public async Task<IList<Store>> GetAllStoresWithLocationEagerLoadAsync()
    {
        return await context.Stores.Include(s => s.Location).ToListAsync();
    }


    public async Task<Store?> GetStoreByIdAsync(Guid id)
    {
        return await context.Stores.FindAsync(id);
    }

    public async Task UpdateStoreAsync(Store store)
    {
        context.Stores.Update(store);
        await context.SaveChangesAsync();
    }

    public async Task DeleteStoreAsync(Store store)
    {
        context.Stores.Remove(store);
        await context.SaveChangesAsync();
    }

    public async Task<int> BatchDeleteStoreAsync(IEnumerable<Guid> ids)
    {
        return await context.Stores
            .Where(s => ids.Contains(s.Id))
            .ExecuteDeleteAsync();
    }

    public async Task<bool> StoreWithLocationIdExists(Guid locationId)
    {
        return await context.Stores.AnyAsync(store => store.LocationId == locationId);
    }
}