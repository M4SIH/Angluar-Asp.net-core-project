using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class EditCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PracticalTim",
                table: "Courses",
                newName: "PracticalTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PracticalTime",
                table: "Courses",
                newName: "PracticalTim");
        }
    }
}
