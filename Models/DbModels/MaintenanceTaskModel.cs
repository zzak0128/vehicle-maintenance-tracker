namespace VehicleMaintenanceTracker;

public class MaintenanceTaskModel
{
    public int MaintenanceTaskId { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public string Frequency { get; set; } = "";


    // Navigation Props
    public virtual VehicleModel Vehicle { get; set; } = null!;

    public virtual ICollection<MaintenanceStepModel> MaintenanceSteps { get; set; } = [];

    public virtual ICollection<MaintenanceSupplyModel> MaintenanceSupplies { get; set; } = [];
}
