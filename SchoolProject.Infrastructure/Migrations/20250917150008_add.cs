using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instractor_InsManger",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subject_Instractor_InsId",
                table: "Ins_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subject_Subjects_SubId",
                table: "Ins_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractor_Departments_DID",
                table: "Instractor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractor_Instractor_SupervisorId",
                table: "Instractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instractor",
                table: "Instractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject");

            migrationBuilder.RenameTable(
                name: "Instractor",
                newName: "instractors");

            migrationBuilder.RenameTable(
                name: "Ins_Subject",
                newName: "ins_subjects");

            migrationBuilder.RenameIndex(
                name: "IX_Instractor_SupervisorId",
                table: "instractors",
                newName: "IX_instractors_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Instractor_DID",
                table: "instractors",
                newName: "IX_instractors_DID");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Subject_InsId",
                table: "ins_subjects",
                newName: "IX_ins_subjects_InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instractors",
                table: "instractors",
                column: "InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ins_subjects",
                table: "ins_subjects",
                columns: new[] { "SubId", "InsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_instractors_InsManger",
                table: "Departments",
                column: "InsManger",
                principalTable: "instractors",
                principalColumn: "InsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ins_subjects_Subjects_SubId",
                table: "ins_subjects",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ins_subjects_instractors_InsId",
                table: "ins_subjects",
                column: "InsId",
                principalTable: "instractors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instractors_Departments_DID",
                table: "instractors",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_instractors_instractors_SupervisorId",
                table: "instractors",
                column: "SupervisorId",
                principalTable: "instractors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_instractors_InsManger",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_ins_subjects_Subjects_SubId",
                table: "ins_subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ins_subjects_instractors_InsId",
                table: "ins_subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_instractors_Departments_DID",
                table: "instractors");

            migrationBuilder.DropForeignKey(
                name: "FK_instractors_instractors_SupervisorId",
                table: "instractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instractors",
                table: "instractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ins_subjects",
                table: "ins_subjects");

            migrationBuilder.RenameTable(
                name: "instractors",
                newName: "Instractor");

            migrationBuilder.RenameTable(
                name: "ins_subjects",
                newName: "Ins_Subject");

            migrationBuilder.RenameIndex(
                name: "IX_instractors_SupervisorId",
                table: "Instractor",
                newName: "IX_Instractor_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_instractors_DID",
                table: "Instractor",
                newName: "IX_Instractor_DID");

            migrationBuilder.RenameIndex(
                name: "IX_ins_subjects_InsId",
                table: "Ins_Subject",
                newName: "IX_Ins_Subject_InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instractor",
                table: "Instractor",
                column: "InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject",
                columns: new[] { "SubId", "InsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instractor_InsManger",
                table: "Departments",
                column: "InsManger",
                principalTable: "Instractor",
                principalColumn: "InsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subject_Instractor_InsId",
                table: "Ins_Subject",
                column: "InsId",
                principalTable: "Instractor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subject_Subjects_SubId",
                table: "Ins_Subject",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractor_Departments_DID",
                table: "Instractor",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instractor_Instractor_SupervisorId",
                table: "Instractor",
                column: "SupervisorId",
                principalTable: "Instractor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
