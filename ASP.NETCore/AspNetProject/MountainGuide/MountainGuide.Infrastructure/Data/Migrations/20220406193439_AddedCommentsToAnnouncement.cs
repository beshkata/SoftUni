using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class AddedCommentsToAnnouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnnouncementId",
                table: "Comments",
                column: "AnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Announcements_AnnouncementId",
                table: "Comments",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Announcements_AnnouncementId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnnouncementId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "Comments");
        }
    }
}
