using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class refactoragenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Domingo",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Quarta",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Quinta",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Sabado",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Segunda",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "Terça",
                table: "Agendas",
                newName: "Horario");

            migrationBuilder.RenameColumn(
                name: "Sexta",
                table: "Agendas",
                newName: "Dia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Agendas",
                newName: "Terça");

            migrationBuilder.RenameColumn(
                name: "Dia",
                table: "Agendas",
                newName: "Sexta");

            migrationBuilder.AddColumn<string>(
                name: "Domingo",
                table: "Agendas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Quarta",
                table: "Agendas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Quinta",
                table: "Agendas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Sabado",
                table: "Agendas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Segunda",
                table: "Agendas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
