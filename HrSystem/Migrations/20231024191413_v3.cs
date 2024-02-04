using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrSystem.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Departmentid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Departmentid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Departmentid",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "phone",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_dept_id",
                table: "Employees",
                column: "dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_dept_id",
                table: "Employees",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_dept_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_dept_id",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "phone",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Departmentid",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Departmentid",
                table: "Employees",
                column: "Departmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Departmentid",
                table: "Employees",
                column: "Departmentid",
                principalTable: "Departments",
                principalColumn: "id");
        }
    }
}
