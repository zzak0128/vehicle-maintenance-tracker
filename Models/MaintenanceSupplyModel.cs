namespace VehicleMaintenanceTracker;

public class MaintenanceSupplyModel
{
    public int MaintenanceSupplyId { get; set; }

    // Navigation Props
    public virtual MaintenanceTaskModel MaintenanceTask { get; set; } = null!;
}
