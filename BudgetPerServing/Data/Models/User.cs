using System.ComponentModel.DataAnnotations;

namespace BudgetPerServing.Data.Models;

public class User
{
    [Key]
    public Guid Id { get; init; }
}