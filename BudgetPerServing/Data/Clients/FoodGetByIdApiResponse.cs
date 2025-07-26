
using System.Text.Json.Serialization;
using BudgetPerServing.Data.Dto;
using BudgetPerServing.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Clients;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class FoodGetByIdApiResponse
{
    public required FoodItemApiResponse FoodItem { get; set; }
}