using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Models;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class Location
{
    [Key]
    public Guid Id { get; set; }
    [StringLength(200)]
    public required string Country { get; set; }
    [StringLength(200)]
    public required string City { get; set; }
    [StringLength(200)]
    public required string State { get; set; }
    [StringLength(200)]
    public required string ZipCode { get; set; }
    [StringLength(200)]
    public required string Street { get; set; }
    [StringLength(200)]
    public string? Suite { get; set; }
    
}