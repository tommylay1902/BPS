namespace BudgetPerServing.Exceptions;

public class NoUpdateException : Exception
{
    // Basic constructor
    public NoUpdateException() 
        : base("The resource has no valid updates") 
    {
    }

    // Constructor with custom message
    public NoUpdateException(string message) 
        : base(message) 
    {
    }

    // Constructor with message and inner exception
    public NoUpdateException(string message, Exception innerException) 
        : base(message, innerException) 
    {
    }

    // Optional: Add resource-specific properties
    public string ResourceType { get; init; }
    public object ResourceId { get; init; }
}