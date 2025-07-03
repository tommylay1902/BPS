using BudgetPerServing.Data;
using BudgetPerServing.Data.Clients;
using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.DAO;

/*public interface IFoodItemDao
{
    public Task<IEnumerable<FoodItem>> GetFoodItemsAsync();
    public Task<FoodItem?> GetFoodItemAsync(Guid id);
    public Task CreateFoodItemAsync(FoodItem foodItem);
}

public class FoodItemDao(ApplicationDbContext context) : IFoodItemDao
{
    public async Task<IEnumerable<FoodItem>> GetFoodItemsAsync()
    {
        return await context.FoodItems.ToListAsync();
    }

    public async Task<FoodItem?> GetFoodItemAsync(Guid id)
    {
        return await context.FoodItems.FindAsync(id);
    }

    public async Task CreateFoodItemAsync(FoodItem foodItem)
    {
        context.FoodItems.Add(foodItem);
        await context.SaveChangesAsync();
    }
}*/