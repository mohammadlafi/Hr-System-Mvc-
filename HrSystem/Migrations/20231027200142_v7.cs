using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrSystem.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Citys",
                newName: "CityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Citys",
                newName: "Name");
        }
    }
}
