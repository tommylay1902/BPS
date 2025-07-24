
using System.Text.Json.Serialization;
using BudgetPerServing.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Clients;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class FoodGetByIdApiResponse
{
    
    public int FdcId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public string GtinUpc { get; set; } = string.Empty;
    public string PublishedDate { get; set; } = string.Empty;
    public string BrandOwner { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string MarketCountry { get; set; } = string.Empty;
    public string FoodCategory { get; set; } = string.Empty;
    public string ModifiedDate { get; set; } = string.Empty;
    public string DataSource { get; set; } = string.Empty;
    public string PackageWeight { get; set; } = string.Empty;
    public string ServingSizeUnit { get; set; } = string.Empty;
    public double ServingSize { get; set; }
    public string HouseholdServingFullText { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public List<string> TradeChannels { get; set; } = new();
    public string AllHighlightFields { get; set; } = string.Empty;
    public double Score { get; set; }
    public List<FoodNutrient> FoodNutrients { get; init; } = new();
}