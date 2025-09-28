using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleMaintenanceTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaintenanceTasks",
                columns: table => new
                {
                    MaintenanceTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTasks", x => x.MaintenanceTaskId);
                    table.ForeignKey(
                        name: "FK_MaintenanceTasks_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaintenanceSteps",
                columns: table => new
                {
                    MaintenanceStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskMaintenanceTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceSteps", x => x.MaintenanceStepId);
                    table.ForeignKey(
                        name: "FK_MaintenanceSteps_MaintenanceTasks_TaskMaintenanceTaskId",
                        column: x => x.TaskMaintenanceTaskId,
                        principalTable: "MaintenanceTasks",
                        principalColumn: "MaintenanceTaskId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaintenanceSupplies",
                columns: table => new
                {
                    MaintenanceSupplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaintenanceTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceSupplies", x => x.MaintenanceSupplyId);
                    table.ForeignKey(
                        name: "FK_MaintenanceSupplies_MaintenanceTasks_MaintenanceTaskId",
                        column: x => x.MaintenanceTaskId,
                        principalTable: "MaintenanceTasks",
                        principalColumn: "MaintenanceTaskId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSteps_TaskMaintenanceTaskId",
                table: "MaintenanceSteps",
                column: "TaskMaintenanceTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSupplies_MaintenanceTaskId",
                table: "MaintenanceSupplies",
                column: "MaintenanceTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTasks_VehicleId",
                table: "MaintenanceTasks",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceSteps");

            migrationBuilder.DropTable(
                name: "MaintenanceSupplies");

            migrationBuilder.DropTable(
                name: "MaintenanceTasks");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
