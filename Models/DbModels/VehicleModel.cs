namespace VehicleMaintenanceTracker;

public class VehicleModel
{
    public int VehicleId { get; set; }

    public string ModelName { get; set; } = "";

    public string Color { get; set; } = "";

    public int Year { get; set; }

    public string BrandName { get; set; } = "";

    // Navigation Props
    public virtual ICollection<MaintenanceTaskModel> MaintenanceTasks { get; set; } = [];
}
