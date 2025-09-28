using Microsoft.EntityFrameworkCore;
using VehicleMaintenanceTracker.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContextFactory<AppDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/vehicles", async (AppDbContext db) => await db.Vehicles.ToListAsync());

app.MapGet("/vehicles/tasks", async (AppDbContext db) => await db.Vehicles.Include(x => x.MaintenanceTasks).ToListAsync());


app.Run();
