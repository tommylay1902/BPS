using System.Runtime.InteropServices.JavaScript;

namespace BudgetPerServing.Data.Models;

public class ServingLog
{
    public Guid Id { get; init; }
    public Decimal Serving { get; init; }
    public DateOnly  Date{ get; init; }
    public int FdcId{ get; set; }
}