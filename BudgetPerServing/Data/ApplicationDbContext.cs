using BudgetPerServing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPerServing.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    public DbSet<UserFoodItem> UserFoodItems { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<ServingLog> ServingLogs { get; set; }
}