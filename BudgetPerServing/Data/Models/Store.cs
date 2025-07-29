using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Models;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
[Index(nameof(LocationId), IsUnique = true)]
public class Store
{
    [Key]
    public Guid Id { get; set; }
    
    [StringLength(200)]
    public required string Name { get; set; }
   
    public required Guid LocationId{get; set;}

    [ForeignKey("LocationId")]
    public Location? Location { get; set; }
}