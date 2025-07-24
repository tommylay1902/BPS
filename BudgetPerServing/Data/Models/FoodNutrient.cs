using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Models;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class FoodNutrient
{
        public int NutrientId { get; set; }
        public string NutrientName { get; set; } = string.Empty;
        public string NutrientNumber { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string DerivationCode { get; set; } = string.Empty;
        public string DerivationDescription { get; set; } = string.Empty;
        public int DerivationId { get; set; }
        public double Value { get; set; }
        public int FoodNutrientSourceId { get; set; }
        public string FoodNutrientSourceCode { get; set; } = string.Empty;
        public string FoodNutrientSourceDescription { get; set; } = string.Empty;
        public int Rank { get; set; }
        public int IndentLevel { get; set; }
        public int FoodNutrientId { get; set; }
        public int? PercentDailyValue { get; set; }
    
}