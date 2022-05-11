using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class refactorcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PsicologoId",
                table: "Schedules",
                newName: "PsychologistId");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Schedules",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Dia",
                table: "Schedules",
                newName: "Day");

            migrationBuilder.RenameColumn(
                name: "AgendaId",
                table: "Schedules",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_PsicologoId",
                table: "Schedules",
                newName: "IX_Schedules_PsychologistId");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Psycologists",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Psycologists",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Psycologists",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Psycologists",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AprovadoEPSI",
                table: "Psycologists",
                newName: "ApprovedEPSI");

            migrationBuilder.RenameColumn(
                name: "Abordagem",
                table: "Psycologists",
                newName: "Approach");

            migrationBuilder.RenameColumn(
                name: "PsicologoId",
                table: "Psycologists",
                newName: "PsychologistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Schedules",
                newName: "Horario");

            migrationBuilder.RenameColumn(
                name: "PsychologistId",
                table: "Schedules",
                newName: "PsicologoId");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Schedules",
                newName: "Dia");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Schedules",
                newName: "AgendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_PsychologistId",
                table: "Schedules",
                newName: "IX_Schedules_PsicologoId");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Psycologists",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Psycologists",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Psycologists",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Psycologists",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "ApprovedEPSI",
                table: "Psycologists",
                newName: "AprovadoEPSI");

            migrationBuilder.RenameColumn(
                name: "Approach",
                table: "Psycologists",
                newName: "Abordagem");

            migrationBuilder.RenameColumn(
                name: "PsychologistId",
                table: "Psycologists",
                newName: "PsicologoId");
        }
    }
}
