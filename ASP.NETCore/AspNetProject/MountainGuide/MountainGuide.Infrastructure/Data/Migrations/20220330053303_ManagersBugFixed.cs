using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class ManagersBugFixed : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_ManagerId",
                table: "TouristBuildings",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TouristAssociations_ManagerId",
                table: "TouristAssociations",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristAssociations_AssociationManagers_ManagerId",
                table: "TouristAssociations",
                column: "ManagerId",
                principalTable: "AssociationManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristBuildings_BuildingManagers_ManagerId",
                table: "TouristBuildings",
                column: "ManagerId",
                principalTable: "BuildingManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
