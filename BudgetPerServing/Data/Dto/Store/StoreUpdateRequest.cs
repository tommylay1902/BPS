using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetPerServing.Data.Dto;
[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record StoreUpdateRequest(string? Name, Guid? LocationId);