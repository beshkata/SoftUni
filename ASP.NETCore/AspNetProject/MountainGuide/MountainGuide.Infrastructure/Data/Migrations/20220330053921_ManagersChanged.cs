using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class ManagersChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristAssociations_AssociationManagers_ManagerId",
                table: "TouristAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristBuildings_BuildingManagers_ManagerId",
                table: "TouristBuildings");

            migrationBuilder.DropIndex(
                name: "IX_TouristBuildings_ManagerId",
                table: "TouristBuildings");

            migrationBuilder.DropIndex(
                name: "IX_TouristAssociations_ManagerId",
                table: "TouristAssociations");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "TouristBuildings");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "TouristAssociations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "TouristBuildings",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "TouristAssociations",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_ManagerId",
                table: "TouristBuildings",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristAssociations_ManagerId",
                table: "TouristAssociations",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristAssociations_AssociationManagers_ManagerId",
                table: "TouristAssociations",
                column: "ManagerId",
                principalTable: "AssociationManagers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristBuildings_BuildingManagers_ManagerId",
                table: "TouristBuildings",
                column: "ManagerId",
                principalTable: "BuildingManagers",
                principalColumn: "Id");
        }
    }
}
