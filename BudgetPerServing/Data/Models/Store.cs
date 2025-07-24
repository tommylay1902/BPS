using System.ComponentModel.DataAnnotations;

namespace BudgetPerServing.Data.Models;

public class Store
{
    public Guid Id { get; set; }
    [StringLength(200)]
    public required string Name { get; set; }
    
    Location Location { get; set; } = new();
    
}