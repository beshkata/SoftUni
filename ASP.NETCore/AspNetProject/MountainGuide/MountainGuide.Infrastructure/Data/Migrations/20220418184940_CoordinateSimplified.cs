using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class CoordinateSimplified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatitudeType",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "LatitudeValue",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "LongitudeType",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "LongitudeValue",
                table: "Coordinates");

            migrationBuilder.AlterColumn<int>(
                name: "TouristAssociationId",
                table: "TouristBuildings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Coordinates",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Coordinates",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Coordinates");

            migrationBuilder.AlterColumn<int>(
                name: "TouristAssociationId",
                table: "TouristBuildings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatitudeType",
                table: "Coordinates",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LatitudeValue",
                table: "Coordinates",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongitudeType",
                table: "Coordinates",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongitudeValue",
                table: "Coordinates",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }
    }
}
