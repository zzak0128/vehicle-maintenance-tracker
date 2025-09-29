namespace VehicleMaintenanceTracker;

public class MaintenanceSupplyModel
{
    public int MaintenanceSupplyId { get; set; }

    public string ItemName { get; set; } = "";

    public double Quantity { get; set; }

    public string Unit { get; set; } = "";

    // Navigation Props
    public virtual MaintenanceTaskModel MaintenanceTask { get; set; } = null!;
}
