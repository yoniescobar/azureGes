using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvalTIC.Migrations
{
    public partial class llavaForaneaAUsuarioDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rol",
                newName: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Rol",
                newName: "Id");
        }
    }
}
