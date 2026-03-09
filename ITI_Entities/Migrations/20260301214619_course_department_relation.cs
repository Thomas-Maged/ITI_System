using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Entities.Migrations
{
    /// <inheritdoc />
    public partial class course_department_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CoursesCrsID = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDeptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CoursesCrsID, x.DepartmentsDeptID });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Courses_CoursesCrsID",
                        column: x => x.CoursesCrsID,
                        principalTable: "Courses",
                        principalColumn: "CrsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_DepartmentsDeptID",
                        column: x => x.DepartmentsDeptID,
                        principalTable: "Departments",
                        principalColumn: "DeptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentsDeptID",
                table: "CourseDepartment",
                column: "DepartmentsDeptID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDepartment");
        }
    }
}
