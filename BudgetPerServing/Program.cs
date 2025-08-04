using System.Diagnostics;
using BudgetPerServing.Clients;
using BudgetPerServing.Dao;
using BudgetPerServing.Data;
using BudgetPerServing.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()  
                .AllowAnyMethod()  
                .AllowCredentials(); 
        });
});
builder.Services.Configure<RouteHandlerOptions>(options =>
{
    options.ThrowOnBadRequest = true;
});

var foodApiKey = builder.Configuration["FoodApi:FoodApiKey"];
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "One or more validation errors occurred."
        };
        return new BadRequestObjectResult(problemDetails);
    };
});

builder.Services.AddProblemDetails(
    options => options.CustomizeProblemDetails = (context) => {
        var httpContext = context.HttpContext;
        context.ProblemDetails.Extensions["traceId"] = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        context.ProblemDetails.Extensions["supportContact"] = "bps.support@example.com";
        
        switch (context.ProblemDetails.Status)
        {
            case StatusCodes.Status401Unauthorized:
                context.ProblemDetails.Title = "UnauthorizedAccess";
                context.ProblemDetails.Detail = "You are not authorized to access this resource.";
                break;
            case StatusCodes.Status400BadRequest:
                context.ProblemDetails.Title = "BadRequest";
                context.ProblemDetails.Detail = context.ProblemDetails.Detail;
                break;
            case StatusCodes.Status404NotFound:
                context.ProblemDetails.Title = "Resource Not Found";
                context.ProblemDetails.Detail = "The resource you are looking for was not found.";
                break;
            case StatusCodes.Status409Conflict:
                context.ProblemDetails.Title = "Conflict";
                context.ProblemDetails.Detail = "The resource has a conflict";
                break;
            default:
                context.ProblemDetails.Title = "An unexpected error occurred";
                context.ProblemDetails.Detail = "An unexpected error occurred. Please try again later.";
                break;
        }

    }
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
;

builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("BudgetPerServingDb"));
});

// add service layer services
builder.Services.AddScoped<IFoodItemService, FoodItemService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IStoreService, StoreService>();

builder.Services.AddScoped<IFdcClient, FdcClient>();
builder.Services.AddHttpClient<IFdcClient, FdcClient>(client =>
{
    client.BaseAddress = new Uri("https://api.nal.usda.gov/fdc/v1/");
});
// add dao layer services
builder.Services.AddScoped<IFoodItemDao, FoodItemDao>(); 
builder.Services.AddScoped<ILocationDao, LocationDao>();
builder.Services.AddScoped<IStoreDao, StoreDao>();

//add logging for docker containers
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();
app.UseCors();
app.UseExceptionHandler();
app.UseStatusCodePages();


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