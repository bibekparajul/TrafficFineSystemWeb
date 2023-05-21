using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficFineSystemWeb.Migrations
{
    public partial class addFineAndDriversToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversAds",
                columns: table => new
                {
                    VechileNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VechineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversAds", x => x.VechileNumber);
                });

            migrationBuilder.CreateTable(
                name: "FineModels",
                columns: table => new
                {
                    FineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrafficId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FineModels", x => x.FineId);
                    table.ForeignKey(
                        name: "FK_FineModels_DriversAds_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DriversAds",
                        principalColumn: "VechileNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FineModels_TrafficAds_TrafficId",
                        column: x => x.TrafficId,
                        principalTable: "TrafficAds",
                        principalColumn: "TrafficId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FineModels_DriverId",
                table: "FineModels",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_FineModels_TrafficId",
                table: "FineModels",
                column: "TrafficId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FineModels");

            migrationBuilder.DropTable(
                name: "DriversAds");
        }
    }
}
