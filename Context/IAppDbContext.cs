using Microsoft.EntityFrameworkCore;

namespace VehicleMaintenanceTracker;

public interface IAppDbContext
{
    DbSet<VehicleModel> Vehicles { get; set; }
    DbSet<MaintenanceSupplyModel> MaintenanceSupplies { get; set; }
    DbSet<MaintenanceStepModel> MaintenanceSteps { get; set; }
    DbSet<MaintenanceTaskModel> MaintenanceTasks { get; set; }
}
