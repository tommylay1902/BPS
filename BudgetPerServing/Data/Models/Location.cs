using System.ComponentModel.DataAnnotations;

namespace BudgetPerServing.Data.Models;

public class Location
{
    [Key]
    public Guid Id { get; set; }
    
    public string Country { get; set; }
    
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Suite { get; set; }
    
}