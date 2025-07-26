using BudgetPerServing.Data;
using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BudgetPerServing.Dao;

public interface IStoreDao
{
    public Task CreateStoreAsync(Store store);
    public Task<IList<Store>> GetAllStoresAsync();
    public Task<Store?> GetStoreByIdAsync(Guid id);
}

public class StoreDao(ApplicationDbContext context) : IStoreDao
{
    public async Task CreateStoreAsync(Store store)
    {
        await context.AddAsync(store);
        
        await context.SaveChangesAsync();
    }

    public async Task<IList<Store>> GetAllStoresAsync()
    {
        // .Include() to include location object reference
       return await context.Stores.ToListAsync();
    }

    public async Task<Store?> GetStoreByIdAsync(Guid id)
    {
        return await context.Stores.FindAsync(id);
    }
}