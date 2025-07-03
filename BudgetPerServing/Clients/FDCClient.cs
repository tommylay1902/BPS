using System.Text;
using BudgetPerServing.Data.Clients;

namespace BudgetPerServing.Clients;

public class FdcClient(IConfiguration configuration, HttpClient httpClient):IFdcClient
{
    private readonly string _fdcApiKey = configuration.GetValue<string>("FoodApi:FoodApiKey") ?? throw new InvalidOperationException("Missing required configuration: 'FoodApi:FoodApiKey'");
    public async Task<FoodApiResponse?> SearchFoodsAsync(IQueryCollection queryParams)
    {
        var uri = new StringBuilder($"search?pageSize=25&sortBy=dataType.keyword&sortOrder=asc&api_key={_fdcApiKey}");
        
        foreach (var q in queryParams)
        {
            uri.Append($"&{q.Key}={q.Value}");
        }
        
        return await httpClient.GetFromJsonAsync<FoodApiResponse>(
            uri.ToString()
        );
    }
}

public interface IFdcClient
{
    public Task<FoodApiResponse?> SearchFoodsAsync(IQueryCollection query);
}