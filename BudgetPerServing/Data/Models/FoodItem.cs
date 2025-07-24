using System.Text.Json.Serialization;


namespace BudgetPerServing.Data.Models;

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
