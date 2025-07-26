using BudgetPerServing.Data.Models;

namespace BudgetPerServing.Data.Dto;

public record FoodItemApiResponse(
    int FdcId,
    string Description,
    string DataType,
    string GtinUpc,
    string PublishedDate,
    string BrandOwner,
    string BrandName,
    string Ingredients,
    string MarketCountry,
    string FoodCategory,
    string ModifiedDate,
    string DataSource,
    string PackageWeight,
    string ServingSizeUnit,
    double ServingSize,
    string HouseholdServingFullText,
    string ShortDescription,
    List<string> TradeChannels,
    string AllHighlightFields,
    double Score,
    List<FoodNutrient> FoodNutrients
)
{
    // Default values for collections (avoids null issues)
    public List<string> TradeChannels { get; init; } = TradeChannels ?? new();
    public List<FoodNutrient> FoodNutrients { get; init; } = FoodNutrients ?? new();

    // Default empty strings for all string properties
    public string Description { get; init; } = Description ?? string.Empty;
    public string DataType { get; init; } = DataType ?? string.Empty;
    public string GtinUpc { get; init; } = GtinUpc ?? string.Empty;
    public string PublishedDate { get; init; } = PublishedDate ?? string.Empty;
    public string BrandOwner { get; init; } = BrandOwner ?? string.Empty;
    public string BrandName { get; init; } = BrandName ?? string.Empty;
    public string Ingredients { get; init; } = Ingredients ?? string.Empty;
    public string MarketCountry { get; init; } = MarketCountry ?? string.Empty;
    public string FoodCategory { get; init; } = FoodCategory ?? string.Empty;
    public string ModifiedDate { get; init; } = ModifiedDate ?? string.Empty;
    public string DataSource { get; init; } = DataSource ?? string.Empty;
    public string PackageWeight { get; init; } = PackageWeight ?? string.Empty;
    public string ServingSizeUnit { get; init; } = ServingSizeUnit ?? string.Empty;
    public string HouseholdServingFullText { get; init; } = HouseholdServingFullText ?? string.Empty;
    public string ShortDescription { get; init; } = ShortDescription ?? string.Empty;
    public string AllHighlightFields { get; init; } = AllHighlightFields ?? string.Empty;
}