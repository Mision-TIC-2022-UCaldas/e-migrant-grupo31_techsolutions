using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MigrationTecSolution2021.Data.Migrations
{
    public partial class RegistroServicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegServicios",
                columns: table => new
                {
                    NDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegServicios", x => x.NDocumento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegServicios");
        }
    }
}
