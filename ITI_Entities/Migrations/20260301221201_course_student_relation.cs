using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Entities.Migrations
{
    /// <inheritdoc />
    public partial class course_student_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course_Students",
                columns: table => new
                {
                    CrsID = table.Column<int>(type: "int", nullable: false),
                    StdID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_Students", x => new { x.CrsID, x.StdID });
                    table.ForeignKey(
                        name: "FK_course_Students_Courses_CrsID",
                        column: x => x.CrsID,
                        principalTable: "Courses",
                        principalColumn: "CrsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_Students_Students_StdID",
                        column: x => x.StdID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_Students_StdID",
                table: "course_Students",
                column: "StdID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_Students");
        }
    }
}
