using System.Text.Json.Serialization;
using BudgetPerServing.Data.Models;

namespace BudgetPerServing.Data.Clients;

public class FoodGetByIdApiResponse
{
    [JsonPropertyName("fdcId")]
    public int FdcId { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("foodNutrients")]
    public List<FoodNutrient> FoodNutrients { get; set; } = new();
}