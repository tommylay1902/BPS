using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Models;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class ServingLog
{
    public Guid Id { get; init; }
    public Decimal Serving { get; init; }
    public DateOnly  Date{ get; init; }
    public int FdcId{ get; set; }
}