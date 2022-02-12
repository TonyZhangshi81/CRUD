using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Department",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Department");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
