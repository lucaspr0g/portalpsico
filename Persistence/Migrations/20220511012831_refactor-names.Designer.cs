// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220511012831_refactor-names")]
    partial class refactornames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Psycologist", b =>
                {
                    b.Property<string>("PsicologoId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Abordagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("AprovadoEPSI")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CRP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("PsicologoId")
                        .HasName("pkPsicologo");

                    b.ToTable("Psycologists");
                });

            modelBuilder.Entity("Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("AgendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dia")
                        .HasColumnType("longtext");

                    b.Property<string>("Horario")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PsicologoId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("AgendaId")
                        .HasName("pkAgenda");

                    b.HasIndex("PsicologoId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleBooking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PsycologistId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("BookingId")
                        .HasName("pkReserva");

                    b.HasIndex("PsycologistId");

                    b.ToTable("ScheduleBookings");
                });

            modelBuilder.Entity("Domain.Entities.Schedule", b =>
                {
                    b.HasOne("Domain.Entities.Psycologist", "Psicologo")
                        .WithMany("Agendas")
                        .HasForeignKey("PsicologoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fkpsicologoAgendaId");

                    b.Navigation("Psicologo");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleBooking", b =>
                {
                    b.HasOne("Domain.Entities.Psycologist", "Psycologist")
                        .WithMany("Reservas")
                        .HasForeignKey("PsycologistId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fkpsicologoReservaId");

                    b.Navigation("Psycologist");
                });

            modelBuilder.Entity("Domain.Entities.Psycologist", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
