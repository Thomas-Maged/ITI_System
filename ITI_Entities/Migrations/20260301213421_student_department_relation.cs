using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Entities.Migrations
{
    /// <inheritdoc />
    public partial class student_department_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeptID",
                table: "Students",
                column: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DeptID",
                table: "Students",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "DeptID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DeptID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DeptID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "Students");
        }
    }
}
