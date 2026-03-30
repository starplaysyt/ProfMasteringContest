using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfMasteringProject.Migrations
{
    /// <inheritdoc />
    public partial class RevisionAlpha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Pictures");

            migrationBuilder.AlterColumn<Guid>(
                name: "AvatarPictureId",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "InternalName",
                table: "Pictures",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PictureId",
                table: "PictureDataRoles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalName",
                table: "Pictures");

            migrationBuilder.AlterColumn<uint>(
                name: "AvatarPictureId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<uint>(
                name: "Id",
                table: "Pictures",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Pictures",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<uint>(
                name: "PictureId",
                table: "PictureDataRoles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");
        }
    }
}
