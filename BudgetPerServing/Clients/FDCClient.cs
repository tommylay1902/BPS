using BudgetPerServing.Data.Clients;

namespace BudgetPerServing.Clients;

public class FdcClient(IConfiguration configuration, HttpClient httpClient) : IFdcClient
{
    private readonly string _fdcApiKey = configuration.GetValue<string>("FoodApi:FoodApiKey") ?? throw new InvalidOperationException("Missing required configuration: 'FoodApi:FoodApiKey'");
    public async Task<FoodSearchApiResponse?> SearchFoodsAsync(string query)
    {
        return await httpClient.GetFromJsonAsync<FoodSearchApiResponse>(
            $"foods/search?pageSize=25&sortBy=dataType.keyword&sortOrder=asc&api_key={_fdcApiKey}&nutrients=203,204,205&query={query}&dataType=Branded,Foundation,Survey (FNDDS), SR Legacy"
        );

    }

    public async Task<FoodGetByIdApiResponse?> GetFoodByIdAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<FoodGetByIdApiResponse>($"food/{id}?api_key={_fdcApiKey}");
    }
}

public interface IFdcClient
{
    public Task<FoodSearchApiResponse?> SearchFoodsAsync(string query);
    public Task<FoodGetByIdApiResponse?> GetFoodByIdAsync(int id);
}