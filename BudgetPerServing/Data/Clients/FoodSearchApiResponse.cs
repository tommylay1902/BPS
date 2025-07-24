using BudgetPerServing.Data.Models;

namespace BudgetPerServing.Data.Clients;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class FoodSearchApiResponse
{
    [JsonPropertyName("totalHits")]
    public int TotalHits { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("pageList")]
    public List<int> PageList { get; set; } = new();

    [JsonPropertyName("foodSearchCriteria")]
    public FoodSearchCriteria FoodSearchCriteria { get; set; } = new();

    [JsonPropertyName("foods")]
    public List<FoodItem> Foods { get; set; } = new();

    [JsonPropertyName("aggregations")]
    public Aggregations Aggregations { get; set; } = new();
}

public class FoodSearchCriteria
{
    [JsonPropertyName("dataType")]
    public List<string> DataTypes { get; set; } = new();

    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;

    [JsonPropertyName("generalSearchInput")]
    public string GeneralSearchInput { get; set; } = string.Empty;

    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; }

    [JsonPropertyName("sortBy")]
    public string SortBy { get; set; } = string.Empty;

    [JsonPropertyName("sortOrder")]
    public string SortOrder { get; set; } = string.Empty;

    [JsonPropertyName("numberOfResultsPerPage")]
    public int NumberOfResultsPerPage { get; set; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    [JsonPropertyName("requireAllWords")]
    public bool RequireAllWords { get; set; }

    [JsonPropertyName("foodTypes")]
    public List<string> FoodTypes { get; set; } = new();
}

public class Aggregations
{
    [JsonPropertyName("dataType")]
    public Dictionary<string, int> DataType { get; set; } = new();

    [JsonPropertyName("nutrients")]
    public Dictionary<string, object> Nutrients { get; set; } = new();
}