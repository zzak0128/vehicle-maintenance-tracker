using Microsoft.EntityFrameworkCore;

namespace VehicleMaintenanceTracker.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<VehicleModel> Vehicles { get; set; }

    public DbSet<MaintenanceSupplyModel> MaintenanceSupplies { get; set; }

    public DbSet<MaintenanceStepModel> MaintenanceSteps { get; set; }

    public DbSet<MaintenanceTaskModel> MaintenanceTasks { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleModel>(e =>
        {
            e.HasKey(x => x.VehicleId);
            e.HasMany(x => x.MaintenanceTasks)
            .WithOne(x => x.Vehicle)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<MaintenanceSupplyModel>(e =>
        {
            e.HasKey(x => x.MaintenanceSupplyId);
            e.HasOne(x => x.MaintenanceTask)
            .WithMany(x => x.MaintenanceSupplies)
            .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<MaintenanceStepModel>(e =>
        {
            e.HasKey(x => x.MaintenanceStepId);
            e.HasOne(x => x.Task)
            .WithMany(x => x.MaintenanceSteps)
            .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<MaintenanceTaskModel>(e =>
        {
            e.HasKey(x => x.MaintenanceTaskId);
            e.HasMany(x => x.MaintenanceSupplies)
            .WithOne(x => x.MaintenanceTask)
            .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}
