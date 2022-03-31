using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatitudeType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LatitudeValue = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    LongitudeType = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LongitudeValue = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouristBuildingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristBuildingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Altitude = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordinateId = table.Column<int>(type: "int", nullable: true),
                    MountainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peaks_Coordinates_CoordinateId",
                        column: x => x.CoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Peaks_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TouristBuildingId = table.Column<int>(type: "int", nullable: true),
                    TouristAssociationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssociationManagers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TouristAssociationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociationManagers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TouristAssociations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    WebSiteUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristAssociations_AssociationManagers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AssociationManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingManagers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TouristBuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingManagers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TouristBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Altitude = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TouristBuildingTypeId = table.Column<int>(type: "int", nullable: false),
                    TouristAssociationId = table.Column<int>(type: "int", nullable: false),
                    CoordinateId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    MountainId = table.Column<int>(type: "int", nullable: true),
                    TouristBuildingTypeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristBuildings_BuildingManagers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "BuildingManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristBuildings_Coordinates_CoordinateId",
                        column: x => x.CoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristBuildings_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristBuildings_TouristAssociations_TouristAssociationId",
                        column: x => x.TouristAssociationId,
                        principalTable: "TouristAssociations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristBuildings_TouristBuildingTypes_TouristBuildingTypeId",
                        column: x => x.TouristBuildingTypeId,
                        principalTable: "TouristBuildingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristBuildings_TouristBuildingTypes_TouristBuildingTypeId1",
                        column: x => x.TouristBuildingTypeId1,
                        principalTable: "TouristBuildingTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    TouristAssociationId = table.Column<int>(type: "int", nullable: true),
                    TouristBuildingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_TouristAssociations_TouristAssociationId",
                        column: x => x.TouristAssociationId,
                        principalTable: "TouristAssociations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_TouristBuildings_TouristBuildingId",
                        column: x => x.TouristBuildingId,
                        principalTable: "TouristBuildings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MountainId = table.Column<int>(type: "int", nullable: true),
                    PeakId = table.Column<int>(type: "int", nullable: true),
                    TouristAssociationId = table.Column<int>(type: "int", nullable: true),
                    TouristBuildingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Peaks_PeakId",
                        column: x => x.PeakId,
                        principalTable: "Peaks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_TouristAssociations_TouristAssociationId",
                        column: x => x.TouristAssociationId,
                        principalTable: "TouristAssociations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_TouristBuildings_TouristBuildingId",
                        column: x => x.TouristBuildingId,
                        principalTable: "TouristBuildings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    TouristBuildingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_TouristBuildings_TouristBuildingId",
                        column: x => x.TouristBuildingId,
                        principalTable: "TouristBuildings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_TouristAssociationId",
                table: "Announcements",
                column: "TouristAssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_TouristBuildingId",
                table: "Announcements",
                column: "TouristBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationManagers_TouristAssociationId",
                table: "AssociationManagers",
                column: "TouristAssociationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociationManagers_UserId",
                table: "AssociationManagers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingManagers_TouristBuildingId",
                table: "BuildingManagers",
                column: "TouristBuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingManagers_UserId",
                table: "BuildingManagers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TouristAssociationId",
                table: "Comments",
                column: "TouristAssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TouristBuildingId",
                table: "Comments",
                column: "TouristBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MountainId",
                table: "Images",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PeakId",
                table: "Images",
                column: "PeakId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TouristAssociationId",
                table: "Images",
                column: "TouristAssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TouristBuildingId",
                table: "Images",
                column: "TouristBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TouristBuildingId",
                table: "Likes",
                column: "TouristBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Peaks_CoordinateId",
                table: "Peaks",
                column: "CoordinateId",
                unique: true,
                filter: "[CoordinateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Peaks_MountainId",
                table: "Peaks",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristAssociations_ManagerId",
                table: "TouristAssociations",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_CoordinateId",
                table: "TouristBuildings",
                column: "CoordinateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_ManagerId",
                table: "TouristBuildings",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_MountainId",
                table: "TouristBuildings",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristBuildings_TouristAssociationId",
                table: "TouristBuildings",
                column: "TouristAssociationId");

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
                name: "FK_Announcements_TouristAssociations_TouristAssociationId",
                table: "Announcements",
                column: "TouristAssociationId",
                principalTable: "TouristAssociations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_TouristBuildings_TouristBuildingId",
                table: "Announcements",
                column: "TouristBuildingId",
                principalTable: "TouristBuildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationManagers_TouristAssociations_TouristAssociationId",
                table: "AssociationManagers",
                column: "TouristAssociationId",
                principalTable: "TouristAssociations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingManagers_TouristBuildings_TouristBuildingId",
                table: "BuildingManagers",
                column: "TouristBuildingId",
                principalTable: "TouristBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationManagers_TouristAssociations_TouristAssociationId",
                table: "AssociationManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristBuildings_TouristAssociations_TouristAssociationId",
                table: "TouristBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingManagers_TouristBuildings_TouristBuildingId",
                table: "BuildingManagers");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Peaks");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TouristAssociations");

            migrationBuilder.DropTable(
                name: "AssociationManagers");

            migrationBuilder.DropTable(
                name: "TouristBuildings");

            migrationBuilder.DropTable(
                name: "BuildingManagers");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Mountains");

            migrationBuilder.DropTable(
                name: "TouristBuildingTypes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
