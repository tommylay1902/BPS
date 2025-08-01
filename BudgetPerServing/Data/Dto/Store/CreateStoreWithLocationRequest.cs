using BudgetPerServing.Data.Dto.Location;

namespace BudgetPerServing.Data.Dto;

public record CreateStoreWithLocationRequest(string Name, LocationCreateRequest Location);