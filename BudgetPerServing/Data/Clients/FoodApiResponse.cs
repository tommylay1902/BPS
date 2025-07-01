namespace BudgetPerServing.Data.Clients;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class FoodApiResponse
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

public class FoodItem
{
    [JsonPropertyName("fdcId")]
    public int FdcId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("dataType")]
    public string DataType { get; set; } = string.Empty;

    [JsonPropertyName("gtinUpc")]
    public string GtinUpc { get; set; } = string.Empty;

    [JsonPropertyName("publishedDate")]
    public string PublishedDate { get; set; } = string.Empty;

    [JsonPropertyName("brandOwner")]
    public string BrandOwner { get; set; } = string.Empty;

    [JsonPropertyName("brandName")]
    public string BrandName { get; set; } = string.Empty;

    [JsonPropertyName("ingredients")]
    public string Ingredients { get; set; } = string.Empty;

    [JsonPropertyName("marketCountry")]
    public string MarketCountry { get; set; } = string.Empty;

    [JsonPropertyName("foodCategory")]
    public string FoodCategory { get; set; } = string.Empty;

    [JsonPropertyName("modifiedDate")]
    public string ModifiedDate { get; set; } = string.Empty;

    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; } = string.Empty;

    [JsonPropertyName("packageWeight")]
    public string PackageWeight { get; set; } = string.Empty;

    [JsonPropertyName("servingSizeUnit")]
    public string ServingSizeUnit { get; set; } = string.Empty;

    [JsonPropertyName("servingSize")]
    public double ServingSize { get; set; }

    [JsonPropertyName("householdServingFullText")]
    public string HouseholdServingFullText { get; set; } = string.Empty;

    [JsonPropertyName("shortDescription")]
    public string ShortDescription { get; set; } = string.Empty;

    [JsonPropertyName("tradeChannels")]
    public List<string> TradeChannels { get; set; } = new();

    [JsonPropertyName("allHighlightFields")]
    public string AllHighlightFields { get; set; } = string.Empty;

    [JsonPropertyName("score")]
    public double Score { get; set; }

    [JsonPropertyName("microbes")]
    public List<object> Microbes { get; set; } = new();

    [JsonPropertyName("foodNutrients")]
    public List<FoodNutrient> FoodNutrients { get; set; } = new();

    [JsonPropertyName("finalFoodInputFoods")]
    public List<object> FinalFoodInputFoods { get; set; } = new();

    [JsonPropertyName("foodMeasures")]
    public List<object> FoodMeasures { get; set; } = new();

    [JsonPropertyName("foodAttributes")]
    public List<object> FoodAttributes { get; set; } = new();

    [JsonPropertyName("foodAttributeTypes")]
    public List<object> FoodAttributeTypes { get; set; } = new();

    [JsonPropertyName("foodVersionIds")]
    public List<object> FoodVersionIds { get; set; } = new();
}

public class FoodNutrient
{
    [JsonPropertyName("nutrientId")]
    public int NutrientId { get; set; }

    [JsonPropertyName("nutrientName")]
    public string NutrientName { get; set; } = string.Empty;

    [JsonPropertyName("nutrientNumber")]
    public string NutrientNumber { get; set; } = string.Empty;

    [JsonPropertyName("unitName")]
    public string UnitName { get; set; } = string.Empty;

    [JsonPropertyName("derivationCode")]
    public string DerivationCode { get; set; } = string.Empty;

    [JsonPropertyName("derivationDescription")]
    public string DerivationDescription { get; set; } = string.Empty;

    [JsonPropertyName("derivationId")]
    public int DerivationId { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("foodNutrientSourceId")]
    public int FoodNutrientSourceId { get; set; }

    [JsonPropertyName("foodNutrientSourceCode")]
    public string FoodNutrientSourceCode { get; set; } = string.Empty;

    [JsonPropertyName("foodNutrientSourceDescription")]
    public string FoodNutrientSourceDescription { get; set; } = string.Empty;

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("indentLevel")]
    public int IndentLevel { get; set; }

    [JsonPropertyName("foodNutrientId")]
    public int FoodNutrientId { get; set; }

    [JsonPropertyName("percentDailyValue")]
    public int? PercentDailyValue { get; set; }
}

public class Aggregations
{
    [JsonPropertyName("dataType")]
    public Dictionary<string, int> DataType { get; set; } = new();

    [JsonPropertyName("nutrients")]
    public Dictionary<string, object> Nutrients { get; set; } = new();
}