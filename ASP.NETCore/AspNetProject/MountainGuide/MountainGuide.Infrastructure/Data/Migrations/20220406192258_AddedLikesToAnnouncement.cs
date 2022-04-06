using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    public partial class AddedLikesToAnnouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AnnouncementId",
                table: "Likes",
                column: "AnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId",
                table: "Likes",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_AnnouncementId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "Likes");
        }
    }
}
