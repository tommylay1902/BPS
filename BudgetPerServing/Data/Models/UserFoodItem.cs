using System.ComponentModel.DataAnnotations;

namespace BudgetPerServing.Data.Models;

public class UserFoodItem
{
    [Key]
    public Guid Id { get; set; }
    [StringLength(300)]
    public string BrandOwner { get; set; } = string.Empty;
    [StringLength(400)]
    public string BrandName { get; set; } = string.Empty;
    [StringLength(50)]
    public string ServingSizeUnit { get; set; } = string.Empty;
    [StringLength(100)]
    public double ServingSize { get; set; }
    
    public List<FoodNutrient> FoodNutrients { get; set; } = new();
    
    public double Price { get; set; }
}