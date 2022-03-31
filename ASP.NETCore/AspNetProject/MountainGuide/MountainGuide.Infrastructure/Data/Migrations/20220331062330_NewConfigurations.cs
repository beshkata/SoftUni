using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class NewConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TouristAssociations_TouristAssociationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TouristBuildings_TouristBuildingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Comments_CommentId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_TouristBuildings_TouristBuildingId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Peaks_Coordinates_CoordinateId",
                table: "Peaks");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristBuildings_Coordinates_CoordinateId",
                table: "TouristBuildings");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Peaks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TouristAssociationId",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Images",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TouristAssociationId",
                table: "Likes",
                column: "TouristAssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TouristAssociations_TouristAssociationId",
                table: "Comments",
                column: "TouristAssociationId",
                principalTable: "TouristAssociations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TouristBuildings_TouristBuildingId",
                table: "Comments",
                column: "TouristBuildingId",
                principalTable: "TouristBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Comments_CommentId",
                table: "Likes",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_TouristAssociations_TouristAssociationId",
                table: "Likes",
                column: "TouristAssociationId",
                principalTable: "TouristAssociations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_TouristBuildings_TouristBuildingId",
                table: "Likes",
                column: "TouristBuildingId",
                principalTable: "TouristBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Peaks_Coordinates_CoordinateId",
                table: "Peaks",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristBuildings_Coordinates_CoordinateId",
                table: "TouristBuildings",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TouristAssociations_TouristAssociationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TouristBuildings_TouristBuildingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Comments_CommentId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_TouristAssociations_TouristAssociationId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_TouristBuildings_TouristBuildingId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Peaks_Coordinates_CoordinateId",
                table: "Peaks");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristBuildings_Coordinates_CoordinateId",
                table: "TouristBuildings");

            migrationBuilder.DropIndex(
                name: "IX_Likes_TouristAssociationId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "TouristAssociationId",
                table: "Likes");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Peaks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Images",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TouristAssociations_TouristAssociationId",
                table: "Comments",
                column: "TouristAssociationId",
                principalTable: "TouristAssociations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TouristBuildings_TouristBuildingId",
                table: "Comments",
                column: "TouristBuildingId",
                principalTable: "TouristBuildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Comments_CommentId",
                table: "Likes",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_TouristBuildings_TouristBuildingId",
                table: "Likes",
                column: "TouristBuildingId",
                principalTable: "TouristBuildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Peaks_Coordinates_CoordinateId",
                table: "Peaks",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristBuildings_Coordinates_CoordinateId",
                table: "TouristBuildings",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
