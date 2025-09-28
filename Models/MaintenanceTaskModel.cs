namespace VehicleMaintenanceTracker;

public class MaintenanceTaskModel
{
    public int MaintenanceTaskId { get; set; }


    // Navigation Props
    public virtual VehicleModel Vehicle { get; set; } = null!;

    public virtual ICollection<MaintenanceStepModel> MaintenanceSteps { get; set; } = [];

    public virtual ICollection<MaintenanceSupplyModel> MaintenanceSupplies { get; set; } = [];
}
