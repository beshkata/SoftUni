using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class BuiltingTypesBugFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristBuildings_TouristBuildingTypes_TouristBuildingTypeId1",
                table: "TouristBuildings");

            migrationBuilder.DropIndex(
                name: "IX_TouristBuildings_TouristBuildingTypeId",
                table: "TouristBuildings");

            migrationBuilder.DropIndex(
                name: "IX_TouristBuildings_TouristBuildingTypeId1",
                table: "TouristBuildings");

            migrationBuilder.DropColumn(
                name: "TouristBuildingTypeId1",
                table: "TouristBuildings");

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_TouristBuildingTypeId",
                table: "TouristBuildings",
                column: "TouristBuildingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TouristBuildings_TouristBuildingTypeId",
                table: "TouristBuildings");

            migrationBuilder.AddColumn<int>(
                name: "TouristBuildingTypeId1",
                table: "TouristBuildings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_TouristBuildingTypeId",
                table: "TouristBuildings",
                column: "TouristBuildingTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_TouristBuildingTypeId1",
                table: "TouristBuildings",
                column: "TouristBuildingTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristBuildings_TouristBuildingTypes_TouristBuildingTypeId1",
                table: "TouristBuildings",
                column: "TouristBuildingTypeId1",
                principalTable: "TouristBuildingTypes",
                principalColumn: "Id");
        }
    }
}
