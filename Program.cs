using Microsoft.EntityFrameworkCore;
using VehicleMaintenanceTracker;
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

app.MapGet("/vehicles", async (AppDbContext db) => await db.Vehicles
.ToListAsync())
.WithName("GetAllVehicles");

app.MapGet("/vehicles/{id}/tasks/", async (AppDbContext db, int id) => await db.Vehicles
.Where(x => x.VehicleId == id)
.Include(x => x.MaintenanceTasks)
.ToListAsync())
.WithName("GetAllVehicleMaintenanceTasks");

app.MapGet("/vehicles/tasks/supplies", async (AppDbContext db) => await db.Vehicles
.Include(x => x.MaintenanceTasks)
.ThenInclude(x => x.MaintenanceSupplies)
.ToListAsync());

app.MapGet("/vehicles/tasks/steps", async (AppDbContext db) => await db.Vehicles
.Include(x => x.MaintenanceTasks)
.ThenInclude(x => x.MaintenanceSteps)
.ToListAsync());

app.MapPost("/vehicles", async (AppDbContext db, vehicleDTO vehicle) =>
{
    db.Vehicles.Add(new VehicleModel
    {
        ModelName = vehicle.Model,
        Color = vehicle.Color,
        Year = vehicle.Year,
        BrandName = vehicle.Brand
    });

    await db.SaveChangesAsync();
    return Results.Created();
});

app.MapDelete("/vehicles/{id}", async (AppDbContext db, int id) =>
{
    db.Vehicles.Remove(db.Vehicles.Find(id));
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.Run();

record vehicleDTO(string Model, string Color, int Year, string Brand);

