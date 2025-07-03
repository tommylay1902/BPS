using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }*/
    
    public DbSet<ServingLog> ServingLogs { get; set; }
}