using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MigrationTecSolution2021.Data.Migrations
{
    public partial class ConServicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConServicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDeEntidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreDelServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Necesidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximoNumeroDeMigrantes = table.Column<int>(type: "int", nullable: false),
                    FechaDeInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeFinalizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoServicio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConServicios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConServicios");
        }
    }
}
