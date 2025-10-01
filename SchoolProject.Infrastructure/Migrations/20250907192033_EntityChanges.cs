using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Subjects",
                newName: "SubjectNameAr");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "DName",
                table: "Departments",
                newName: "DNameAr");

            migrationBuilder.AddColumn<string>(
                name: "SubjectNameEn",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNameEn",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectNameEn",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DNameEn",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "SubjectNameAr",
                table: "Subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DNameAr",
                table: "Departments",
                newName: "DName");
        }
    }
}
