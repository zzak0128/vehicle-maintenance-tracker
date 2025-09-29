namespace VehicleMaintenanceTracker;

public class MaintenanceStepModel
{
    public int MaintenanceStepId { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    // Navigation Properties
    public virtual MaintenanceTaskModel Task { get; set; } = null!;
    
}
