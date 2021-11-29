using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MigrationTecSolution2021.Data.Migrations
{
    public partial class Relacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistroNecNit",
                table: "Migrantes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Migrantes_RegistroNecNit",
                table: "Migrantes",
                column: "RegistroNecNit");

            migrationBuilder.AddForeignKey(
                name: "FK_Migrantes_registroNecs_RegistroNecNit",
                table: "Migrantes",
                column: "RegistroNecNit",
                principalTable: "registroNecs",
                principalColumn: "Nit",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migrantes_registroNecs_RegistroNecNit",
                table: "Migrantes");

            migrationBuilder.DropIndex(
                name: "IX_Migrantes_RegistroNecNit",
                table: "Migrantes");

            migrationBuilder.DropColumn(
                name: "RegistroNecNit",
                table: "Migrantes");
        }
    }
}
