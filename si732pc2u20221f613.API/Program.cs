using si732pc2u20221f613.API.Shared.Domain.Repositories;
using si732pc2u20221f613.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si732pc2u20221f613.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using si732pc2u20221f613.API.Subscriptions.Application.Internal.CommandServices;
using si732pc2u20221f613.API.Subscriptions.domain.Repositories;
using si732pc2u20221f613.API.Subscriptions.infrastructure.Persistence.EFC.Repositories;
using si732pc2u20221f613.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using si732pc2u20221f613.API.Subscriptions.domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Get DB connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
    throw new Exception("Database connection string is not set.");

// Configure DbContext
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    });
}

// === Dependency Injection Configuration ===

// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Subscriptions - Command Service + Repository
builder.Services.AddScoped<IPlanCommandService, PlanCommandService>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();

// ==========================================

var app = builder.Build();

// Ensure DB is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// HTTP pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
