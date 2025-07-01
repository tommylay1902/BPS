using BudgetPerServing.Data.Clients;

namespace BudgetPerServing.Clients;

public class FdcClient(IConfiguration configuration, HttpClient httpClient):IFdcClient
{
    private readonly string _fdcApiKey = configuration.GetValue<string>("FoodApi:FoodApiKey") ?? throw new InvalidOperationException("Missing required configuration: 'FoodApi:FoodApiKey'");
    public async Task<FoodApiResponse?> SearchFoodsAsync(string query)
    {
        return await httpClient.GetFromJsonAsync<FoodApiResponse>(
            $"search?pageSize=25&sortBy=dataType.keyword&sortOrder=asc&api_key={_fdcApiKey}&nutrients=203,204,205&query={query}&dataType=Branded,Foundation,Survey (FNDDS), SR Legacy"
        );

    }
}

public interface IFdcClient
{
    public Task<FoodApiResponse?> SearchFoodsAsync(string query);
}