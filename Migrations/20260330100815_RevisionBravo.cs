using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfMasteringProject.Migrations
{
    /// <inheritdoc />
    public partial class RevisionBravo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures_AvatarPictureId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AvatarPictureId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AvatarPictureId",
                table: "Users",
                newName: "AvatarPicturePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarPicturePath",
                table: "Users",
                newName: "AvatarPictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AvatarPictureId",
                table: "Users",
                column: "AvatarPictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pictures_AvatarPictureId",
                table: "Users",
                column: "AvatarPictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
