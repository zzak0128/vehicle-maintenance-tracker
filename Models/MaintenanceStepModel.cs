namespace VehicleMaintenanceTracker;

public class MaintenanceStepModel
{
    public int MaintenanceStepId { get; set; }

    // Navigation Properties
    public virtual MaintenanceTaskModel Task { get; set; } = null!;
    
}
