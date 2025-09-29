using Microsoft.EntityFrameworkCore;
using VehicleMaintenanceTracker;
using VehicleMaintenanceTracker.Context;
using VehicleMaintenanceTracker.Models.DTOs.Vehicles;

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

app.MapPost("/vehicles", async (AppDbContext db, VehicleDTO vehicle) =>
{
    db.Vehicles.Add(new VehicleModel
    {
        ModelName = vehicle.ModelName,
        Color = vehicle.Color,
        Year = vehicle.Year,
        BrandName = vehicle.BrandName
    });

    await db.SaveChangesAsync();
    return Results.Created();
});

app.MapPatch("/vehicles/{id}", async (AppDbContext db, VehicleDTO vehicle, int id) =>
{
    VehicleModel? updateVehicle = await db.Vehicles.FindAsync(id);

    if (updateVehicle == null)
    {
        return Results.NotFound();
    }

    updateVehicle.BrandName = vehicle.BrandName;
    updateVehicle.Color = vehicle.Color;
    updateVehicle.Year = vehicle.Year;
    updateVehicle.ModelName = vehicle.ModelName;

    db.Vehicles.Update(updateVehicle);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/vehicles/{id}", async (AppDbContext db, int id) =>
{
    VehicleModel? deleteVehicle = await db.Vehicles.FindAsync(id);

    if (deleteVehicle == null)
    {
        return Results.NotFound();
    }

    db.Vehicles.Remove(deleteVehicle);
    await db.SaveChangesAsync();

    return Results.Ok();
});

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

app.Run();



