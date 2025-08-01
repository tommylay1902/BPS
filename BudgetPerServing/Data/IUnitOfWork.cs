using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BudgetPerServing.Data;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    
    IDbTransaction BeginTransaction();
    
}

internal sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);   
    }

    public IDbTransaction BeginTransaction()
    {   
        var transaction = context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}