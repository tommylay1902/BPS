using BudgetPerServing.DAO;
using BudgetPerServing.Data;
using BudgetPerServing.Data.Clients;
using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.Services;

public interface IFoodItemService
{
    public Task<IEnumerable<FoodItem>> GetFoodItemsAsync();
    public Task<FoodItem?> GetFoodItemAsync(Guid id);
    public Task CreateFoodItemAsync(FoodItem foodItem);
}

public class FoodItemService() : IFoodItemService
{
    public Task<IEnumerable<FoodItem>> GetFoodItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FoodItem?> GetFoodItemAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CreateFoodItemAsync(FoodItem foodItem)
    {
        throw new NotImplementedException();
    }
}