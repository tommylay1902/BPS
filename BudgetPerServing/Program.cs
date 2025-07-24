using BudgetPerServing.Clients;
using BudgetPerServing.DAO;
using BudgetPerServing.Data;
using BudgetPerServing.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var foodApiKey = builder.Configuration["FoodApi:FoodApiKey"];


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
;

builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("BudgetPerServingDb"));
});

// add service layer services
builder.Services.AddScoped<IFoodItemService, FoodItemService>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddScoped<IFdcClient, FdcClient>();
builder.Services.AddHttpClient<IFdcClient, FdcClient>(client =>
{
    client.BaseAddress = new Uri("https://api.nal.usda.gov/fdc/v1/");
});
// add dao layer services
builder.Services.AddScoped<IFoodItemDao, FoodItemDao>(); 
builder.Services.AddScoped<ILocationDao, LocationDao>();

//add logging for docker containers
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();

var logger = app.Logger;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    logger.LogInformation("Development environment detected. OpenAPI documentation is enabled.");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();