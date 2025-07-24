using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Models;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class Store
{
    public Guid Id { get; set; }
    [StringLength(200)]
    public required string Name { get; set; }
    
    public Guid LocationId{get;set;}
    public required Location Location { get; set; }
}