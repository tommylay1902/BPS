namespace BudgetPerServing.Exceptions;

public class ResourceConflictException:Exception
{
    public ResourceConflictException() 
        : base("The resource has no valid updates") 
    {
    }

    // Constructor with custom message
    public ResourceConflictException(string message) 
        : base(message) 
    {
    }

    // Constructor with message and inner exception
    public ResourceConflictException(string message, Exception innerException) 
        : base(message, innerException) 
    {
    }

    // Optional: Add resource-specific properties
    public string ResourceType { get; init; }
    public object ResourceId { get; init; }
}