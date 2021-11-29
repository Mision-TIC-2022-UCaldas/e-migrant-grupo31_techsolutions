using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MigrationTecSolution2021.Data.Migrations
{
    public partial class NombreSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreDelServicio",
                table: "RegServicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreDelServicio",
                table: "RegServicios");
        }
    }
}
