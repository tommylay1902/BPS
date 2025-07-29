namespace BudgetPerServing.Data.Dto.Location;

public record LocationCreateRequest(string Country, string State, string City, string ZipCode, string Street, string? Suite);