using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace BudgetPerServing.Data.Models;

public class ServingLog
{
    public Guid Id { get; init; }
    public Decimal Serving { get; init; }
    
    public DateTime  Date{ get; init; }
    [StringLength(8)]
    public required string FdcId { get; init; }
}