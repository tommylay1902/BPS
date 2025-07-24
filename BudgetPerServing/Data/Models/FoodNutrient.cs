using System.Text.Json.Serialization;

namespace BudgetPerServing.Data.Models;

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