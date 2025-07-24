using BudgetPerServing.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Clients;

using System.Collections.Generic;
using System.Text.Json.Serialization;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class FoodSearchApiResponse
{
    public int TotalHits { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public List<int> PageList { get; set; } = new();
    public FoodSearchCriteria FoodSearchCriteria { get; set; } = new();
    public List<FoodItem> Foods { get; set; } = new();
    public Aggregations Aggregations { get; set; } = new();
}

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class FoodSearchCriteria
{
    public List<string> DataTypes { get; set; } = new();
    public string Query { get; set; } = string.Empty;
    public string GeneralSearchInput { get; set; } = string.Empty;
    public int PageNumber { get; set; }
    public string SortBy { get; set; } = string.Empty;
    public string SortOrder { get; set; } = string.Empty;
    public int NumberOfResultsPerPage { get; set; }
    public int PageSize { get; set; }
    public bool RequireAllWords { get; set; }
    public List<string> FoodTypes { get; set; } = new();
}

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class Aggregations
{
    public Dictionary<string, int> DataType { get; set; } = new();
    public Dictionary<string, object> Nutrients { get; set; } = new();
}