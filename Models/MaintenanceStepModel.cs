namespace VehicleMaintenanceTracker;

public class MaintenanceStepModel
{
    public int MaintenanceStepId { get; set; }

    // Navigation Properties
    public virtual MaintenanceTaskModel Tasks { get; set; } = null!;
    
}
