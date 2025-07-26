using BudgetPerServing.Dao;
using BudgetPerServing.Data.Models;


namespace BudgetPerServing.Services;

public interface IFoodItemService
{
    /*public Task<IEnumerable<FoodItem>> GetFoodItemsAsync();
    public Task<FoodItem?> GetFoodItemAsync(Guid id);*/
    public Task CreateFoodItemAsync(FoodItem foodItem);
}

public class FoodItemService(IFoodItemDao foodItemDao) : IFoodItemService
{
    /*public async Task<IEnumerable<FoodItem>> GetFoodItemsAsync()
    {
        return await foodItemDao.GetFoodItemsAsync();
    }

    public async Task<FoodItem?> GetFoodItemAsync(Guid id)
    {
        var foodItem = await foodItemDao.GetFoodItemAsync(id);
        
        return foodItem;
    }*/

    public async Task CreateFoodItemAsync(FoodItem foodItem)
    {
        await foodItemDao.CreateFoodItemAsync(foodItem);
    }
}