using System.ComponentModel.DataAnnotations;

namespace BudgetPerServing.Data.Models;

public class FoodItem
{
    [Key]
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required Decimal TotalServings { get; init; }
    public required Decimal TotalPrice { get; init; }
}