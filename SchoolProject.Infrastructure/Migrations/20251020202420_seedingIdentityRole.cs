using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefualt", "IsDelete", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0195442f-5b32-7334-9a35-d43ff70d3aa9", "0195442f-5b32-761a-b2ee-cfca69434828", false, false, "Admin", "ADMIN" },
                    { "0195442f-5b32-7b00-a097-61b7c3baec76", "0195442f-5b32-7bfc-8b9c-18f34c1d2eea", true, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0195442f-5b32-7163-9117-b7023daacb2d", 0, "", "0195442f-5b32-7594-8754-260776e9cdcc", "", "admin@SchoolSystem.com", true, "Plant-Project", "", "Admin", false, null, "ADMIN@SCHOOLSYSTEM.COM", "ADMIN@SCHOOLSYSTEM.COM", "AQAAAAIAAYagAAAAEES76XCzEAJzOKK3RHphtyNuJc52FtrqMqoDuSoo921MiNJ/llOGYPXIq92thIuxvg==", "01205024661", true, "55BF92C9EF0249CDA210D85D1A851BC9", false, "School-Project" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permissions", "Students:Read", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 2, "Permissions", "Students:Add", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 3, "Permissions", "Students:Update", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 4, "Permissions", "Students:Delete", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 5, "Permissions", "Departments:Read", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 6, "Permissions", "Departments:Add", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 7, "Permissions", "Departments:Update", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 8, "Permissions", "Departments:Delete", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 9, "Permissions", "Instructors:Read", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 10, "Permissions", "Instructors:Add", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 11, "Permissions", "Instructors:Update", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 12, "Permissions", "Instructors:Delete", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 13, "Permissions", "Subjects:Read", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 14, "Permissions", "Subjects:Add", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 15, "Permissions", "Subjects:Update", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 16, "Permissions", "Subjects:Delete", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 17, "Permissions", "Users:Read", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 18, "Permissions", "Users:Add", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 19, "Permissions", "Users:Update", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 20, "Permissions", "Users:Delete", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 21, "Permissions", "Roles:Read", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 22, "Permissions", "Roles:Add", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 23, "Permissions", "Roles:Update", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 24, "Permissions", "Roles:Delete", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 25, "Permissions", "Authorization:AssignRole", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 26, "Permissions", "Authorization:RemoveRole", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 27, "Permissions", "Results:Read", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 28, "Permissions", "Results:Add", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 29, "Permissions", "Results:Update", "0195442f-5b32-7334-9a35-d43ff70d3aa9" },
                    { 30, "Permissions", "Results:Delete", "0195442f-5b32-7334-9a35-d43ff70d3aa9" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0195442f-5b32-7334-9a35-d43ff70d3aa9", "0195442f-5b32-7163-9117-b7023daacb2d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0195442f-5b32-7b00-a097-61b7c3baec76");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0195442f-5b32-7334-9a35-d43ff70d3aa9", "0195442f-5b32-7163-9117-b7023daacb2d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0195442f-5b32-7334-9a35-d43ff70d3aa9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0195442f-5b32-7163-9117-b7023daacb2d");
        }
    }
}
