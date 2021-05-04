using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoPWA.Migrations
{
    public partial class criaBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TipoCliente");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TipoCliente",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
